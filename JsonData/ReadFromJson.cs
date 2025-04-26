namespace ReqnrollProjectSauceDemo3.JsonData
{
    public class ReadFromJson
    {
        public IConfigurationRoot _config;
        public ReadFromJson()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("reqnroll.json");
            _config = builder.Build();
        }

        public string GetUrl() => _config.GetSection("url:saucedemoUrl").Value!;
    }
}
