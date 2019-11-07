using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using NUnit.Framework;
using System.Threading;


namespace CSharpSeleniumWithGit
{
    [TestFixture]
    public class GoogleTest
    {
        public IWebDriver driver;
       

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            driver = new FirefoxDriver();
            driver.Url = "https://www.google.com/";
            //driver.Manage().Window.Maximize();
        }

        [Test]
        public void YahooSearchBoxTest()
        {
            driver = new FirefoxDriver();
            driver.Url = "https://www.yahoo.com/";
            driver.Manage().Window.Maximize();
        }



        [Test]
        public void GoogleSearchBoxTest()
        {
            IWebElement SearchBox = driver.FindElement(By.Name("q"));
            
            SearchBox.SendKeys("Selenium WebDriver");
            SearchBox.SendKeys(Keys.Enter);

            Thread.Sleep(1000);
            
        }


        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Close();
            driver.Quit();
            
        }

    }
}
