using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;

namespace API_test
{
    class Item:Login
    {
        private const string ITEM_ROUTE = "/item";

        public Item()
        {
            POST_Login();
        }
        public Item(string name, string password) : base(name, password)
        {
            POST_Login();
        }

        public string GET_getItem(string token, int index)
        {
            Request = new RestRequest(ITEM_ROUTE+"/"+index, Method.GET);
            Request.AddParameter("token", Token);

            Response = Client.Execute(Request);
            Console.WriteLine(Response.Content);
            Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(Response.Content);
            return values["content"];
        }

        public bool POST_AddItem(string token, string item, int index)
        {
            Request = new RestRequest(ITEM_ROUTE+"/"+index, Method.POST);
            Request.AddParameter("token", token);
            Request.AddParameter("item", item);
           

            Response = Client.Execute(Request);
            Console.WriteLine(Response.Content);
            Dictionary<string, bool> values = JsonConvert.DeserializeObject<Dictionary<string, bool>>(Response.Content);
            return values["content"];
        }

        public bool PUT_UpdateItem(string token, string item, int index)
        {
            Request = new RestRequest(ITEM_ROUTE + "/" + index, Method.PUT);
            Request.AddParameter("token", token);
            Request.AddParameter("item", item);


            Response = Client.Execute(Request);
            Console.WriteLine(Response.Content);
            Dictionary<string, bool> values = JsonConvert.DeserializeObject<Dictionary<string, bool>>(Response.Content);
            return values["content"];
        }

        public bool DELETE_DeleteItem(string token, int index)
        {
            Request = new RestRequest(ITEM_ROUTE + "/" + index, Method.DELETE);
            Request.AddParameter("token", token);   

            Response = Client.Execute(Request);
            Console.WriteLine(Response.Content);
            Dictionary<string, bool> values = JsonConvert.DeserializeObject<Dictionary<string, bool>>(Response.Content);
            return values["content"];
        }
    }
}
