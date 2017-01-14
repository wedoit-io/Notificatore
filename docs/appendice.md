Appendice
==========

Inviare notifiche da PL/SQL
---------------------------
Per Oracle è disponibile una procedura di database (pl/sql) che consente l'invio di notifiche da stored procedure.

La procedura è disponibile a `questo link <https://github.com/teopost/oracle-scripts/blob/master/notificatore.sql>`_

Inviare notifiche da C#
-----------------------

1. Aprire un nuovo progetto in visual studio (es: NotificatoreSample)
2. Nel Solution Explorer cliccare il tasto destro e selezionare **Add** e **Service Reference**
3. Cliccare il bottone **Advanced**
4. Cliccare il pulsante **Add Web Reference**
5. Inserire nell'url il riferimento al wsdl (es: http://notificatore.apexnet.it/ws/NotificatoreWS.asmx?wsdl)
6. In **Web Reference Name** lasciare it.apexnet.notificatore
7. Cliccare **Add Reference**
8. Incollare il seguente codice:

```csharp
    string AuthKey = "AUTH-KEY HERE";
    string ApplKey = "APPL-KEY HERE";

    it.apexnet.notificatore.Notificatore notificatore_ = new it.apexnet.notificatore.Notificatore();

    string outSendNotifica = notificatore_.SendNotification(AuthKey, ApplKey, "Hello World", "w.coyote@acme.com", "default", 0);

    if (outSendNotifica != "")
    {
        string outErrore = "Errore: " + outSendNotifica;
    }
 ```
