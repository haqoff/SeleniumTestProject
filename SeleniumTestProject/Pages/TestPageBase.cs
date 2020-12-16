using System;
using SeleniumTestProject.Init;

namespace SeleniumTestProject.Pages
{
    public abstract class TestPageBase
    {
        protected readonly ITestStartupInitializer Initializer;

        protected TestPageBase(ITestStartupInitializer initializer)
        {
            this.Initializer = initializer;
        }

        public abstract Uri Uri { get; }
        public string Title => Initializer.Driver.Title;

        public void Navigate()
        {
            Initializer.Driver.Navigate().GoToUrl(Uri);
        }
        
    }
}
