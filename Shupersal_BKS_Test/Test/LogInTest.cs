using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.Extensions;
using log4net;
using Shupersal_BKS_Test.PageObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shupersal_BKS_Test.Helper;

namespace Shupersal_BKS_Test.Test
{
    [TestClass]
    public class LogInTest : BaseTest
    {
        ILog logger;
        

        public LogInTest()
        {
            logger = LogManager.GetLogger("testLogger");
        }

        [TestMethod]
        [TestCategory("LogIn")]
        public void LogIn()
        {
            RunTest(() =>
            {
                logger.Info(new { test = GeneralFunctions.GetCurrentMethodName(), state = TestStatusMessages.TEST_STARTED });

                homePage.OpenLigin();
                Assert.IsTrue(logInPage.IsAtPage(), "LogIn Page not Displayed");
                logInPage.EnterUserCredentials(GlobalVariables.UserLogInName, GlobalVariables.Password).SubmitLogin();
                Assert.IsTrue(homePage.IsLogedIn(GlobalVariables.UserName),"Not Loged In or Wrong User Name");

                logger.Info(new { test = GeneralFunctions.GetCurrentMethodName(), state = TestStatusMessages.TEST_PASSED });
            });
        }

       

    }
}
