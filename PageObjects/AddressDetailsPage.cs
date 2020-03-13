using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.PageObjects
{
    class AddressDetailsPage
    {
        private IWebDriver driver;

        public AddressDetailsPage(IWebDriver browser)
        {
            driver = browser;
        }                   
        public IWebElement lblSuccess => driver.FindElement(By.CssSelector("[data-test='notice']"));

    }
}
