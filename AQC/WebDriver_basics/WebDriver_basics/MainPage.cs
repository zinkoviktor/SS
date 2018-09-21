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
    public class MainPage
    {
        private static String BASE_URL = @"https://jsfiddle.net";

        By helloBarCloseLocator = By.LinkText("Close");
        By jQueryButtonLocator = By.LinkText("jQuery");
        By singInLocator = By.Id("login");
        
        private IWebDriver driver;
        
        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
            open();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            if (!driver.Title.StartsWith(@"Create a new fiddle"))
            {
                throw new Exception("This is not the jsfiddle.net page");
            }
        }
        
        public void open()
        {
            driver.Navigate().GoToUrl(BASE_URL);            
        }

        public MainPage closeHelloBar()
        {
            driver.FindElement(helloBarCloseLocator).Click();
            return this;
        }
        public MainPage choseJQuery()
        {
            driver.FindElement(jQueryButtonLocator).Click();
            return this;
        }
        public SingUp openRegistration()
        {
            LoginPage loginPage = openLoginPage();            
            return loginPage.OpenSingUp();            
        }
        public void logout()
        {
            //To do
        }
        public LoginPage openLoginPage()
        {
            driver.FindElement(singInLocator).Click();
            return new LoginPage(driver);
        }
    }
}
