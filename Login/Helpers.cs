using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    public class Helpers
    {
        //vars 
        public static string api_token = "";
        private static string baseurl = "http://chatapp.rickstoit.nl/api/";
        public List<string> Onlineusers;




        //post to api
        public static string webPostMethod(string postData, string suburl) {
            string responseFromServer = "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(baseurl+ suburl);
            request.Method = "POST";
            request.Credentials = CredentialCache.DefaultCredentials;
            ((HttpWebRequest)request).UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 7.1; Trident/5.0)";
            request.Accept = "application/json";
            request.UseDefaultCredentials = true;
            request.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            WebResponse response = request.GetResponse();
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            responseFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();
            return responseFromServer;
        }
        

        //get from api
        public static string webGetMethod(string suburl) {
          
            string jsonString = "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(baseurl+suburl);
            request.Headers.Add("Authorization", "Bearer " + api_token);
            request.Method = "GET";
            request.Credentials = CredentialCache.DefaultCredentials;
            ((HttpWebRequest)request).UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 7.1; Trident/5.0)";
            request.Accept = "application/json";
            request.UseDefaultCredentials = true;
            request.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
            request.ContentType = "application/json";
         
            WebResponse response = request.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream());
            jsonString = sr.ReadToEnd();
            sr.Close();
            return jsonString;
        }

        //checks what users are online
        public static void CheckOnline() {
            var online = webGetMethod("online");
            Console.WriteLine(online);
            dynamic users = JsonConvert.DeserializeObject(online);
            foreach(var persoon in users)
            {
                Console.WriteLine(persoon.name);
            }
        }
    }

}

