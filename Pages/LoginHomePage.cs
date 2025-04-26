using ReqnrollProjectSauceDemo3.JsonData;

namespace ReqnrollProjectSauceDemo3.Pages
{
    public class LoginHomePage 
    {
        IWebDriver driver;
        ReadFromJson readFromJson;

        public LoginHomePage(IWebDriver _driver)  
        {
            driver = _driver;
            readFromJson = new ReadFromJson();
        }

        IWebElement userName => driver.FindElement(By.Id("user-name"));   
        IWebElement passWord => driver.FindElement(By.Id("password"));   
        IWebElement loginBtn => driver.FindElement(By.Id("login-button")); 

        public void NavigateToWebsite()
        {
            var url1 = readFromJson.GetUrl();
           // driver.Navigate().GoToUrl(environdata.saucedemoUrl);
            driver.Navigate().GoToUrl(readFromJson.GetUrl());
        }

        public void EnterLoginCredentials(string username, string password)     
        {
            userName.SendKeys(username);
            passWord.SendKeys(password);
        }

        public void ClickOnLonginBtn() => loginBtn.Click();
    }
}
