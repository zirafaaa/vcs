using System;
using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using PageObject.Page;

namespace PageObject.Test
{
    public class W3MultipleTest 
    {
        private static W3MultiplePage page;

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            IWebDriver chrome = new ChromeDriver();
            page = new W3MultiplePage(chrome);
            chrome.Url = "https://www.w3schools.com/tags/tryit.asp?filename=tryhtml_select_multiple";
            chrome.Manage().Window.Maximize();
            WebDriverWait wait = new WebDriverWait(chrome, TimeSpan.FromSeconds(10));
           
        }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            page.CloseBrowser();
        }

        [TestCase("Volvo", "Opel", TestName = "Select Volvo and Opel")]
        [TestCase("Volvo", "Saab", "Opel", "Audi", TestName = "Select Volvo, Saab, Opel and Audi")]
        [TestCase("Saab", "Audi", TestName = "Select Saab and Audi")]
        public static void TestMultipleDropdown(params string[] cars)
        {
            page.NavigateToPage();
            page.AcceptCookies();
            page.SelectFromDropDownByValue(cars.ToList());
            page.ClickSubmitButton();
            page.VerifyResult(cars.ToList());
            page.RerunPageScript();

        }
    }
}
