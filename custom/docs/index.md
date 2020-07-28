Documentazione su Push Notificator
=======

Introduzione
----------
Push Notificator WEDO è il sistema centralizzato di messaggistica push per IOS e Android per l'invio di notifiche push verso dispositivi mobile.
L'interfaccia e i servizi del "Push Notificator" sono raggiungibili all'indirizzo https://push.wedo.io:

Funzionamento
-------------
<descrivere qui il funzionamento del notificatore>

API
-----
<descrivere qui il funzionamneto delle API>

Inviare le notifiche con curl
-----------------------------

```bash
curl -X POST https://push.wedo.io/NotificaPush \
   -H "X-HTTP-Method-Override:SendPushAuth" \
   -H "Content-Type:application/json" \
   -H "X-AuthKey:5d15b54f-823f-4832-8b1d-a3bd0074u84d" \
   -d "{\"Message\":\"x\",\"TypeMessage\":2,\"UserName\":\"user@service.net\",\"Sound\":\"\",\"Badge\":0,\"CustomField1\":\"IC_MSG\",\"CustomField2\":\"1234\"}"
```

TODO
----
* Usare colore nella navbar #214080

Riferimenti
-------------
* http://127.0.0.1:1308/Notificatore/docs/index.html
* https://push.wedo.io/docs/index.html
