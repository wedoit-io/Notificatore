Notificatore
============

Sistema di gestione delle notifiche push di Apexnet

Il progetto sorgente INDE è gestito su Teamworks

La documentazione ' qua:

* http://doc-notificatore.wedoit.io

ACL
===
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
`
