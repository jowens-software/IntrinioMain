using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft;

namespace Intrino
{
    class Program
    {
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        static void Main(string[] args)
        {
            //WebRequest request = WebRequest.Create("https://api.intrinio.com/prices?identifier=NUGT");
            WebRequest request = WebRequest.Create("https://api.intrinio.com/prices?identifier=NUGT");

            request.PreAuthenticate = true;
            var username = "replaceWithUsername";
            var password = "replaceWithPassword";
            var auth = "Basic " + Base64Encode(username + ':' + password).ToString();
            request.Headers.Add("Authorization", auth);
            request.ContentType = "application/json; charset=utf-8";

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                Console.WriteLine(reader.ReadToEnd());


                //StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                //string json = Newtonsoft.Json.JsonConvert.SerializeObject(reader.ReadToEnd());
                //Movie m = Newtonsoft.Json.JsonConvert.DeserializeObject<Movie>(json);
                ////Console.WriteLine(reader.ReadToEnd());
                //Console.WriteLine(json);
            }

            Console.ReadLine();
        }
    }
}
