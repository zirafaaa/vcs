using System;
using autotests.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace autotests.Test
{
    public class DropdownTest
    {
        private static DropdownPage page;

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            IWebDriver chrome = new ChromeDriver();
            page = new DropdownPage(chrome);
            chrome.Manage().Window.Maximize();
            chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            page.CloseBrowser();
        }

        [TestCase("Friday", TestName = "Test dropdown with Friday value")]
        [TestCase("Tuesday", TestName = "Test dropdown with Tuesday value")]
        public static void TestDropdown(string dayOfWeek)
        {
            page.NavigateToPage();
            page.SelectFromDropdownByVisibleText(dayOfWeek);
            page.VerifyResultBySelectedOption();
        }
    }
}