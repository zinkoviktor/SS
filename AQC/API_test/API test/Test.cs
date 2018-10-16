using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace API_test
{
    [TestFixture]
    class Test
    {
        [TestCase("admin", "qwerty", 32)]
        public void Login_Test(string name, string password, int tokenLength)
        {

            Login login = new Login(name, password);

            Assert.AreEqual(login.POST_Login().Length, tokenLength, "POST test, failed");
        }

        [TestCase("admin", "qwerty")]
        public void User_Test(string name, string password)
        {
            User user = new User(name, password);
            Assert.AreEqual(user.GET_UserName(user.Token), name, "GET test, failed");            
        }

        [TestCase("Hello", "Good bye!", 1)]
        public void Item_Test(string firstItem, string secondItem, int index)
        {
            Item item = new Item();
           
            Assert.IsTrue(item.POST_AddItem(item.Token, firstItem, index), "POST test (return), failed");
            
            Assert.AreEqual(item.GET_getItem(item.Token, index), firstItem, "POST or GET test, failed");

            Assert.IsTrue(item.PUT_UpdateItem(item.Token, secondItem, index), "PUT test (return), failed");
            Assert.AreEqual(item.GET_getItem(item.Token, index), secondItem, "PUT test, failed");

            Assert.IsTrue(item.DELETE_DeleteItem(item.Token, index), "DELETE test (return), failed");
            Assert.IsNull(item.GET_getItem(item.Token, index), "DELETE test, failed");
        }

        
    }
}
