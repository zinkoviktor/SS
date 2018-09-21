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
    public class LoginPage
    {
        By usernameLocator = By.Id("id_username");
        By passwordLocator = By.Id("id_password");
        By singInLocator = By.Id("session-form");
        By singUpLocator = By.LinkText("Sign up");
        By errorListLocator = By.ClassName("errorsList");
        

        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;

            if (!driver.Title.StartsWith("Log in"))
            {
                throw new Exception("This is not the login page");
            }
        }

        public LoginPage typeUsername(String username)
        {
            driver.FindElement(usernameLocator).SendKeys(username);
            return this;
        }

        public LoginPage typePassword(String password)
        {
            driver.FindElement(passwordLocator).SendKeys(password);
            return this;
        }

        public MainPage submitLogin()
        {            
            driver.FindElement(singInLocator).Submit();
            try
            {
                driver.FindElement(errorListLocator);
            }
            catch(NoSuchElementException)
            {
                return new MainPage(driver);
            }
            throw new Exception("Incorrect login and password");
        }   

        public MainPage loginAs(String username, String password)
        {
            typeUsername(username);
            typePassword(password);
            return submitLogin();
        }

        public SingUp OpenSingUp()
        {
            driver.FindElement(singUpLocator).Click();
            return new SingUp(driver);
        }
    }
}
