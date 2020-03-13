using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UnitTestProject1.PageObjects
{
    class AddAddressPage
    {

        private IWebDriver driver;

        public AddAddressPage(IWebDriver browser)
        {
            driver = browser;
        }

        private IWebElement TxtFirstName => driver.FindElement(By.Id("address_first_name"));
        private IWebElement TxtLastName => driver.FindElement(By.Id("address_last_name"));
        private IWebElement TxtAddress1 => driver.FindElement(By.Id("address_street_address"));
        private IWebElement TxtCity => driver.FindElement(By.Id("address_city"));
        private IWebElement DdlState => driver.FindElement(By.Id("address_state"));
        private IWebElement TxtZipCode => driver.FindElement(By.Id("address_zip_code"));
        private IList<IWebElement> LstCountry => driver.FindElements(By.CssSelector("input[type=radio]"));
        //private IWebElement TxtBirthday => driver.FindElement(By.Id("address_birthday"));
        private IWebElement Clcolor => driver.FindElement(By.Id("address_color"));
        private IWebElement BtnSave => driver.FindElement(By.Name("commit"));
        public void AddAddress()
        {
            TxtFirstName.SendKeys("test");
            TxtLastName.SendKeys("test");
            TxtAddress1.SendKeys("Test");
            TxtCity.SendKeys("test");
            var selectState = new SelectElement(DdlState);
            selectState.SelectByText("Alabama");
            TxtZipCode.SendKeys("123456");
            LstCountry[1].Click();

            var js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].setAttribute('value', arguments[1])", Clcolor, "#FF0000");
            BtnSave.Click();

            Thread.Sleep(2000);
        }
    }
}
