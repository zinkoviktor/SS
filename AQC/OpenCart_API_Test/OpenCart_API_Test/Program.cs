using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;

namespace OpenCart_API_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            const string URL = "http://localhost/oc/index.php";
            const string ROUTE = "?route=api";
            const string LOGIN_ROUTE = "/login";
            string API_TOKEN;
            const string NAME = "myAPI";
            const string KEY = "98d812f8abada2b6e1ff319e32b498cb120952ce83157e011adbd3527068ebf06a8806e3867fd97844fe1ec633c2b1aa5a33d165d364edc8ec8ab08ef1e2a86e84884e4e0202a0a93530684f231acba26e18dc181b1bf033a9e972eac981c974657b2aa7366a4fac334e97ec68edaf314b80b0c149b96dcb4c8727a24bd95422";
            const string PARAMETR_NAME = "multipart/form-data; boundary=----WebKitFormBoundary7MA4YWxkTrZu0gW";
            const string PARAMETR_VALUE = "------WebKitFormBoundary7MA4YWxkTrZu0gW\r\nContent-Disposition: form-data; name=\"username\"\r\n\r\n"+NAME+"\r\n------WebKitFormBoundary7MA4YWxkTrZu0gW\r\nContent-Disposition: form-data; name=\"key\"\r\n\r\n"+KEY+"\r\n------WebKitFormBoundary7MA4YWxkTrZu0gW--";

            RestClient Client = new RestClient(URL+ROUTE+LOGIN_ROUTE);
            RestRequest Request = new RestRequest(Method.POST);            
            Request.AddParameter(PARAMETR_NAME, PARAMETR_VALUE, ParameterType.RequestBody);

            IRestResponse Response = Client.Execute(Request);
            int index = Response.Content.IndexOf('{');
            string responseJson = Response.Content.Remove(0, index);

            Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseJson);
            API_TOKEN = values["api_token"];            
            Console.WriteLine(API_TOKEN);

            Console.ReadKey();
        
        }  

    }
}
