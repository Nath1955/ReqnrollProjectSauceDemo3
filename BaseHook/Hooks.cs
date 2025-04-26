namespace ReqnrollProjectSauceDemo3.BaseHook
{
    [Binding]
    public sealed class Hooks
    {
        public InitializeDriver _initializeDriver;  
        public IObjectContainer objectContainer;

        public Hooks(InitializeDriver initializeDriver, IObjectContainer container)
        {
            _initializeDriver = initializeDriver;
            objectContainer = container;
        }

        [BeforeScenario()]
        public void BeforeScenarioWithTag()
        {
             _initializeDriver.Start();
            objectContainer.RegisterInstanceAs(_initializeDriver.driver);
        } 

        [AfterScenario]
        public void AfterScenario()
        {
           _initializeDriver.CloseDownBrowser();
        }
    }
}