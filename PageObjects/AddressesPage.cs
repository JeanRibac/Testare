using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.PageObjects
{
    class AddressesPage
    {
        private IWebDriver driver;
        
        public AddressesPage(IWebDriver browser)
        {
            driver = browser;
        }

        private IWebElement BtnNewAddress => driver.FindElement(By.CssSelector("[data-test='create']"));

        public AddAddressPage NavigateToAddAddressesPage()
        {
            BtnNewAddress.Click();
            return new AddAddressPage(driver);
        }
    }
}
