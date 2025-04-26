namespace ReqnrollProjectSauceDemo3.Drivers
{
    public class InitializeDriver
    {
        public IWebDriver driver;
        ChromeOptions options;

        public IWebDriver Start()
        {
            options = new ChromeOptions();
            options.AddArguments("--start-maximized", "--incognito");
            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            return driver;
        }

        public void CloseDownBrowser()
        {
            if (driver != null)
            {
                driver.Close();
                driver.Quit();
            }
        }
    }
}
