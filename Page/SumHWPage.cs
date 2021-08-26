
using autotests.Page;
using NUnit.Framework;
using OpenQA.Selenium;

namespace PageObject.Page
{
    public class SumHWPage : BasePage
    {
        private const string AddressUrl = "http://www.seleniumeasy.com/test/basic-first-form-demo.html";        

        private IWebElement firstInputField => Driver.FindElement(By.Id("sum1"));
        private IWebElement secondInputField => Driver.FindElement(By.Id("sum2"));
        private IWebElement getTotalButton => Driver.FindElement(By.CssSelector("#gettotal > button"));
        private IWebElement resultFromPage => Driver.FindElement(By.Id("displayvalue"));
        public SumHWPage(IWebDriver webdriver) : base(webdriver) { }

        public void EnterFirstInput (string firstInput)
        {
            firstInputField.Clear();
            firstInputField.SendKeys(firstInput);
        }
        public void EnterSecondInput(string sencondInput)
        {
            secondInputField.Clear();
            secondInputField.SendKeys(sencondInput);
        }
        public void ClickGetTotal()
        {
            getTotalButton.Click();
        }
        public void VerifyResult(string result)
        {
            Assert.IsTrue(resultFromPage.Text.Contains(result), "Result is wrong");
        }
    }
}
