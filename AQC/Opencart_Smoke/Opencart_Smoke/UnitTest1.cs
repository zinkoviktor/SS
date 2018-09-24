using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

//Functional Decomposition???
namespace Opencart_Smoke
{
    [TestFixture]
    public class UnitTest1
    {
        //string price;

        //Registration data
        string firstName = "Victor";
        string lastName = "Zinko";
        string email = "zinkoexp@gmail.com";
        string telephone = "+380979797979";
        string address1 = "Naukova, 5";
        string city = "Lviv";
        string postCode = "80000";
        string country = "220"; //Ukraine
        string region = "3493"; //L'vivs'ka Oblast'

        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://atqc-shop.epizy.com");
        }
        [TearDown]
        public void TearDown()
        {
           driver.Quit();
        }

        [Test]
        [TestCase("iPhone SE 64GB")]
        [TestCase("iPhone")]
        public void SmokeTesting(string productName)
        {
            if (!driver.Title.Equals("Your Store"))
            {
                throw new Exception("This is not main page");
            }

            /* Search */

            driver.FindElement(By.Id("search"));
            //searchInput 
            driver.FindElement(By.Name("search")).SendKeys(productName);
            //searchButton
            driver.FindElement(By.CssSelector("#search .btn.btn-default.btn-lg")).Click();
            
            /* "iPhone SE 64GB" */

            //Go to details
            driver.FindElement(By.PartialLinkText(productName)).Click();
            //Add to Card
            driver.FindElement(By.Id("button-cart")).Click();
            //Go to Card
            driver.FindElement(By.CssSelector("a[href$='/cart']")).Click();
            //Price
            //price = driver.FindElement(By.CssSelector("/*TO DO*/"));
            //Go to Checkout
            driver.FindElement(By.CssSelector("a[href$='/checkout']")).Click();
            
            /* Checkout */

            if (!driver.Title.Equals("Checkout"))
            {
                throw new Exception("This is not Checkout page");
            }                       
            
            /*
             * Checkout Options
             */

            //Wait
            IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("collapse-checkout-option")));
            //Guest Checkout - radiobutton
            driver.FindElement(By.CssSelector("input[value='guest'")).Click();
            //Continue
            driver.FindElement(By.Id("button-account")).Click();
            
            /*
             * Billing Details
             */

            //Wait
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("collapse-payment-address")));
            
            //Enters Registration data
            driver.FindElement(By.Id("input-payment-firstname")).SendKeys(firstName);
            driver.FindElement(By.Id("input-payment-lastname")).SendKeys(lastName);
            driver.FindElement(By.Id("input-payment-email")).SendKeys(email);
            driver.FindElement(By.Id("input-payment-telephone")).SendKeys(telephone);
            driver.FindElement(By.Id("input-payment-address-1")).SendKeys(address1);
            driver.FindElement(By.Id("input-payment-city")).SendKeys(city);
            driver.FindElement(By.Id("input-payment-postcode")).SendKeys(postCode);
            //Selects Country
            new SelectElement(driver.FindElement(By.Id("input-payment-country"))).SelectByValue(country);
            //Loading regions
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector(".fa.fa-circle-o-notch.fa-spin")));
            //Selects Region
            new SelectElement(driver.FindElement(By.Id("input-payment-zone"))).SelectByValue(region);

            //Continue
            driver.FindElement(By.Id("button-guest")).Click();

            /*
             * Delivery Method
             */
            
            //Wait
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("collapse-shipping-method")));
            //Continue
            driver.FindElement(By.Id("button-shipping-method")).Click();

            /*
             * Payment Method
             */

            //Wait
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("collapse-payment-method")));            
            //Agree to the Terms & Conditions
            driver.FindElement(By.CssSelector("input[name='agree']")).Click();
            //Continue
            driver.FindElement(By.Id("button-payment-method")).Click();

            /*
             * Confirm Order
             */

            //Wait
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("collapse-checkout-confirm")));
            //Confirm Order
            IWebElement productTable = driver.FindElement(By.CssSelector(".table.table-bordered.table-hover"));
            string expected = productTable.FindElement(By.XPath("//tbody/tr[last()]/td[1]/a")).Text;

            //Verifies the product
            StringAssert.Contains(expected, productName);
            //Continue
            driver.FindElement(By.Id("button-confirm")).Click();

            /*
             * Success
             */
            //Wait
            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("checkout-success")));
            //Continue
            driver.FindElement(By.CssSelector("#content a.btn.btn-primary")).Click();

            /*
            * End
            */            
            if (!driver.Url.EndsWith("/home"))
            {
                throw new Exception("This is not Home page");
            }
        }
    }
}
