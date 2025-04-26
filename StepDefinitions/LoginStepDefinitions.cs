namespace ReqnrollProjectSauceDemo3.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions 
    {
        LoginHomePage lHomepage;
        ProductPage pctpage;
        CartPage cartPage;
        IWebDriver driver;

        public LoginStepDefinitions(IObjectContainer container)  
        {
            driver = container.Resolve<IWebDriver>();
            lHomepage = new LoginHomePage(driver);  
            pctpage = new ProductPage(driver);
            cartPage = new CartPage(driver);
        }

        [Given("user navigate on saucedemo website")]
        public void GivenUserNavigateOnSaucedemoWebsite()
        {
            lHomepage.NavigateToWebsite();     
        }

        [When("user enters login credentials")]
        public void WhenUserEntersLoginCredentials(DataTable dataTable)
        {
            lHomepage.EnterLoginCredentials(dataTable.Rows[0]["username"], dataTable.Rows[0]["password"]);   
        }

        [When("user click on the login button")]
        public void WhenUserClickOnTheLoginButton()
        {
           lHomepage.ClickOnLonginBtn();
        }

        [Then("user lands on the current url with {string}")]
        public void ThenUserLandsOnTheCurrentUrlWith(string url)
        {
           var currenturl = pctpage.IsUrlContainInventory(url);
           Assert.That(currenturl, Is.True);
        }

        [Then("user is on product's page")]
        public void ThenUserIsOnProductsPage()
        {
            pctpage.ProductsTitleDisplayed();
        }

        [When("user adds one of the following product to the cart:")]
        public void WhenUserAddsOneOfTheFollowingProductToTheCart(DataTable dataTable)
        {
            pctpage.AddTwoItemToCart();
        }

        [When("user clicks on cart basket to view the items")]
        public void WhenUserClicksOnCartBasketToViewTheItems()
        {
            cartPage.ClickOnCartBtn();
        }

        [Then("user verifies product count is {int}")]
        public void ThenUserVerifiesProductCountIs(int ExpectedCount)
        {
            var actualcount = cartPage.CountItem();
            Assert.That(ExpectedCount, Is.EqualTo(actualcount));     
        }

        [Then("user also verifies the product names to be:")]
        public void ThenUserAlsoVerifiesTheProductNamesToBe(DataTable dataTable)
        {
            List <string>tableData = new List <string> ();
            // var expectedNames = dataTable.Rows.Select(x => x["ProductName"]).ToList();
            //var expectedNames = dataTable.Rows[0]["ProductName"];
            foreach (var data in dataTable.Rows)
            {
                tableData.Add(data.Values.First());
            }
            var actualNames = cartPage.GetItemNames();

            //CollectionAssert.AreEquivalent(expectedNames, actualNames);
            CollectionAssert.AreEquivalent(tableData, actualNames);
        }

        [When("user click on the hambuger menu")]
        public void ThenUserClickOnTheHambugerMenu()
        {
            cartPage.ClickHamburger();
        }

        [When("user click on logout button")]
        public void WhenUserClickOnLogoutButton()
        {
            cartPage.ClickLogout();
        }

        [Then("user should logout")]
        public void ThenUserShouldLogout()
        {
            var mainUrl = cartPage.IsLogoutPageDisplayed();
            Assert.That(mainUrl, Is.True);
        }
    }
}
