Utilizzo delle API
===================

La spedizione di una o più notifiche push, viene effettuata esclusivamente attraverso l'utilizzo delle API.

Il ws service pubblico è questo: http://notificatore.apexnet.it/ws/NotificatoreWS.asmx

    L'indirizzo sopra riportato è solo ad titolo di esempio. Esistono varie installazioni del notificatore e tale indirizzo, a seconda dei casi, viene comunicato direttamente dal personale tecnico. Per altri casi si veda l'Appendice.

SendNotification
----------------
Come si può vedere, il web service espone alcuni metodi pubblici, ma solo uno di essi deve essere utilizzato per l'invio delle notifiche, ovvero il **SendNotification**.

Tale metodo richiede in input i seguenti parametri:

==============  =============
Parametri       Descrizione
==============  =============
pAuthKey        Chiave di autenticazione (fornita da Apexnet)
pApplicationKey Chiave dell'applicazione (fornita da Apexnet)
pMessage        Messaggio da inviare (max 255 caratteri)
pUsername       Chiave dell'utente a cui inviare il messaggio (es. username)
pSound          Nome di un file audio da eseguire alla ricezione del messaggio. Impostare stringa vuota a meno che non sia gestito diversamente dall'app
pBadge          Numero che appare sulla icona dell'applicazione (solo se gestito nell'app)
==============  =============
