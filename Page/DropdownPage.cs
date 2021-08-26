using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace autotests.Page
{
    public class DropdownPage : BasePage
    {
        private const string AddressUrl = "https://www.seleniumeasy.com/test/basic-select-dropdown-demo.html";
        private SelectElement dropdown => new SelectElement(Driver.FindElement(By.Id("select-demo")));
        private IWebElement resultElement => Driver.FindElement(By.CssSelector(".selected-value"));
        public DropdownPage(IWebDriver webdriver) : base(webdriver) { }

        public void NavigateToPage()
        {
            if (Driver.Url != AddressUrl)
            {
                Driver.Url = AddressUrl;
            }
        }

        public void VerifyResult(string result)
        {
            Assert.AreEqual("Day selected :- " + result, resultElement.Text, "Selected day is not correct");
        }

        public void VerifyResultBySelectedOption()
        { 
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
                wait.Until(ExpectedConditions.)
            Assert.IsTrue(resultElement.Text.Contains(dropdown.SelectedOption.Text), "Selected day is not correct");
        }

        public void SelectFirstOptionFromDropdown()
        {
            dropdown.SelectByIndex(0);
        }

        public void SelectFromDropdownByIndex(int index)
        {
            dropdown.SelectByIndex(index);
        }

        public void SelectFromDropdownByVisibleText(string visibleText)
        {
            dropdown.SelectByText(visibleText);
        }

        public void SelectMondayFromDropdown()
        {
            dropdown.SelectByText("Monday");
        }

        public void SelectFromDropdownByValue(string value)
        {
            dropdown.SelectByValue(value);
        }
    }
}