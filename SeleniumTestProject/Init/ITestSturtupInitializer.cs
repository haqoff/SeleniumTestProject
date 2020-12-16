using System;
using OpenQA.Selenium;

namespace SeleniumTestProject.Init
{
    public interface ITestStartupInitializer
    {
        /// <summary>
        /// Корневой адрес сервера для тестирования.
        /// </summary>
        Uri RootUri { get; }

        /// <summary>
        /// Драйвер для тестирования.
        /// </summary>
        IWebDriver Driver { get; }
    }
}
