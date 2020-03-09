
namespace SightlyTestTask
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;

    using Assert = NUnit.Framework.Assert;

    [TestFixture]
    public class UnitTest1
    {
        private IWebDriver driver;

        [SetUp]
        public void SetupTest()
        {
            this.driver = new ChromeDriver();
        }

        [Test(Description = "Check SauceLabs Homepage for Login Link")]
        public void TestMethod()
        {
            var homeURL = "https://www.SauceLabs.com";
            this.driver.Navigate().GoToUrl(homeURL);

            var wait = new WebDriverWait(this.driver, System.TimeSpan.FromSeconds(15));
            wait.Until(dr => dr.FindElement(By.XPath("//a[@href='/beta/login']")));

            var element = this.driver.FindElement(By.XPath("//a[@href='/beta/login']"));

            Assert.AreEqual("Sign In", element.GetAttribute("text"));
        }

        [TearDown]
        public void TearDownTest()
        {
            driver.Close();
        }
    }
}
