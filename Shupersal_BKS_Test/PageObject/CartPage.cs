using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Shupersal_BKS_Test.Helper;

namespace Shupersal_BKS_Test.PageObject
{
    public class CartPage : BasePage
    {

        string _cartPanel_class = "innerCart";
        //string _cartPanel = "class=innerCart";

        string _deliveryCost_xpath = "//header[@class='defaultDeliveryCosts']//span[@class='infoSubText']";
        //string _deliveryCost = "xpath=//header[@class='defaultDeliveryCosts']//span[@class='infoSubText']";
        string _productsInCart_xpath = "//div[contains(@class,'miglog-cart-summary-prod-wrp')][contains(@class,'miglog-cart-prod-wrp')]";
        //string _productsInCart = "xpath=//div[contains(@class,'miglog-cart-summary-prod-wrp')][contains(@class,'miglog-cart-prod-wrp')]";
        string _productTotlaPrice_xpath = "//p[contains(@class,'miglog-prod-totalPrize')]";
        string _totalPrice_xpath = "//div[@class='sideBlock']/div[@class='price']";
        //string _totalPrice = "xpath=//div[@class='sideBlock']/div[@class='price']";
        string _deleteProductsFromCart_xpath = "//div[contains(@class,'deleteCartContainer')]/a";
        string _deleteProductsFromCartConfirm_xpath = "//div[contains(@class,'miglog-cart-delete-popup-btngroup')]/button[@data-miglog-role='cart-remover']";
        //string _deleteProductsFromCartConfirm = "xpath=//div[contains(@class,'miglog-cart-delete-popup-btngroup')]/button[@data-miglog-role='cart-remover']";



        public CartPage(IWebDriver driver) : base(driver)
        {
        }

        public override bool IsAtPage()
        {
            webdriver.WaitForElementVisible(By.ClassName(_cartPanel_class));
            return webdriver.FindElement(By.ClassName(_cartPanel_class)).Displayed;
        }

        public void ClearCart()
        {
            IWebElement element = null;
            if (webdriver.TryFindElement(By.XPath(_deleteProductsFromCart_xpath),out element))
            {
                if (element.Displayed)
                {
                    webdriver.FindElement(By.XPath(_deleteProductsFromCart_xpath)).Click();
                    webdriver.WaitForElementVisible(By.XPath(_deleteProductsFromCartConfirm_xpath));

                    webdriver.FindElement(By.XPath(_deleteProductsFromCartConfirm_xpath)).Click();
                }
            }
            
        }

        public double GetDeliveryCost()
        {
            webdriver.WaitForElementVisible(By.XPath(_deliveryCost_xpath));
            return Convert.ToDouble(webdriver.FindElement(By.XPath(_deliveryCost_xpath)).Text.Split('\r').FirstOrDefault());
        }

        public double GetAllProbuctsCost()
        {
            
            double SummaryPrise = 0;
            webdriver.WaitForElementVisible(By.XPath(_productsInCart_xpath));
            var ProductsInCart = webdriver.FindElements(By.XPath(_productsInCart_xpath));
            foreach( var product in ProductsInCart)
            {
                SummaryPrise = SummaryPrise + Convert.ToDouble(product.FindElement(By.XPath(_productTotlaPrice_xpath)).Text.Split('\r').FirstOrDefault());
            }

            return SummaryPrise;
        }

        public double GetTotalCost()
        {
            webdriver.WaitForElementVisible(By.XPath(_totalPrice_xpath));
            return Convert.ToDouble(webdriver.FindElement(By.XPath(_totalPrice_xpath)).Text.Split('\n').LastOrDefault());
        }


    }
}
