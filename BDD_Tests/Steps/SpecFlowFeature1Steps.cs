using System;
using System.IO;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace BDD_Tests.Steps
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        IWebDriver webdriver;

        [Given(@"I Open Google")]
        public void GivenIOpenGoogle()
        {
            var outputDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var relPath = @"..\..\Drivers";
            var fullPath = Path.GetFullPath(Path.Combine(outputDir, relPath));
            webdriver = new ChromeDriver(fullPath);
            webdriver.Navigate().GoToUrl("https://www.google.ie");
        }
        
        [Then(@"The page opens and I close test")]
        public void ThenThePageOpens()
        {
            Assert.That(webdriver.Title == "Google");
            webdriver.Quit();
        }
    }
}
