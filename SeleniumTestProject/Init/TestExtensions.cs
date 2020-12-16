using OpenQA.Selenium;

namespace SeleniumTestProject.Init
{
    public static class TestExtensions
    {
        public static IJavaScriptExecutor GetJsExecutor(this IWebDriver driver)
        {
            return (IJavaScriptExecutor)driver;
        }
    }
}
