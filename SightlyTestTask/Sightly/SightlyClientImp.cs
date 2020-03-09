namespace SightlyTestTask.Sightly
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

    public class SightlyClientImp : ISightlyClient
    {
        private readonly IWebDriver webDriver;

        private SightlyClientImp(IWebDriver webDriver)
        {
            this.webDriver = webDriver ?? new ChromeDriver();
        }

        public static SightlyClientImp Create(IWebDriver webDriver = null)
        {
            return new SightlyClientImp(webDriver);
        }

        public void Dispose()
        {
            this.webDriver.Dispose();
        }

        public string DownloadPerformanceDetailReport()
        {
            //var homeURL = "https://www.SauceLabs.com";
            //this.webDriver.Navigate().GoToUrl(homeURL);

            //var wait = new WebDriverWait(this.webDriver, System.TimeSpan.FromSeconds(15));
            //wait.Until(dr => dr.FindElement(By.XPath("//a[@href='/beta/login']")));

            //var element = this.webDriver.FindElement(By.XPath("//a[@href='/beta/login']"));

            return
                @"C:\Users\maxim.lukoshko\Downloads\PerformanceDetail-Campaign-A48EB038-5D47-40F8-A2BD-E897AEAC4A9F - Copy.xlsx";
        }
    }
}