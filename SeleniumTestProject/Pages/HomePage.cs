using System;
using OpenQA.Selenium;
using SeleniumTestProject.Init;

namespace SeleniumTestProject.Pages
{
    public class HomePage : TestPageBase
    {
        public override Uri Uri => new Uri(Initializer.RootUri, "");


        public IWebElement SearchF => Initializer.Driver.FindElement(By.ClassName("search_input"));

        public IWebElement WeatherSection => Initializer.Driver.FindElement(By.CssSelector("[href*='/']"));

        #region newsForms

        public IWebElement NewsSection => Initializer.Driver.FindElement(By.CssSelector("[href*='/news/']"));
        public IWebElement NewsAutoSection => Initializer.Driver.FindElement(By.CssSelector("[href*='/news/auto/']"));
        public IWebElement NewsAnimalsSection => Initializer.Driver.FindElement(By.CssSelector("[href*='/news/animals/']"));
        public IWebElement NewsScienceSection => Initializer.Driver.FindElement(By.CssSelector("[href*='/news/science/']"));
        public IWebElement NewsNewYearSection => Initializer.Driver.FindElement(By.CssSelector("[href*='/news/new-year/']"));
        public IWebElement NewsWeatherSection => Initializer.Driver.FindElement(By.CssSelector("[href*='/news/weather/']"));
        public IWebElement NewsNatureSection => Initializer.Driver.FindElement(By.CssSelector("[href*='/news/nature/']"));
        public IWebElement NewsCoronavirusSection => Initializer.Driver.FindElement(By.CssSelector("[href*='/news/coronavirus/']"));

        #endregion

        #region mapsForms

        public IWebElement MapsSection => Initializer.Driver.FindElement(By.CssSelector("[href*='/maps/']"));

        public IWebElement MapsWindSection => Initializer.Driver.FindElement(By.CssSelector("[href*='/maps/eur/wind/']"));
        public IWebElement MapsPrcSection => Initializer.Driver.FindElement(By.CssSelector("[href*='/maps/eur/prc/']"));
        public IWebElement MapsCloudSection => Initializer.Driver.FindElement(By.CssSelector("[href*='/maps/eur/clou/']"));

        public IWebElement MapsTempSection => Initializer.Driver.FindElement(By.CssSelector("[href*='/maps/eur/temp/']"));

        #endregion

        #region informersForms
        public IWebElement InformersSection => Initializer.Driver.FindElement(By.CssSelector("[href*='/informers/']"));

        public IWebElement InformerSimpleSection => Initializer.Driver.FindElement(By.CssSelector("[href*='/informers/simple/']"));
        public IWebElement InformerConstructorSection => Initializer.Driver.FindElement(By.CssSelector("[href*='/informers/constructor/"));
        public IWebElement InformerOfferSection => Initializer.Driver.FindElement(By.CssSelector("[href*='/informers/offer/"));

        #endregion

        #region softForms
        public IWebElement SoftSection => Initializer.Driver.FindElement(By.CssSelector("[href*='/soft/']"));
        public IWebElement SoftMobileSection => Initializer.Driver.FindElement(By.CssSelector("[href*='/soft-mobile/']"));
        public IWebElement SoftDesktopSection => Initializer.Driver.FindElement(By.CssSelector("[href*='/soft-desktop/']"));
        public IWebElement SoftTVSection => Initializer.Driver.FindElement(By.CssSelector("[href*='/soft-tv/']"));

        #endregion
        public IWebElement WeatherInformerLabel => Initializer.Driver.FindElement(By.XPath("//div[@class='main']/h1"));

        #region searchFThings
        public void NewSearchQuery(string query)
        {
            SearchF.SendKeys(query);
        }

        public string CheckCurrentQueryText()
        {
            return SearchF.GetAttribute("value");
        }



        public void SearchQueryGo() => SearchF.SendKeys(Keys.Enter);

        #endregion

        #region news

        public void NewsGo() => NewsSection.Click();

        public void NewsAutoGo() => Initializer.Driver.GetJsExecutor().ExecuteScript("arguments[0].click();", NewsAutoSection);

        public void NewsScienceGo() => Initializer.Driver.GetJsExecutor().ExecuteScript("arguments[0].click();", NewsScienceSection);

        public void NewsAnimalsGo() => Initializer.Driver.GetJsExecutor().ExecuteScript("arguments[0].click();", NewsAnimalsSection);
        public void NewsNewYearGo() => Initializer.Driver.GetJsExecutor().ExecuteScript("arguments[0].click();", NewsNewYearSection);

        public void NewsWeatherGo() => Initializer.Driver.GetJsExecutor().ExecuteScript("arguments[0].click();", NewsWeatherSection);

        public void NewsNatureGo() => Initializer.Driver.GetJsExecutor().ExecuteScript("arguments[0].click();", NewsNatureSection);
        public void NewsCoronavirusGo() => Initializer.Driver.GetJsExecutor().ExecuteScript("arguments[0].click();", NewsCoronavirusSection);

        #endregion

        #region maps
        public void MapsGo() => MapsSection.Click();

        public void MapsWindGo() => Initializer.Driver.GetJsExecutor().ExecuteScript("arguments[0].click();", MapsWindSection);

        public void MapsPrcGo() => Initializer.Driver.GetJsExecutor().ExecuteScript("arguments[0].click();", MapsPrcSection);

        public void MapsCloudsGo() => Initializer.Driver.GetJsExecutor().ExecuteScript("arguments[0].click();", MapsCloudSection);
        public void MapsTempGo() => Initializer.Driver.GetJsExecutor().ExecuteScript("arguments[0].click();", MapsTempSection);

        #endregion

        #region informers

        public void InformersGo() => InformersSection.Click();

        public void InformersSimpleGo() => Initializer.Driver.GetJsExecutor().ExecuteScript("arguments[0].click();", InformerSimpleSection);
        public void InformersContstructorGo() => Initializer.Driver.GetJsExecutor().ExecuteScript("arguments[0].click();", InformerConstructorSection);
        public void InformersOfferGo() => Initializer.Driver.GetJsExecutor().ExecuteScript("arguments[0].click();", InformerOfferSection);

        #endregion

        public void SoftGo() => SoftSection.Click();

        public void SoftMobileGo() => Initializer.Driver.GetJsExecutor().ExecuteScript("arguments[0].click();", SoftMobileSection);
        public void SoftDesktopGo() => Initializer.Driver.GetJsExecutor().ExecuteScript("arguments[0].click();", SoftDesktopSection);
        public void SoftTVGo() => Initializer.Driver.GetJsExecutor().ExecuteScript("arguments[0].click();", SoftTVSection);

        public bool IsElementVisible(IWebElement element)
        {
            return element.Displayed && element.Enabled;
        }

        //ExceptionTestHelper
        public bool isInformerPage()
        {
            return WeatherInformerLabel.Displayed;
        }

        public HomePage(ITestStartupInitializer initializer) : base(initializer)
        {
        }
    }
}
