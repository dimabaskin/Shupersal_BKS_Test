using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

using NUnit.Framework;

namespace Shupersal_BKS_Test.PageObject
{
    public class LogInPage : BasePage
    {
        //[FindsBy(How = How.Id, Using = @"loginDropdown")]
        //private IWebElement _loginDropdown { get; set; }
        string _loginDropdown_ID = "loginDropdown";
        string _inputUsername_ID = "j_username";
        string _inputPassword_ID = "j_password";
        string _loginSubmit_xpath = "//div[@class='bottomSide']/button[@type='submit'][contains(@class,'big')]";

        public LogInPage(IWebDriver driver) : base(driver)
        {
        }

        public override bool IsAtPage()
        {
            return webdriver.FindElement(By.Id(_loginDropdown_ID)).Displayed;
        }

        public LogInPage EnterUserCredentials(string User, string Password)
        {
            webdriver.FindElement(By.Id(_inputUsername_ID)).SendKeys(User);
            webdriver.FindElement(By.Id(_inputPassword_ID)).SendKeys(Password);
            return this;
        }
         public void SubmitLogin()
        {
            webdriver.FindElement(By.XPath(_loginSubmit_xpath)).Click();
        }


            
    }
}
