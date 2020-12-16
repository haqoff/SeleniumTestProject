using System;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTestProject.Init
{
    /// <summary>
    /// Представляет собой класс, который инициализирует окружение для UI-тестирования веб-приложений.
    /// </summary>
    public abstract class TestStartupInitializer : ITestStartupInitializer, IDisposable
    {
        private Lazy<Uri> _rootUriInitializer;
        private Lazy<IWebDriver> _driverInitializer;

        public Uri RootUri => _rootUriInitializer.Value;
        public IWebDriver Driver => _driverInitializer.Value;
        

        protected TestStartupInitializer()
        {
            InitLazy();
        }

        private void InitLazy()
        {
            _rootUriInitializer = new Lazy<Uri>(StartAndGetRootUri);
            _driverInitializer = new Lazy<IWebDriver>(CreateWebDriver);
        }

        protected static void RunInBackgroundThread(Action action)
        {
            var isDone = new ManualResetEvent(false);
            ExceptionDispatchInfo edi = null;
            new Thread(() =>
            {
                try
                {
                    action();
                }
                catch (Exception ex)
                {
                    edi = ExceptionDispatchInfo.Capture(ex);
                }

                isDone.Set();
            }).Start();

            if (!isDone.WaitOne(TimeSpan.FromSeconds(10)))
                throw new TimeoutException("Timed out waiting for: " + action);

            if (edi != null)
                throw edi.SourceException;
        }

        protected virtual Uri StartAndGetRootUri()
        {
            
            return new Uri("https://www.gismeteo.ru/");
        }

        public void Dispose() => Dispose(true);

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Driver?.Dispose();
            }
        }

        public void EnsureServerRestart()
        {
            Dispose();
            InitLazy();
        }


        protected abstract IWebDriver CreateWebDriver();
    }

    public class TestStartupInitializerDefault : TestStartupInitializer
    {
        /// <inheritdoc />
        protected override IWebDriver CreateWebDriver()
        {
            var service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;

            var options = new ChromeOptions();
            options.AddArgument("headless");


            var driver = new ChromeDriver(service, options);
            return driver;
        }
    }
}
