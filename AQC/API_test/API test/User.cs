using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;

namespace API_test
{
    class User:Login
    {
        private const string USER_ROUTE = "/user";
        public string NewUserToken { get; private set; }

        public User()
        {
            POST_Login();
        }
        public User(string name, string password):base(name, password)
        {
            POST_Login();
        }

        public void POST_CreateUser(string adminToken, string name, string password, bool adminRights)
        {
            Request = new RestRequest(USER_ROUTE, Method.POST);
            Request.AddParameter("adminToken", adminToken);
            Request.AddParameter("newName", name);
            Request.AddParameter("newPassword", password);
            Request.AddParameter("adminRights", adminRights);

            Response = Client.Execute(Request);
            Console.WriteLine(Response.Content);
            Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(Response.Content);
            NewUserToken = values["content"];
        }

        public string GET_UserName(string Token)
        {
            Request = new RestRequest(USER_ROUTE, Method.GET);
            Request.AddParameter("token", Token);            

            Response = Client.Execute(Request);

            Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(Response.Content);
            return values["content"];
        }

        public bool PUT_ChangePassword(string Token, string oldPassword, string newPassword)
        {
            Request = new RestRequest(USER_ROUTE, Method.PUT);
            Request.AddParameter("token", Token);
            Request.AddParameter("oldPassword", oldPassword);
            Request.AddParameter("newPassword", newPassword);

            Response = Client.Execute(Request);

            Dictionary<string, bool> values = JsonConvert.DeserializeObject<Dictionary<string, bool>>(Response.Content);
            return values["content"];
        }

        public bool DELETE_RemoveUser(string adminToken, string removedName)
        {
            Request = new RestRequest(USER_ROUTE, Method.PUT);
            Request.AddParameter("adminToken", adminToken);
            Request.AddParameter("removedName", removedName);
            
            Response = Client.Execute(Request);

            Dictionary<string, bool> values = JsonConvert.DeserializeObject<Dictionary<string, bool>>(Response.Content);
            return values["content"];
        }
    }
}
