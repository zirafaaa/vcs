using System;
using System.Collections.Generic;
using System.Linq;
using System;
using autotests.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace autotests.Test
{
    public class VartuTechnikaTest
    {
        private static VartuTechnikaPage page;

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            IWebDriver chrome = new ChromeDriver();
            page = new VartuTechnikaPage(chrome);

            chrome.Manage().Window.Maximize();
            chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            chrome.Url = "http://vartutechnika.lt/";
            page.AcceptCookies();
        }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            page.CloseBrowser();
        }

        [TestCase("2000", "2000", true, false, "665.98€", TestName = "2000 x 2000 + Vartų automatika = 665.98€")]
        [TestCase("4000", "2000", true, true, "1006.43€", TestName = "4000 x 2000 + Vartų automatika + Vartų montavimo darbai = 1006.43€")]
        [TestCase("4000", "2000", false, false, "692.35€", TestName = "4000 x 2000 = 692.35€")]
        [TestCase("5000", "2000", false, true, "989.21€", TestName = "5000 x 2000 + Vartų montavimo darbai = 989.21€")]
        public static void TestVartuTechnika(string width, string height, bool automatika, bool works, string result)
        {
            page.InsertWidth(width);
            page.InsertHeight(height);
            page.CheckAutomatikaCheckbox(automatika);
            page.CheckWorksCheckbox(works);
            page.ClickCalculateButton();
            page.VerifyResult(result);
        }
    }
}