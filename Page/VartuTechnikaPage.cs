using NUnit.Framework;
using OpenQA.Selenium;

namespace autotests.Page
{
    public class VartuTechnikaPage : BasePage
    {
        private IWebElement widthInputField => Driver.FindElement(By.Id("doors_width"));
        private IWebElement heightInputField => Driver.FindElement(By.Id("doors_height"));

        private IWebElement autoCheckbox => Driver.FindElement(By.Id("automatika"));
        private IWebElement workCheckbox => Driver.FindElement(By.Id("darbai"));

        private IWebElement calculateButton => Driver.FindElement(By.Id("calc_submit"));

        private IWebElement resultElement => Driver.FindElement(By.CssSelector("#calc_result > div > strong"));

        private IWebElement acceptCookiesButon => Driver.FindElement(By.Id("cookiescript_accept"));

        public VartuTechnikaPage(IWebDriver webdriver) : base(webdriver) { }

        public void InsertWidth(string width)
        {
            widthInputField.Clear();
            widthInputField.SendKeys(width);
        }

        public void AcceptCookies()
        {
            acceptCookiesButon.Click();
        }

        public void InsertHeight(string height)
        {
            heightInputField.Clear();
            heightInputField.SendKeys(height);
        }

        //public void Insert2000ToHeight()
        //{
        //    heightInputField.Clear();
        //    heightInputField.SendKeys("2000");
        //}

        public void CheckAutomatikaCheckbox(bool shouldBeChecked)
        {
            if (autoCheckbox.Selected != shouldBeChecked)
            {
                autoCheckbox.Click();
            }
        }

        public void CheckWorksCheckbox(bool shouldBeChecked)
        {
            if (workCheckbox.Selected != shouldBeChecked)
            {
                workCheckbox.Click();
            }
        }

        public void ClickCalculateButton()
        {
            calculateButton.Click();
        }

        public void VerifyResult(string result)
        {
            Assert.IsTrue(resultElement.Text.Contains(result), "Result is wrong");
        }

    }
}
