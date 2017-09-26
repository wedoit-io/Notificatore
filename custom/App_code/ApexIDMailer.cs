// ***************************************************************
// Implementazione Mailer (local)
// ***************************************************************
using System;
using System.Collections;
using System.Net;
using System.Net.Mail;
using System.Text;

public class ApexIDMailer:Object
	{
		// Modifica Apex-net
    public bool SevenBitMultiPart = false;
    public bool EnableSSL = false;
    public Encoding CustomEncoding = null;
    // Fine Modifica
     
		// Interfaccia comune con altri mailers
		public String Subject;
		public String Body;
    public String HTMLBody;
    public bool ConfirmRead = false;
		public String FromAddress;
		public String FromName;
		public String Organization;
		public int Priority = 3;
		public bool ReturnReceipt = false;
		public String LastError = "";
		
		private ArrayList TOs = new ArrayList();
		private ArrayList CCs = new ArrayList();
		private ArrayList BCCs = new ArrayList();
		private ArrayList ReplyTos = new ArrayList();

    // Attachments
		private ArrayList Files = new ArrayList();
    private ArrayList FileNames = new ArrayList();
    private ArrayList FileCntTypes = new ArrayList();
		
		private String RelayServer;
    private int RelayPort;
		internal String UserName;
		internal String Password;

		public virtual void  AddToAddress(String NewAddress)
		{
			TOs.Add(NewAddress);
		}
		
		public virtual void  AddCCAddress(String NewAddress)
		{
			CCs.Add(NewAddress);
		}
		
		public virtual void  AddBCCAddress(String NewAddress)
		{
			BCCs.Add(NewAddress);
		}
		
		public virtual void  AddReplyToAddress(String NewAddress)
		{
			ReplyTos.Add(NewAddress);
		}

    public virtual void  AddAttachment(String NewFile) { AddAttachment(NewFile, null, null); }
    public virtual void  AddAttachment(String NewFile, String Name) { AddAttachment(NewFile, Name, null); }
    public virtual void  AddAttachment(String NewFile, String Name, String CntType)
		{
			Files.Add(NewFile);
      FileNames.Add(Name);
      FileCntTypes.Add(CntType);
		}
		
		public virtual void  ResetContainers()
		{
			TOs.Clear();
			CCs.Clear();
			BCCs.Clear();
			ReplyTos.Clear();
			Files.Clear();
      FileNames.Clear();
      FileCntTypes.Clear();
		}

    public virtual void SetRelayServer(String MailServer, String User, String Pwd) { SetRelayServer(MailServer, 25, User, Pwd); }
		public virtual void  SetRelayServer(String MailServer, int Port, String User, String Pwd)
		{
			RelayServer = MailServer;
      RelayPort = Port;
			UserName = User;
			Password = Pwd;
		}
		
		public virtual void  SendMail()
		{
      LastError = "";
      try
      {
        SmtpClient client = new SmtpClient(RelayServer, RelayPort);
        if ((UserName!=null && UserName.Length > 0) || (Password!=null && Password.Length > 0))
          client.Credentials = new NetworkCredential(UserName, Password);
        else
          client.UseDefaultCredentials = true;
        //
        // La socket rimarrà aperta al massimo 1 secondo in idle prima di essere chiusa
        client.ServicePoint.MaxIdleTime = 1000;
        //
        // Creo il messaggio
        MailMessage msg = new MailMessage();
        //
        // Aggiungo il FROM
        msg.From = new MailAddress(FromAddress, FromName);
				//
        // Aggiungo il TO
				for (int i = 0; i < TOs.Count; i++)
          msg.To.Add((String)TOs[i]);
				//
        // Aggiungo il CC
        for (int i = 0; i < CCs.Count; i++)
          msg.CC.Add((String)CCs[i]);
				//
        // Aggiungo il BCC
        for (int i = 0; i < BCCs.Count; i++)
          msg.Bcc.Add((String)BCCs[i]);
				//
        // Aggiungo il Reply To
        if (ReplyTos.Count > 0)
          msg.ReplyTo = new MailAddress((String)ReplyTos[0]);
				//
        // Aggiungo Subject e Body
        msg.Subject = Subject;
				msg.BodyEncoding = Encoding.GetEncoding("Windows-1252");
				if (Body == null && HTMLBody != null)
				{
					msg.Body = HTMLBody;
					msg.IsBodyHtml = true;
				}
				else
					msg.Body = Body;
        //
				// Aggiungo gli attachments
				for (int i = 0; i < Files.Count; i++)
				{
          Attachment att = new Attachment((String)Files[i]);
          if (FileNames[i] != null && ((String)FileNames[i]).Length > 0)
          {
            att.Name = (String)FileNames[i];
            att.ContentId = (String)FileNames[i];
          }
          if (FileCntTypes[i] != null && ((String)FileCntTypes[i]).Length > 0)
            att.ContentType = new System.Net.Mime.ContentType((String)FileCntTypes[i]);
          msg.Attachments.Add(att);
				}
				//
				// Altri Headers
        msg.Priority = (Priority == 3 ? MailPriority.Normal : (Priority < 3 ? MailPriority.High : MailPriority.Low));
        msg.DeliveryNotificationOptions = DeliveryNotificationOptions.None;
        if (ReturnReceipt)
          msg.DeliveryNotificationOptions |= DeliveryNotificationOptions.OnSuccess;
        if (ConfirmRead)
          msg.Headers.Add("Disposition-Notification-To", FromAddress);
        
        // Modifica Apex-net
        if (EnableSSL == true)
        {
           client.EnableSsl = true;
        }

        if (SevenBitMultiPart == true )
        {
	        AlternateView av = AlternateView.CreateAlternateViewFromString(msg.Body, Encoding.GetEncoding("iso-8859-1"), "text/plain");
	        av.TransferEncoding = System.Net.Mime.TransferEncoding.SevenBit;
	        msg.AlternateViews.Add(av);
        }
  		// Fine Modifica
  			
        if (CustomEncoding != null)
        {
          msg.SubjectEncoding = CustomEncoding;
          msg.BodyEncoding = CustomEncoding;
        }
        //
        // Spedisco il messaggio
        client.Send(msg);
        //
        // Libero tutti gli attachments
        msg.Attachments.Dispose();
      }
			catch (Exception e)
			{
				LastError = e.Message;
        Console.Error.WriteLine(e.Message + "\n" + e.StackTrace); Console.Error.Flush();
        throw e;
			}
		}
		
		public virtual bool ValidateAddress(String Address)
		{
      return false;
/*
			try
			{
				UriBuilder a = new UriBuilder("mailto:" + Address);
				//a.validate();
				return true;
			}
			catch (Exception e)
			{
				return false;
			}
*/
		}
	}
