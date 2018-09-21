using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;

namespace WebDriver_basics
{
    public class SingUp
    {
        By usernameLocator = By.Id("id_username");
        By emailLocator = By.Id("id_email");
        By passwordLocator = By.Id("id_password1");
        By createAcountLocator = By.Id("session-form");
        
        private IWebDriver driver;

        public SingUp(IWebDriver driver)
        {
            this.driver = driver;           

            if (!driver.Title.StartsWith("Create"))
            {
                throw new Exception("This is not the SingUp page");
            }
        }

        public SingUp typeUsername(String username)
        {
            driver.FindElement(usernameLocator).SendKeys(username);
            return this;
        }

        public SingUp typePassword(String password)
        {
            driver.FindElement(passwordLocator).SendKeys(password);
            return this;
        }

        public SingUp typeEmail(String email)
        {
            driver.FindElement(emailLocator).SendKeys(email);
            return this;
        }

        public MainPage submitCreateAcount()
        {
            driver.FindElement(createAcountLocator).Submit();
            return new MainPage(driver);
        }

        public MainPage submitSingUpExpectingFailure()
        {
            driver.FindElement(createAcountLocator).Submit();
            return new MainPage(driver);
        }

        public MainPage createAnAccount(String username, String password, String email)
        {
            typeUsername(username);
            typeEmail(email);
            typePassword(password);
            
            return submitCreateAcount();
        }
    }
}
