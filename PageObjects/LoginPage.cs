using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.PageObjects
{
    class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver browser)
        {
            driver = browser;
        }
        private IWebElement BtnSignIn()
        {
            return driver.FindElement(By.Id("sign-in"));
        }
        private IWebElement TxtUsername()
        {
            return driver.FindElement(By.Id("session_email"));
        }

        private IWebElement TxtPassword()
        {
            return driver.FindElement(By.Id("session_password"));
        }

        private IWebElement BtnLoginClick()
        {
            return driver.FindElement(By.Name("commit"));
        }

        public void NavigateToLoginPage()
        {
            BtnSignIn().Click();
        }

        public void LoginApplication(string username, string password)
        {
            TxtUsername().SendKeys(username);
            TxtPassword().SendKeys(password);
            BtnLoginClick().Click();
        }
    }
}
