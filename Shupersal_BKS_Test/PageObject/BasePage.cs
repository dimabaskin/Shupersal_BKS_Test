using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace Shupersal_BKS_Test.PageObject
{
    public abstract class BasePage
    {
        internal IWebDriver webdriver;
        internal WebDriverWait wait;

        public BasePage(IWebDriver driver)
        {
            webdriver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public abstract bool IsAtPage();
    }
}
