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

```

How to
======

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
-----------
* https://oracle-base.com/articles/11g/fine-grained-access-to-network-services-11gr1

