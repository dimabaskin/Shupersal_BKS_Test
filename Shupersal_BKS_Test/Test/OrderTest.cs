using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shupersal_BKS_Test.Helper;

namespace Shupersal_BKS_Test.Test
{
    [TestClass]
    public class OrderTest : BaseTest
    {
        ILog logger;

        public OrderTest()
        {
            logger = LogManager.GetLogger("testLogger");
        }

        [TestMethod]
        [TestCategory("OrderTest")]
        public void OrderCheapestMilk()
        {
            RunTest(() =>
            {
                logger.Info(new { test = GeneralFunctions.GetCurrentMethodName(), state = TestStatusMessages.TEST_STARTED });

                string ProductName = "חלב";

                logger.Info(new { text = "LogIn with User: " + GlobalVariables.UserName });
                homePage.OpenLigin();
                Assert.IsTrue(logInPage.IsAtPage(), "LogIn Page not Displayed");
                logInPage.EnterUserCredentials(GlobalVariables.UserLogInName, GlobalVariables.Password).SubmitLogin();
                Assert.IsTrue(homePage.IsLogedIn(GlobalVariables.UserName), "Not Loged In or Wrong User Name");

                logger.Info(new { text = "Search For Product: " + ProductName });
                homePage.SearchForProduct(ProductName);

                Assert.IsTrue(searchPage.IsAtPage(), "Serach Results not Displayed or not Found");
                cartPage.ClearCart();

                searchPage.OrderByPriceASC();
                searchPage.WaitForLoaderInVisible();
                logger.Info(new { text = "Add chipest Product to cart. "  });
                searchPage.AddFirstProductFromListToCart();

                Assert.IsTrue(cartPage.IsAtPage(), "Cart Panel not Visible");
                double DeliveryPrice = cartPage.GetDeliveryCost();
                double AllProductsPrice = cartPage.GetAllProbuctsCost();
                double TotalPrice = cartPage.GetTotalCost();

                logger.Info(new { DeliveryPrice = DeliveryPrice.ToString() });
                logger.Info(new { AllProductsPrice = AllProductsPrice.ToString() });
                logger.Info(new { TotalPrice = "Delivery and AllProducts: " + (DeliveryPrice + AllProductsPrice).ToString()  });
                logger.Info(new { TotalPrice = TotalPrice.ToString() });

                Assert.IsTrue((DeliveryPrice + AllProductsPrice) == TotalPrice, "Total Price on Site do not compare to All Products and Delivery Total Price");
                cartPage.ClearCart();

                logger.Info(new { test = GeneralFunctions.GetCurrentMethodName(), state = TestStatusMessages.TEST_PASSED });
            });
        }
            

    }
}
