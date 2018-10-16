using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;

namespace API_test
{
    class Login:Application
    {
        private const string LOGIN_ROUTE = "/login";
        public string Token { get; private set; }
        public string Name { get; private set; }
        public string Password { get; private set; }

        public Login()
        {
            Name = "admin";
            Password = "qwerty";
            POST_Login();
        }

        public Login(string name, string password)
        {
            Name = name;
            Password = password;
            POST_Login();
        }
                
        public string POST_Login()
        {
            Request = new RestRequest(LOGIN_ROUTE, Method.POST);
            Request.AddParameter("name", Name);
            Request.AddParameter("password", Password);

            Response = Client.Execute(Request);

            Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(Response.Content);
            Token = values["content"];
            return values["content"];
        }
    }
}
