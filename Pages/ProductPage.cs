namespace ReqnrollProjectSauceDemo3.Pages
{
    public class ProductPage 
    {
        IWebDriver driver;
        public ProductPage(IWebDriver _driver)
        {
           driver = _driver;
        }

        private IWebElement productsTitle => driver.FindElement(By.XPath("//span[@class='title']"));
        private IWebElement AddbackpackToCart => driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
        private IWebElement AddOnesieToCart => driver.FindElement(By.Id("add-to-cart-sauce-labs-onesie"));


        public bool ProductsTitleDisplayed() => productsTitle.Displayed;

        public bool IsUrlContainInventory(string url)
        {
            return driver.Url.Contains(url);
        }
        
        public void AddTwoItemToCart()
        {
            AddbackpackToCart.Click();
            AddOnesieToCart.Click();
        }
    }
}

