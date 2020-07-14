using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;
using System.Configuration;
using OpenQA.Selenium.Support.PageObjects;



namespace Shupersal_BKS_Test.PageObject
{
    public class HomePage : BasePage
    {
        string _logInLink_ID = "loginDropdownContainer";
        string _loginInfoContainer_Class = "loginInfoContainer";
        string _searchInput_ID = "js-site-search-input";
        string _searchSubmit_Xpath = "//button[@type='submit'][contains(@class,'btnSubmit')][contains(@class,'js_search_button')]";


        //[FindsBy(How = How.Id, Using = @"loginDropdownContainer")]
        //private IWebElement _loginDropdownContainer { get; set; }

        public HomePage(IWebDriver driver) : base(driver)
        {
            
        }

        public override bool IsAtPage()
        {
            throw new NotImplementedException();
        }

        internal void OpenLigin()
        {
            webdriver.FindElement(By.Id(_logInLink_ID)).Click();
            
        }

        public bool IsLogedIn(string UserName)
        {
            var LogInInfoContainerElement = webdriver.FindElement(By.ClassName(_loginInfoContainer_Class));
            bool isShalom = !String.IsNullOrEmpty(LogInInfoContainerElement.Text) && (LogInInfoContainerElement.Text.IndexOf("שלום", StringComparison.InvariantCultureIgnoreCase) >= 0);
            bool isLogout = (LogInInfoContainerElement.Text.IndexOf("התנתקות", StringComparison.InvariantCultureIgnoreCase) >= 0);
            bool isUserName = (LogInInfoContainerElement.Text.IndexOf(UserName, StringComparison.InvariantCultureIgnoreCase) >= 0);
            return isShalom && isUserName;
        }

        public void SearchForProduct(string ProductName)
        {
            webdriver.FindElement(By.Id(_searchInput_ID)).SendKeys(ProductName);
            webdriver.FindElement(By.XPath(_searchSubmit_Xpath)).Click();

        }
    }
}
