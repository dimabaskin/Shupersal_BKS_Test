using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Globalization;
using log4net;
using SeleniumExtras.WaitHelpers;

namespace Shupersal_BKS_Test.Helper
{
    
    public static class WebDriverHelper
    {
        const int DEFULT_WAIT_SECOUNDS = 18;

        public static void WaitForElementInVisible(this IWebDriver webdriver , By by, int timeoutInSec = DEFULT_WAIT_SECOUNDS)
        {
            WebDriverWait wait = new WebDriverWait(webdriver, new TimeSpan(0, 0, timeoutInSec));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(by));
            
        }

        public static void WaitForElementVisible(this IWebDriver webdriver, By by, int timeoutInSec = DEFULT_WAIT_SECOUNDS)
        {
            WebDriverWait wait = new WebDriverWait(webdriver, new TimeSpan(0, 0, timeoutInSec));
            wait.PollingInterval = TimeSpan.FromSeconds(2);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            
        }

        public static bool TryFindElement(this IWebDriver webdriver, By by, out IWebElement element)
        {
            try
            {
                element = webdriver.FindElement(by);
                
            }
            catch (NoSuchElementException ex)
            {
                element = null;
                return false;
            }
            return true;
        }

        

    }
}
