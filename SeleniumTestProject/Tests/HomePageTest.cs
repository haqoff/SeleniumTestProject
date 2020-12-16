using SeleniumTestProject.Init;
using SeleniumTestProject.Pages;
using Xunit;

namespace SeleniumTestProject.Tests
{
    public class HomePageTests : IClassFixture<TestStartupInitializerDefault>
    {
        private readonly TestStartupInitializerDefault _initializer;
        private readonly HomePage _page;

        public HomePageTests(TestStartupInitializerDefault initializer)
        {
            _initializer = initializer;
            _page = new HomePage(initializer);
        }


        [Fact]
        public void TestSearchField()
        {
            string query = "Муром";
            //_initializer.EnsureServerRestart();
            _page.Navigate();

            _page.NewSearchQuery(query);

            Assert.Equal(query, _page.CheckCurrentQueryText());
            Assert.DoesNotContain("осадки в Европе", _page.Title);
        }

        [Fact]
        public void NavigationViaSearchFTest()
        {
            string query = "Муром";
            _page.Navigate();

            _page.NewSearchQuery(query);
            _page.SearchQueryGo();
            Assert.Contains("Муром", _page.Title);
            Assert.Throws<OpenQA.Selenium.NoSuchElementException>(() => _page.isInformerPage());
        }

        [Fact]
        public void NavigateNewsTest()
        {
            _page.Navigate();
            _page.NewsGo();
            Assert.Contains("Новости погоды", _page.Title);
            Assert.DoesNotContain("осадки в Европе", _page.Title);
            Assert.Throws<OpenQA.Selenium.NoSuchElementException>(() => _page.isInformerPage());

            _page.NewsAutoGo();
            Assert.Contains("Автомобили", _page.Title);
            _page.NewsAnimalsGo();
            Assert.Contains("Животные", _page.Title);
            _page.NewsScienceGo();
            Assert.Contains("Наука", _page.Title);
            _page.NewsNewYearGo();
            Assert.Contains("Новый год", _page.Title);
            _page.NewsWeatherGo();
            Assert.Contains("О погоде", _page.Title);
            _page.NewsNatureGo();
            Assert.Contains("Природа", _page.Title);
            _page.NewsCoronavirusGo();
            Assert.Contains("коронавирус", _page.Title);
        }

        [Fact]
        public void NavigateMapsTest()
        {
            _page.Navigate();
            _page.MapsGo();
            Assert.Contains("осадки в Европе", _page.Title);
            Assert.Throws<OpenQA.Selenium.NoSuchElementException>(() => _page.isInformerPage());


            _page.MapsWindGo();
            Assert.Contains("ветер", _page.Title);
            _page.MapsPrcGo();
            Assert.Contains("осадки", _page.Title);
            _page.MapsCloudsGo();
            Assert.Contains("облачность", _page.Title);
            _page.MapsTempGo();
            Assert.Contains("температура", _page.Title);
        }

        [Fact]
        public void NavigateInformersTest()
        {
            _page.Navigate();
            _page.InformersGo();
            Assert.True(_page.isInformerPage());
            Assert.DoesNotContain("осадки в Европе", _page.Title);

            _page.InformersSimpleGo();
            Assert.Contains("Информер", _page.Title);
            _page.InformersContstructorGo();
            Assert.Contains("Конструктор", _page.Title);
            _page.InformersOfferGo();
            Assert.Contains("Условия", _page.Title);
        }

        [Fact]
        public void NavigateSoftTest()
        {
            _page.Navigate();
            _page.SoftGo();
            Assert.Contains("погодные приложения", _page.Title);
            Assert.DoesNotContain("осадки в Европе", _page.Title);
            Assert.Throws<OpenQA.Selenium.NoSuchElementException>(() => _page.isInformerPage());

            _page.SoftMobileGo();
            Assert.Contains("для мобильных устройств", _page.Title);
            _page.SoftDesktopGo();
            Assert.Contains("на рабочий стол", _page.Title);
            _page.SoftTVGo();
            Assert.Contains("для телевизоров", _page.Title);
        }
    }
}