using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SpecFlowProject1.PageObjects;
using System;
using System.Diagnostics.Metrics;
using System.Numerics;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class FAQsStepDefinitions
    {
        private IWebDriver driver;
        private GuestLogin AccessGuestpage;
        private Dictionary<string, string> 
            expectedAccordionFAQs, actualAccordionFAQs;

        public IWebElement Loginbutton => driver.FindElement(By.Id("login-button"));

        public FAQsStepDefinitions(IWebDriver driver)
        {
            AccessGuestpage = new GuestLogin(driver);
            InitAccordionDic();
        }

        private void InitAccordionDic() => expectedAccordionFAQs = new Dictionary<string, string>
            {
                {
                    "How do I get started?",
                    "Simply download our Android app from the Google play store and register. It is quick and easy."
                },
                {
                    "Is my data secure with My Bill Africa?",
                    "Security is our highest priority and we use the latest standards to protect your data."
                },
                {
                    "What countries can I pay my bill in?",
                    @"  <p>You can currently pay bills in the following African countries:</p>\
                        <ul>
                            <li>Ghana</li>
                            <li>Nigeria</li>
                        </ul>
                    <p> This list is constantly growing so please check back or contact support to know when your country will be included.</p>"
                },
                {
                    "What type of bills can I pay?",
                    @"  <p>You can pay most things such as:</p>
                        <ul><li>Energy</li>
                            <li>Internet</li>
                            <li>Phone bills</li>
                            <li>TV</li>
                            <li>and much more…</li>
                        </ul>"
                },
                {
                    "How quickly will my bill be settled with the provider?",
                    @"  <p>In most cases we settle the bills with your provider instantly and in some cases within 24hrs. You will be notified by email the moment your bill has been paid to the provider.</p>"
                },
                {
                    "I can't find my bill provider on your list?",
                    @"  <p>We are adding providers to our system on a monthly basis. If you cant find a particular bill provider, then simply drop us an email to support@mybillafrica.com and we will let you know when they are coming onboard.</p>"
                },
                {
                    "Can I send money using this service?",
                    @"  <p>No, we are focused on bill payment and management. Enabling money transfer is not in our immediate plans.</p>"
                }
            };

        [Given(@"I can navigate to the FAQs Page")]
        public void GivenICanNavigateToTheFAQsPage()
        {            
            AccessGuestpage.NavigateTo();
            AccessGuestpage.EnterTheGuestPass("QAGUEST");
            AccessGuestpage.Loginbutton.Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.Url == "https://delightful-sand-072182f03-test.westeurope.2.azurestaticapps.net/");
            driver.Navigate().GoToUrl("https://delightful-sand-072182f03-test.westeurope.2.azurestaticapps.net/help");
            
            IWebElement element = wait.Until(Driver => Driver.FindElement(By.Id("heading1")));

            //TODO: Assertion Needed

        }

        [When(@"I click on each question button")]
        public void WhenIClickOnEachQuestionButton()
        {
            actualAccordionFAQs = new Dictionary<string, string>();
            IWebElement accordion = driver.FindElement(By.Id("faq"));
            var cards = accordion.FindElements(By.ClassName("card"));
            foreach (var card in cards)
            {
                //var cardheader = card.FindElement(By.ClassName("card-header"));
                //var faqButton = cardheader.FindElement(By.TagName("button"));

                var faqCardButton = card.FindElement(By.XPath("//*[@class='card-header']/h4/button"));
                var faqCardBody = card.FindElement(By.XPath("//*/div/div/p[text()]"));
                //*[@id="heading1"]/h4/button                

                if (!faqCardBody.Displayed)
                    faqCardButton.Click();                

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(driver => driver.FindElement(By.XPath("//*/div/div/p[text()]")).Displayed);

                //var cardbody = card.FindElement(By.ClassName("card-body"));

                actualAccordionFAQs.Add(faqCardButton.Text, faqCardBody.Text);

                //TODO: Assertions
            }
        }

        [Then(@"The appropriate text is revealed")]
        public void ThenTheAppropriateTextIsRevealed()
        {
            throw new PendingStepException();
        }
    }
}
