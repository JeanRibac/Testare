using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UnitTestProject1.PageObjects;

namespace UnitTestProject1
{
    [TestClass]
    public class LoginTest
    {
        private IWebDriver driver;
        private LoginPage loginPage;

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            loginPage = new LoginPage(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://a.testaddressbook.com");
            loginPage.NavigateToLoginPage();

            Thread.Sleep(1000);
        }
        [TestMethod]
        public void Login_CorrectEmail_CorrectPassword()
        {
            loginPage.LoginApplication("jeanribac95@gmail.com", "Parola1234");

            var expectedResult = "jeanribac95@gmail.com";
            var HomePage = new HomePage(driver);
            
            Assert.AreEqual(expectedResult, HomePage.UserEmailText);
        }
        [TestMethod]
        public void Login_IncorrectCorrectEmail_IncorrectCorrectPassword()
        {
            loginPage.LoginApplication("123asd@asd.com", "123asd");

            var expectedResult = "Bad email or password.";
            var actualResult = driver.FindElement(By.XPath("//div[starts-with(@class,'alert alert-notice')]")).Text;

            Assert.AreEqual(expectedResult, actualResult);
        }
        
        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
