namespace ReqnrollProjectSauceDemo3.Pages
{
    public class CartPage
    {
        IWebDriver driver;
        public CartPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IList<IWebElement> CartItemElements =>
        driver.FindElements(By.CssSelector(".cart_item .inventory_item_name"));
        private IWebElement CartBtn => driver.FindElement(By.XPath("(//a[@class='shopping_cart_link'])[1]"));
        private IWebElement totalCount => driver.FindElement(By.CssSelector("[data-test='shopping-cart-badge']"));
        private IWebElement logoutBtn => driver.FindElement(By.CssSelector("#logout_sidebar_link"));
        private IWebElement hamburgerMenu => driver.FindElement(By.Id("react-burger-menu-btn"));
        
        
        public int CountItem()
        {
            return int.Parse(totalCount.Text);
        }

        public void ClickOnCartBtn() => CartBtn.Click();
        public void ClickHamburger()
        {
            hamburgerMenu.Click();
            Thread.Sleep(1000);
        }

        public void ClickLogout() => logoutBtn.Click();

        public List<string> GetItemNames()
        {
            return CartItemElements.Select(item => item.Text).ToList();
        }
        public bool IsLogoutPageDisplayed()
        {
            return driver.Url.Contains("saucedemo");
        }
    }
}
