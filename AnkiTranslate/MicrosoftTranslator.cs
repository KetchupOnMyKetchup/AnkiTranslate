using System;
using System.Configuration;
using System.IO;
using System.Text;
using System.Web;

namespace AnkiTranslate
{
    public class MicrosoftTranslator
    {
        public string Translate()
        {
            string clientId = ConfigurationManager.AppSettings["clientID"];
            string clientSecret = ConfigurationManager.AppSettings["clientSecret"];
            string strTranslatorAccessUri = ConfigurationManager.AppSettings["strTranslatorAccessURI"]; 

            String strRequestDetails = string.Format("grant_type=client_credentials&client_id={0}&client_secret={1}&scope=http://api.microsofttranslator.com", HttpUtility.UrlEncode(clientId), HttpUtility.UrlEncode(clientSecret));

            System.Net.WebRequest webRequest = System.Net.WebRequest.Create(strTranslatorAccessUri);
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Method = "POST";

            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(strRequestDetails);
            webRequest.ContentLength = bytes.Length;

            using (var outputStream = webRequest.GetRequestStream()) outputStream.Write(bytes, 0, bytes.Length);

            System.Net.WebResponse webResponse = webRequest.GetResponse();

            var serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(AdmAccessToken));

            //Get deserialized object from JSON stream 
            AdmAccessToken token = (AdmAccessToken)serializer.ReadObject(webResponse.GetResponseStream());
            if (token == null) throw new ArgumentNullException("token");

            string headerValue = "Bearer " + token.access_token;

            // User input text to translate plus chosen TO and FROM languages 
            string uri = "http://api.microsofttranslator.com/v2/Http.svc/Translate?text=" +
                HttpUtility.UrlEncode(ConfigClass.TextToTranslate) + "&from=" + ConfigClass.LanguageTranslatedFrom + "&to=" + ConfigClass.LanguageToTranslateTo;
            System.Net.WebRequest translationWebRequest = System.Net.WebRequest.Create(uri);
            translationWebRequest.Headers.Add("Authorization", headerValue);
            System.Net.WebResponse response = null;
            response = translationWebRequest.GetResponse();
            Stream stream = response.GetResponseStream();

            Encoding encode = Encoding.GetEncoding("utf-8");
            var translatedStream = new StreamReader(stream, encode);
            System.Xml.XmlDocument xTranslation = new System.Xml.XmlDocument();
            xTranslation.LoadXml(translatedStream.ReadToEnd());

            return xTranslation.InnerText;
        }
    }
}
