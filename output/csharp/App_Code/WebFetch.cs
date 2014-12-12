using System;
using System.IO;
using System.Net;
using System.Text;


/// <summary>
/// Fetches a Web Page
/// </summary>
class WebFetch
{
	public static string getHtml(string url)
	{
		HttpWebRequest myWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
		
		myWebRequest.Method = "GET";
		// make request for web page
		HttpWebResponse myWebResponse = (HttpWebResponse)myWebRequest.GetResponse();
		
		StreamReader myWebSource = new StreamReader(myWebResponse.GetResponseStream(), Encoding.GetEncoding("ISO-8859-1"));
		string myPageSource = string.Empty;
		myPageSource= myWebSource.ReadToEnd();
		myWebResponse.Close();
		return myPageSource;
	}


    public static string getHtml1(string url)
    {
     
        WebClient client = new WebClient();

        client.Encoding = System.Text.Encoding.UTF8;

        client.Headers.Add("user-agent",
        "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

        Stream data = client.OpenRead(url);
        StreamReader reader = new StreamReader(data,Encoding.GetEncoding("UTF-8"));
        string s = reader.ReadToEnd();
        data.Close();
        reader.Close();

        return s;
    }
}



