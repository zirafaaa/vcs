using System;
using autotests.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace autotests.Test
{
    public class CheckboxTest
    {
        private static CheckboxPage page;

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            IWebDriver chrome = new ChromeDriver();
            page = new CheckboxPage(chrome);
            chrome.Manage().Window.Maximize();
            chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            page.CloseBrowser();
        }

        [Test]
        public static void FirstCheckbox()
        {
            page.NavigateToPage();
            page.ClickCheckbox();
            page.VerifyResult();
        }

        [Test]
        public static void SecondCheckbox()
        {
            page.NavigateToPage();
            page.ClickCheckbox();
            page.VerifyResult();
        }
    }
}