using System;
using System.IO;
using System.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.Extensions;
using log4net;
using Shupersal_BKS_Test.PageObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Shupersal_BKS_Test.Test
{

    [TestClass]
    public class BaseTest
    {

        internal IWebDriver driver;
        private readonly string _driverType;
        internal WebDriverWait wait;
        ILog logger;

        public BaseTest()
        {
            _driverType = ConfigurationManager.AppSettings["driver"];

            logger = LogManager.GetLogger("testLogger");
        }

        private string SITE_URL = ConfigurationManager.AppSettings["SiteURL"];

        public HomePage homePage;
        public LogInPage logInPage;
        public SearchPage searchPage;
        public CartPage cartPage;

        [TestInitialize]
        public void Init()
        {
            
            switch (_driverType)
            {
                case "chrome":
                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("--allow-running-insecure-content");
                    chromeOptions.AddArgument("--ignore-certificate-errors");
                    chromeOptions.AddArgument("start-maximized");
                    chromeOptions.AddArgument("no-sandbox");
                    ChromeDriverService service = ChromeDriverService.CreateDefaultService();
                    driver = new ChromeDriver(service, chromeOptions, TimeSpan.FromMinutes(3));
                    //driver = new ChromeDriver(Path.Combine(Environment.CurrentDirectory));
                    break;
                case "firefox":
                    driver = new FirefoxDriver();
                    driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                    break;
                case "IE":
                    driver = new InternetExplorerDriver();
                    break;
                default:
                    driver = new ChromeDriver();
                    break;
            }

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //var dir = Path.GetDirectoryName(typeof(BaseTest).Assembly.Location);
            var dir = Path.Combine(Environment.CurrentDirectory);
            Directory.SetCurrentDirectory(dir);
                        
            homePage = new HomePage(driver);
            logInPage = new LogInPage(driver);
            searchPage = new SearchPage(driver);
            cartPage = new CartPage(driver);

            logger.Info(new { text = "Site under test: ", URL = SITE_URL });
            driver.Navigate().GoToUrl(SITE_URL);

        }

        internal void RunTest(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {

                logger.Info(new { TestStatus = TestStatusMessages.TEST_FAILED, Reason = ex.ToString() });
                var filename = driver.TakeScreenshot();

                throw;
            }
        }





        [TestCleanup]
        public void Cleanup()
        {
            driver.Quit();
            driver = null;
        }
    }

}
