using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace OpenCart_AddressBookTest
{
    [TestFixture]
    public class UnitTest1
    {
        const string TEST_SITE_URL = "http://atqc-shop.epizy.com";
        const string PAGE_NAME = "Account";
        const string EMAIL = "zinkoexp@gmail.com";
        const string PASSWORD = "viktor11";

        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(TEST_SITE_URL);

            //Login to the site
            driver.FindElement(By.CssSelector("#top-links a.dropdown-toggle")).Click();//My Acount link
            //driver.FindElement(By.CssSelector("#top-links a[href$='/account']"));
            driver.FindElement(By.CssSelector("#top-links a[href$='/login']")).Click();//Login link
            driver.FindElement(By.Id("input-email")).Clear();
            driver.FindElement(By.Id("input-email")).SendKeys(EMAIL);//Type Login
            driver.FindElement(By.Id("input-password")).Clear();
            driver.FindElement(By.Id("input-password")).SendKeys(PASSWORD);//Type Password
            driver.FindElement(By.CssSelector("form input[type ='submit']")).Click();//Login button

            //Verify that opened Account page
            driver.FindElement(By.CssSelector(".breadcrumb a[href$='/account']"));
        }

        [TearDown]
        public void TearDown()
        {
            //driver.Quit();
        }

        [Test]
        [TestCase("Roman", "Zinko", "Grinchenko, 7", "Lviv", "220"/*Ukraine*/, "3493"/*L'vivs'ka Oblast'*/,
                    "Roman Zinko\r\nGrinchenko, 7\r\nLviv\r\nL'vivs'ka Oblast'\r\nUkraine")]
        public void CreateNewAddressTest(string firstName, string lastName, string address1,
                                            string city, string country, string region, string expected)
        {
            //Arrange   

            //Click on "Address Book" link
            driver.FindElement(By.CssSelector("#column-right a[href$='/address']")).Click();

            //Verify that "Address Book" page is opened 
            driver.FindElement(By.CssSelector(".breadcrumb a[href$='/address']"));

            //New Address button
            driver.FindElement(By.CssSelector("#content .buttons .pull-right>a")).Click();

            //Verify that "New Address" page is opened            
            driver.FindElement(By.CssSelector(".breadcrumb a[href*='/address/add']"));

            //Fill all required fields with data
            driver.FindElement(By.Id("input-firstname")).SendKeys(firstName);
            driver.FindElement(By.Id("input-lastname")).SendKeys(lastName);
            driver.FindElement(By.Id("input-address-1")).SendKeys(address1);
            driver.FindElement(By.Id("input-city")).SendKeys(city);
            //Select Country
            new SelectElement(driver.FindElement(By.Id("input-country"))).SelectByValue(country);
            //Loading regions
            IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(
                By.CssSelector(".fa.fa-circle-o-notch.fa-spin")));
            //Select Region
            new SelectElement(driver.FindElement(By.Id("input-zone"))).SelectByValue(region);

            //Click on "Continue" button
            driver.FindElement(By.CssSelector("form input[type ='submit']")).Click();

            //Verify that Address Book page is opened 
            driver.FindElement(By.CssSelector(".breadcrumb a[href$='/address']"));

            //Act
            //Get text from Address table
            IWebElement productTable = driver.FindElement(
                                            By.CssSelector(".table.table-bordered.table-hover"));
            string actual = productTable.FindElement(
                               By.XPath("//tbody/tr[last()]/td[contains(@class, 'text-left')]")).Text;

            //Assert
            Assert.AreEqual(expected, actual);//Verify that correct text displayed in the table
        }

        [Test]
        [TestCase("Khreshchatyk, 1", "Kyiv", "3490"/*Kyiv*/)]
        public void EditAddressTest(string address, string city, string region)
        {
            //Arrange 

            //Click on "Address Book" link
            driver.FindElement(By.CssSelector("#column-right a[href$='/address']")).Click();

            //Verify that Address Book page is opened 
            driver.FindElement(By.CssSelector(".breadcrumb a[href$='/address']"));

            //Find address table
            IWebElement addressTable = driver.FindElement(
                                            By.CssSelector(".table.table-bordered.table-hover"));
            //Find first address it the table
            IWebElement firstAddressInTable = addressTable.FindElement(By.XPath("//tbody/tr[1]"));
            //Save an old address, for expected result
            string expected = firstAddressInTable.FindElement(By.ClassName("text-left")).Text;

            //"Edit Address" button in first table row           

            firstAddressInTable.FindElement(By.ClassName("btn-info")).Click();

            //Verify that "Edit Address" page is opened            
            driver.FindElement(By.CssSelector(".breadcrumb a[href*='/address/edit']"));

            //Set new data
            //Verify that the name not same as new name
            if (address.Equals(driver.FindElement(By.Id("input-address-1")).Text))
            {
                driver.FindElement(By.Id("input-address-1")).Clear();
                //Add "test" word to the address1 
                driver.FindElement(By.Id("input-address-1")).SendKeys(address + "(test)");
            }
            else
            {
                driver.FindElement(By.Id("input-address-1")).Clear();
                driver.FindElement(By.Id("input-address-1")).SendKeys(address);
            }

            //Verify that the address1 not same as new address1
            if (city.Equals(driver.FindElement(By.Id("input-city")).Text))
            {
                driver.FindElement(By.Id("input-city")).Clear();
                //Add "test" word to the city
                driver.FindElement(By.Id("input-city")).SendKeys(city + "(test)");
            }
            else
            {
                driver.FindElement(By.Id("input-city")).Clear();
                driver.FindElement(By.Id("input-city")).SendKeys(city);
            }

            //Loading regions
            IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            //Wait, while loading indicator is visible
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(
                            By.CssSelector(".fa.fa-circle-o-notch.fa-spin")));
            //Select Region
            SelectElement selectRegion = new SelectElement(driver.FindElement(By.Id("input-zone")));

            //Verify that the region not same as new region
            if (region.Contains(selectRegion.SelectedOption.GetAttribute("value")))
            {
                selectRegion.SelectByIndex(1);
                if (region.Equals(selectRegion.SelectedOption))
                {
                    selectRegion.SelectByIndex(2);
                }
            }
            else
            {
                selectRegion.SelectByValue(region);
            }

            //Click on "Continue" button
            driver.FindElement(By.CssSelector("form input[type ='submit']")).Click();

            //Verify that Address Book page is opened 
            driver.FindElement(By.CssSelector(".breadcrumb a[href$='/address']"));

            //Act
            //Get text from Address table            
            string actual = driver.FindElement(
                                By.XPath("//tbody/tr[1]/td[contains(@class, 'text-left')]")).Text;

            //Assert
            Assert.AreNotEqual(expected, actual);//Verify that new text displayed in the table
        }

        [Test]
        [TestCase("Roman", "Zinko", "Grinchenko, 7", "Lviv", "220"/*Ukraine*/, "3493"/*L'vivs'ka Oblast'*/)]
        public void DeleteAddressTest(string firstName, string lastName, string address1,
                                            string city, string country, string region)
        {
            /***///CreateNewAddressTest(firstName, lastName, address1, city, country, region, "ffff");

            //Arrange   

            //Click on "Address Book" link
            driver.FindElement(By.CssSelector("#column-right a[href$='/address']")).Click();
            //Verify that "Address Book" page is opened 
            driver.FindElement(By.CssSelector(".breadcrumb a[href$='/address']"));

            //Add new Address
            //Save primary "Address Book" table length
            int expected = driver.FindElements(By.CssSelector("#content tbody")).Count;

            driver.FindElement(By.CssSelector("#content .buttons .pull-right>a")).Click();
            //Verify that "New Address" page is opened            
            driver.FindElement(By.CssSelector(".breadcrumb a[href*='/address/add']"));
            //Fill all required fields with data
            driver.FindElement(By.Id("input-firstname")).SendKeys(firstName);
            driver.FindElement(By.Id("input-lastname")).SendKeys(lastName);
            driver.FindElement(By.Id("input-address-1")).SendKeys(address1);
            driver.FindElement(By.Id("input-city")).SendKeys(city);
            //Select Country
            new SelectElement(driver.FindElement(By.Id("input-country"))).SelectByValue(country);
            //Loading regions
            IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(
                By.CssSelector(".fa.fa-circle-o-notch.fa-spin")));
            //Select Region
            new SelectElement(driver.FindElement(By.Id("input-zone"))).SelectByValue(region);
            //Click on "Continue" button
            driver.FindElement(By.CssSelector("form input[type ='submit']")).Click();
            //Verify that Address Book page is opened 
            driver.FindElement(By.CssSelector(".breadcrumb a[href$='/address']"));

            int tbodyRowsEnd = driver.FindElements(By.CssSelector("#content tbody")).Count;

            if (tbodyRowsEnd > expected)
            {
                driver.FindElement(By.XPath("//tbody/tr[last()]]")).FindElement(By.ClassName("#btn-danger")).Click();
            }
            else
            {
                throw new Exception();
            }

            //Act
            //Save "Address Book" table length, after deleting added address
            int actual = driver.FindElements(By.CssSelector("#content tbody")).Count;

            //Assert
            Assert.AreEqual(expected, actual);//Verify that the address deleted from the table

        }
    }
}
