using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriver_basics
{
    class CheckSauceLabsHomePage
    {
        [Test]
        public void site_header_is_on_home_page()
        {
            string login = "zinkoviktor";
            string password = "viktor11";
            string email = "zinkoviktor@ukr.net";

            IWebDriver driver = new ChromeDriver(@"C:\Users\Victor\Desktop\WebDriver_basics\packages\Selenium.Chrome.WebDriver.2.41\driver\");

            MainPage mainPage = new MainPage(driver);
                //mainPage.closeHelloBar();
            LoginPage loginPage = mainPage.openLoginPage();
            try
            {
                mainPage = loginPage.loginAs(login, password);
            }
            catch (NoSuchElementException)
            {
                SingUp singUp = loginPage.OpenSingUp();
                mainPage = singUp.createAnAccount(login, password, email);
            }
         
            mainPage.choseJQuery();
            driver.SwitchTo().Frame("result");
            string color = driver.FindElement(By.Id("banner-message")).GetCssValue("background");
            driver.FindElement(By.TagName("button")).Click();             
            Assert.AreNotEqual(driver.FindElement(By.Id("banner-message")).GetCssValue("background"), color);
            driver.SwitchTo().ParentFrame();

            driver.Close();
        }
    }
}
