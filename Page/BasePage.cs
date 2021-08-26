
using OpenQA.Selenium;

namespace autotests.Page
{
    public class BasePage
    {
        protected IWebDriver Driver;
        public BasePage(IWebDriver webdriver)
        {
            Driver = webdriver;
        }

        public void CloseBrowser()
        {
            Driver.Quit();
        }

    }
}
