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
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;

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
            driver.Manage().Window.Maximize();
        }


        [Test]
        public void GoogleSearchBoxTest()
        {
            IWebElement SearchBox = driver.FindElement(By.Name("q"));
            var extent = new ExtentReports();
            ExtentHtmlReporter reporter = new ExtentHtmlReporter("report.html");
            
            extent.AttachReporter(reporter);
            var test = extent.CreateTest("MyFirstTest", "Sample description");
            test.Log(Status.Info, "This step shows usage of log(status, details)");
            test.Info("This step shows usage of info(details)");

            test.Fail("details",
                MediaEntityBuilder.CreateScreenCaptureFromPath("screenshot.png").Build());
            test.AddScreenCaptureFromPath("screenshot.png");
         
            SearchBox.SendKeys("Selenium WebDriver");
            SearchBox.SendKeys(Keys.Enter);

            Thread.Sleep(1000);
            extent.Flush();

        }


        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Close();
            driver.Quit();
            
        }

    }
}
