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
    public class SearchPage : BasePage
    {
        string _searchResultsPanel_ID = "tabPane1";
        //string _searchResultsPanel = "id=tabPane1";
        string _sortOptionDropDownButton_Xpath = "//button[@data-id='sortOptions1']";
        //string _sortOptionDropDownButton = "xpath=//button[@data-id='sortOptions1']";
        string _sortOptionList_xpath = "//div[contains(@class,'js-sortingSelect')]//ul[contains(@class,'dropdown-menu')][@role='listbox']/li";
        //string _loader = "xpath=//div[@class='spinner']";
        string _loader_xpath = "//div[@class='spinner']";
        string _mainProductGrid_xpath = "//ul[@id='mainProductGrid']/li";
        //string _mainProductGrid = "xpath=//ul[@id='mainProductGrid']/li";
        string _addToCart_btn_xpath = "//button[contains(@class,'js-add-to-cart')]";
        string _updateCart_btn_xpath = "//button[contains(@class,'js-update-cart')]";
        


        public SearchPage(IWebDriver driver) : base(driver)
        {
        }

        public override bool IsAtPage()
        {
            webdriver.WaitForElementVisible(By.Id(_searchResultsPanel_ID));
            return webdriver.FindElement(By.Id(_searchResultsPanel_ID)).Displayed;
        }

        public void OrderByPriceASC()
        {
            webdriver.WaitForElementVisible(By.XPath(_sortOptionDropDownButton_Xpath));

            webdriver.FindElement(By.XPath(_sortOptionDropDownButton_Xpath)).Click();
            var SortOptionsList = webdriver.FindElements(By.XPath(_sortOptionList_xpath));
            //var OrderByPriseASC_Option = SortOptionsList.Where(x => x.GetAttribute("data-original-index") == "1");
            //OrderByPriseASC_Option.FirstOrDefault().Click();
            foreach ( var orderOprion in SortOptionsList)
            {
                if (orderOprion.GetAttribute("data-original-index") == "1")
                {
                    orderOprion.Click();
                    break;
                }
            }
        }

        
        public void WaitForLoaderInVisible()
        {
            webdriver.WaitForElementInVisible(By.XPath(_loader_xpath));
        }

        public void AddFirstProductFromListToCart()
        {
            webdriver.WaitForElementVisible(By.XPath(_mainProductGrid_xpath));
            var ProductsList = webdriver.FindElements(By.XPath(_mainProductGrid_xpath));
            if(ProductsList.FirstOrDefault().FindElement(By.XPath(_updateCart_btn_xpath)).Displayed)
            {
                //ProductsList.FirstOrDefault().FindElement(By.XPath(_updateCart_btn_xpath)).Click();
            }
            else
            {
                ProductsList.FirstOrDefault().FindElement(By.XPath(_addToCart_btn_xpath)).Click();
            }
            
        }
    }
}
