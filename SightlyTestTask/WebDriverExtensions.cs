namespace SightlyTestTask
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public static class WebDriverExtensions
    {
        public static IWebElement GetInputByPlaceHolder(this IWebDriver webDriver, string placeHolder)
        {
            return webDriver.FindElement(By.XPath($"//input[@placeholder='{placeHolder}']"));
        }

        public static IWebElement GetButtonByClass(this IWebDriver webDriver, string buttonClass)
        {
            return webDriver.FindElement(By.XPath($"//button[contains(@class, '{buttonClass}')]"));
        }

        public static IWebElement GetDivById(this IWebDriver webDriver, string divId)
        {
            return webDriver.FindElement(By.XPath($"//div[@id='{divId}']"));
        }

        public static IWebElement GetFirstCheckBoxInTable(this IWebDriver webDriver, string divClass)
        {
            return webDriver.FindElement(By.XPath($"(//input[contains(@class, '{divClass}')])[2]"));
        }

        public static IWebElement GetRadioButtonByValue(this IWebDriver webDriver, string value)
        {
            return webDriver.FindElement(By.XPath($"//input[@value='{value}']"));
        }

        public static SelectElement GetSelectDropDownByClass(this IWebDriver webDriver, string selectClass, int index)
        {
            return new SelectElement(webDriver.FindElement(By.XPath($"(//select[contains(@class, '{selectClass}')])[{index}]")));
        }
    }
}