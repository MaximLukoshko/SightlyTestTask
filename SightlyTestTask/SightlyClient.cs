namespace SightlyTestTask
{
    using System;
    using System.Threading;

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
                wait.Until(dr => dr.GetInputByPlaceHolder("Your email address"));

                var emailElement = driver.GetInputByPlaceHolder("Your email address");
                emailElement.Clear();
                emailElement.SendKeys("nick@sightly.com");

                var passwordElement = driver.GetInputByPlaceHolder("Your password");
                passwordElement.Clear();
                passwordElement.SendKeys("a");

                var loginButton = driver.GetButtonByClass("login-button");
                loginButton.Click();               
                wait.Until(dr => dr.GetDivById("header-reports"));

                Thread.Sleep(TimeSpan.FromSeconds(5));

                var reportsDiv = driver.GetDivById("header-reports");
                reportsDiv.Click();

                Thread.Sleep(TimeSpan.FromSeconds(5));

                var firstRowCheckBox = driver.GetFirstCheckBoxInTable("checkbox-style");
                firstRowCheckBox.Click();

                Thread.Sleep(TimeSpan.FromSeconds(3));

                var createReportButton = driver.GetButtonByClass("create-report");
                createReportButton.Click();

                Thread.Sleep(TimeSpan.FromSeconds(5));

                var radioButton = driver.GetRadioButtonByValue("performanceDetail");
                radioButton.Click();

                Thread.Sleep(TimeSpan.FromSeconds(1));
                
                var costBasis = driver.GetSelectDropDownByClass("report-dialog-select", 2);
                costBasis.SelectByValue("all");

                var timePeriod = driver.GetSelectDropDownByClass("report-dialog-select", 2);
                timePeriod.SelectByValue("all");

                Thread.Sleep(TimeSpan.FromSeconds(1));

                var runReportButton = driver.GetButtonByClass("run-report-button");
                runReportButton.Click();
                Thread.Sleep(TimeSpan.FromSeconds(10));

                result =
                    @"C:\Users\maxim.lukoshko\Downloads\PerformanceDetail-Campaign-A48EB038-5D47-40F8-A2BD-E897AEAC4A9F - Copy2.xlsx";

                driver.Close();
            }

            return result;
        }
    }
}