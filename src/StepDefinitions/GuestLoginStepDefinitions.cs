using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowProject1.PageObjects;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class GuestLoginStepDefinitions 
    {
        private GuestLogin AccessGuestpage;

        private IWebDriver _driver;

        public GuestLoginStepDefinitions(IWebDriver driver)
        {
            AccessGuestpage = new GuestLogin(driver);
        }



        [Given(@"I am on the mybillafrica guest access page")]
        public void GivenIAmOnTheMybillafricaGuestAccessPage()
        {
            //Driver.Navigate().GoToUrl("https://delightful-sand-072182f03-test.westeurope.2.azurestaticapps.net/guest-access");
            //Driver.Navigate().GoToUrl("https://delightful-sand-072182f03-test.westeurope.2.azurestaticapps.net/register?redirecturl=/");
            AccessGuestpage.NavigateTo();
        }

        [When(@"I enter my guest password")]
        public void WhenIEnterMyGuestPassword()
        {



            
            //var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            AccessGuestpage.EnterTheGuestPass("QAGUEST");
           // IWebElement element = wait.Until(Driver => Driver.FindElement(By.Id("email-login")));
            //IWebElement element = wait.Until(Driver => Driver.FindElement(By.Id("email")));

            //Driver.FindElement(By.Id("email-login")).SendKeys("QAGUEST");
        }

        [Then(@"I should be taken to the homepage")]
        public void ThenIShouldBeTakenToTheHomepage()
        {
            //var btnsubmit = Driver.FindElement(By.CssSelector("#app > div > div:nth-child(3) > div > div:nth-child(2) > div > form > div.py-4 > button"));
            //btnsubmit.Click();
            AccessGuestpage.Loginbutton.Click();
        }
    }
}
