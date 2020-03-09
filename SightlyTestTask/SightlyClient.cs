namespace SightlyTestTask
{
    using System;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;

    public class SightlyClient
    {
        public static string DownloadPerformanceDetailReport()
        {
            string result;

            using (var driver = new ChromeDriver())
            {
                var homeURL = "https://staging-newtargetview.sightly.com/";

                driver.Navigate().GoToUrl(homeURL);

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(dr => dr.FindElement(By.XPath("//input[@placeholder='Your email address']")));

                var emailElement = driver.FindElement(By.XPath("//input[@placeholder='Your email address']"));
                //emailElement.Click();
                emailElement.Clear();
                emailElement.SendKeys("nick@sightly.com");

                var passwordElement = driver.FindElement(By.XPath("//input[@placeholder='Your password']"));
                passwordElement.Clear();
                //passwordElement.Click();
                passwordElement.SendKeys("a");

                var loginButton = driver.FindElement(By.XPath("//button[contains(@class, 'login-button')]"));
                loginButton.Click();

                wait.Until(dr => dr.FindElement(By.XPath("//input[@placeholder='re']")));

                result =
                    @"C:\Users\maxim.lukoshko\Downloads\PerformanceDetail-Campaign-A48EB038-5D47-40F8-A2BD-E897AEAC4A9F - Copy2.xlsx";

                driver.Close();
            }

            return result;
        }
    }
}