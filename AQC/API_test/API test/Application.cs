using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;

namespace API_test
{
    class Application
    {
        public Uri URL { get; private set; }
        public RestClient Client { get; private set; }
        public IRestResponse Response { get; set; }
        public RestRequest Request { get; set; }

        public Application()
        {
            const string url = "http://localhost:8080/";
            URL = new Uri(url);
            Client = new RestClient(URL);            
        }
        public Application(string URL)
        {
            this.URL = new Uri(URL);
            Client = new RestClient(URL);
        }

        public void PrintHelpInfo()
        {
            Request = new RestRequest(Method.GET);
            Response = Client.Execute(Request);

            Dictionary<string, List<string>> values = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(Response.Content);

            //Writes to the console, a help information about the Methods 
            int i = 0;
            Console.WriteLine("API help info:");            
            foreach(var item in values["content"])
            {
                Console.Write("{0} = ", i);
                Console.WriteLine(item);
                i++;
            }            
        }

    }
}
