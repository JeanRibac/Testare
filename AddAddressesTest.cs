using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using UnitTestProject1.PageObjects;

namespace UnitTestProject1
{
    [TestClass]
    public class AddAddressesTest
    {
        private OpenQA.Selenium.IWebDriver driver;
        private AddAddressPage addAddressPage;

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            var loginPage = new LoginPage(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://a.testaddressbook.com");
            loginPage.NavigateToLoginPage();
            Thread.Sleep(1000);

            loginPage.LoginApplication("jeanribac95@gmail.com", "Parola1234");
            var homePage = new HomePage(driver);
            Thread.Sleep(1000);

            var addressesPage = homePage.NavigateToAddressesPage();
            Thread.Sleep(1000);

            addAddressPage = addressesPage.NavigateToAddAddressesPage();
            Thread.Sleep(1000);

        }
        [TestMethod]
        public void Go_To_AddAddressPage()
        {
            addAddressPage.AddAddress();
            var addressDetails = new AddressDetailsPage(driver);
            var message = "Address was successfully created.";
            Assert.AreEqual(message, addressDetails.lblSuccess.Text);
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
