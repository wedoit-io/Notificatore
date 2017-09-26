Funzionamento generale
======================

In Notificatore è composto :

1. Una interfaccia web di gestione
2. Una Api Rest di registrazione del dispositivo
3. Un web service SOAP per l'invio delle notifiche (API)


Interfaccia di gestione
-----------------------
L'interfaccia di gestione del Notificatore, è ad uso esclusivo del Team di sviluppo. All'interno di tale interfaccia vengono:

1. Configurate le app per le quali inviare le notifiche
2. Gestiti i certificati digitali per l'invio delle notifiche

Registrazione dei device token
------------------------------
Ogni volta che una app mobile viene aperta, viene effettuata una chiamata a questo servizio passando:

1. Lo username dell'utente che sta aprendo l'applicazione (oppure guest o null se l'applicazione non ha una autenticazione
2. Un device token, ovvero un numero che identifica univocamente il dispositivo.

In questo modo il Notificatore può mantenere nel suo database l'associazione chiave valore di utente e dispositivo.


    L'associazione utente / device toker, per questioni di sicurezza, viene periodicamente cambiata da Apple.


Invio delle notifiche push
--------------------------
L'invio delle notifiche push avviene attraverso l'utilizzo delle API di integrazione.
Una applicazione che vuole mandare una notifica, chiama le API passando:

1. **username** - Identificativo univoco dell'utente
2. **messaggio** - Testo di max 255 caratteri che contiene il messaggio da inviare.

A questo punto il notificatore cerca nel proprio database i device token associati a quello username e invia, ad ognuno di essi, il messaggio.

Tale invio passa dai server di :

* Apple, nel caso di notifiche push su **iOs**
* Google, nel caso di notifiche push su **Android**
* Microsoft, nel caso di notifiche push verso **Windows Phone**.

Tutte le richieste ricevute dal notificatore vengono messe in una coda di elaborazione e smistate in base al carico di lavoro. Di solito questo invio è comunque istantaneo.
