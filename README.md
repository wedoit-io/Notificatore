Notificatore - Gestione delle notifiche push di WEDO
============

Il Notificatore WEDO è il sistema ccentralizzato di messaggistica push per IOS e Android.
L'interfaccia (e i servizi) del notificatore sono installati sul nostro server in cloud (aruba1) e sono raggiungibili a questi indirizzi:


* http://notificatore.apexnet.it - Frontend
* http://notificatore.apexnet.it/ws/NotificatoreWS.asmx - Web Service per l'invio delle notifiche


Le app mobile, quando vengono lanciate, inviano al notificatore una informazione di registrazione che comprende:

* un identificativo del dispositivo (token)
* uno username (opzionale)


NOTA: Il progetto sorgente INDE è gestito su Teamworks

ORACLE
===
E' possibile inviare notifiche push direttamente dal DB Oracle.
Per farlo bisogna configurare Oracle per consentirgli di comunicare con l'esterno.
Per farlo occorre configurare specifiche ACL

ACL
---
```plsql
/* Eseguire come system */
BEGIN
  DBMS_NETWORK_ACL_ADMIN.create_acl (
    acl          => 'notificatore.xml', 
    description  => 'Acl per invio notifiche push da DB',
    principal    => 'NOTIFICATORE',
    is_grant     => TRUE, 
    privilege    => 'connect');

  COMMIT;
END;
/

/* Add privilege of ACL to user MAIL_QUEUE */
BEGIN
  DBMS_NETWORK_ACL_ADMIN.ADD_PRIVILEGE
    (acl      => 'notificatore.xml', 
    principal => 'NOTIFICATORE',
    is_grant  =>  true, 
    privilege => 'resolve');
  commit;
END;
/

BEGIN
  DBMS_NETWORK_ACL_ADMIN.assign_acl (
    acl => 'notificatore.xml',
    host => 'notificatore.apexnet.it', 
    lower_port => 80,
    upper_port => NULL); 
  COMMIT;
END;
/

declare
  ret varchar2(100);
begin

ret :=  notificatore.SendNotification('Messaggio di test da DB Oracle', 'admin', 0, '3892DB2C-53A9-4B57-9638-08C1E91319C8' , 'IB');

end;

```

Procedura di DB
---

```plsql
FUNCTION SendNotification (p_Message IN VARCHAR2, p_Username in VARCHAR2, p_Badge in number default 0) RETURN VARCHAR2
is
 l_response_payload  XMLType;
 l_payload           varchar2(2000);
 l_payload_namespace varchar2(200);
 l_target_url        varchar2(200);
 l_RetValue          varchar2(2000);
 l_AuthKey           varchar2(36)  := '___AuthKey___';
 l_AppCode           varchar2(100) := '___AppCode___';
 l_SoundName         varchar2(100) := 'default';
 l_Badge             varchar2(10)  := to_char(p_Badge);


BEGIN


  if trim(p_Username) is null then
     raise_application_error(-20001, 'Errore: Lo Username deve essere valorizzato');
  end if;


  if trim(p_Message) is null then
     raise_application_error(-20002, 'Errore: Il Messaggio deve essere valorizzato');
  end if;

  l_payload_namespace := 'http://notificatore01.cineca.it/ws';
  l_target_url        := 'http://notificatore01.cineca.it/ws/NotificatoreWS.asmx';
  -- Pezzo di XML dentro il body della chiamata
  l_payload          :=
    '<prog:SendNotification soapenv:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
         <pAuthKey xsi:type="xsd:string">'|| l_AuthKey || '</pAuthKey>
         <pApplicationKey xsi:type="xsd:string">'|| l_AppCode || '</pApplicationKey>
         <pMessage xsi:type="xsd:string">' || p_Message || '</pMessage>
         <pUserName xsi:type="xsd:string">' || p_Username || '</pUserName>
         <pSound xsi:type="xsd:string">'|| l_SoundName || '</pSound>
         <pBadge xsi:type="xsd:int">'|| l_Badge || '</pBadge>
      </prog:SendNotification>';

  l_response_payload := soap_call(l_payload, l_target_url, 'http://www.progamma.com/SendNotification');

  -- Uso la chiamata dentro una select per evitare la raise dell'errore che mi verrebbe scatenata da una chiamata
  -- puntuale tipo a:= l_response_payload.extract...

  select l_response_payload.extract('//SendNotificationResult/text()','xmlns:tns="http://www.progamma.com/"').getStringVal() into l_RetValue from dual;
  return l_RetValue;

END;
/

create or replace procedure p_agg_notifiche
as
cursor c1 is   select rowid, user, testo
                from tabella
                where flg_sped = 0;
begin
    for f1 in c1 loop
       begin
          log_test:= notificatore.sendnotification(f1.testo, f1.matricola, 0);

          exception
          when others then
            --- se da errore
       end;

       update tabella
       set flg_sped = 1, data_sped = sysdate
       where rowid = f1.rowid;

    end loop;
end;
/
```

Allinterno della funzione ci sono due variabili da settare in base all'installazione:

* AuthKey chiave di autorizzarione del'app relativa
* AppCode identificativo della app

How to
------

Le impostazioni delle ACL si possono vedere dalle seguenti viste di sistema di Oracle:

* DBA_NETWORK_ACLS
* DBA_NETWORK_ACL_PRIVILEGES
* USER_NETWORK_ACL_PRIVILEGES


DROP ACL
----------

```plsql
BEGIN
  DBMS_NETWORK_ACL_ADMIN.drop_acl ( 
    acl         => 'notificatore.xml');

  COMMIT;
END;
/
```

Delete Privilege
----------------

```plsql
BEGIN
  DBMS_NETWORK_ACL_ADMIN.delete_privilege ( 
    acl         => 'test_acl_file.xml', 
    principal   => 'TEST2',
    is_grant    => FALSE, 
    privilege   => 'connect');

  COMMIT;
END;
/
```

Riferimenti
===
* https://oracle-base.com/articles/11g/fine-grained-access-to-network-services-11gr1

