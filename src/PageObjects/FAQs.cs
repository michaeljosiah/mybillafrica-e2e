using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.DevTools.V106.Browser;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.PageObjects
{
    public class FAQs
    {

        private IWebDriver _browser;

        public FAQs(IWebDriver driver)
        {
            this._browser = driver;
        }

        public IWebElement heading1 => _browser.FindElement(By.Id("login-button"));
        public IWebElement Emailinput => _browser.FindElement(By.Id("email-login"));       

        public void NavigateTo()
        {
            _browser.Navigate().GoToUrl("https://delightful-sand-072182f03-test.westeurope.2.azurestaticapps.net/guest-access");
            //browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);            
            //Thread.Sleep(3000);
        }

        public void EnterTheGuestPass(string strCode)
        {
            var wait = new WebDriverWait(_browser, TimeSpan.FromSeconds(5));
            //wait.Until(e => e.FindElement(Emailinput.)); // explicit wait for element to be found before running test. Refer to cheatsheet

            //var FAQsElements = browser.FindElements(By.ClassName("")); // loop through FAQ elements for test
            Emailinput.SendKeys(strCode);
        }

        public bool IsLoggedInAsGuest()
        {
            if (_browser == null)
                return false;

            if(_browser.Manage().Cookies.GetCookieNamed("GuestPassCode")?.Value == "QAGUEST")            
            {
                return true;
            }

            return false;
        }

        public void LogInAsGuest(string redirect)
        {
            if(!IsLoggedInAsGuest())
            {
                NavigateTo();
                EnterTheGuestPass("QAGUEST");

                if (!string.IsNullOrEmpty(redirect))
                {
                    var wait = new WebDriverWait(_browser, TimeSpan.FromSeconds(5));
                    //wait.
                    _browser.Navigate().GoToUrl(redirect);
                }
            }
        }
    }
}
