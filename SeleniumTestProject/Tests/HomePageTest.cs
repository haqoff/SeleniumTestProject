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
            string query = "�����";
            //_initializer.EnsureServerRestart();
            _page.Navigate();

            _page.NewSearchQuery(query);

            Assert.Equal(query, _page.CheckCurrentQueryText());
            Assert.DoesNotContain("������ � ������", _page.Title);
        }

        [Fact]
        public void NavigationViaSearchFTest()
        {
            string query = "�����";
            _page.Navigate();

            _page.NewSearchQuery(query);
            _page.SearchQueryGo();
            Assert.Contains("�����", _page.Title);
            Assert.Throws<OpenQA.Selenium.NoSuchElementException>(() => _page.isInformerPage());
        }

        [Fact]
        public void NavigateNewsTest()
        {
            _page.Navigate();
            _page.NewsGo();
            Assert.Contains("������� ������", _page.Title);
            Assert.DoesNotContain("������ � ������", _page.Title);
            Assert.Throws<OpenQA.Selenium.NoSuchElementException>(() => _page.isInformerPage());

            _page.NewsAutoGo();
            Assert.Contains("����������", _page.Title);
            _page.NewsAnimalsGo();
            Assert.Contains("��������", _page.Title);
            _page.NewsScienceGo();
            Assert.Contains("�����", _page.Title);
            _page.NewsNewYearGo();
            Assert.Contains("����� ���", _page.Title);
            _page.NewsWeatherGo();
            Assert.Contains("� ������", _page.Title);
            _page.NewsNatureGo();
            Assert.Contains("�������", _page.Title);
            _page.NewsCoronavirusGo();
            Assert.Contains("�����������", _page.Title);
        }

        [Fact]
        public void NavigateMapsTest()
        {
            _page.Navigate();
            _page.MapsGo();
            Assert.Contains("������ � ������", _page.Title);
            Assert.Throws<OpenQA.Selenium.NoSuchElementException>(() => _page.isInformerPage());


            _page.MapsWindGo();
            Assert.Contains("�����", _page.Title);
            _page.MapsPrcGo();
            Assert.Contains("������", _page.Title);
            _page.MapsCloudsGo();
            Assert.Contains("����������", _page.Title);
            _page.MapsTempGo();
            Assert.Contains("�����������", _page.Title);
        }

        [Fact]
        public void NavigateInformersTest()
        {
            _page.Navigate();
            _page.InformersGo();
            Assert.True(_page.isInformerPage());
            Assert.DoesNotContain("������ � ������", _page.Title);

            _page.InformersSimpleGo();
            Assert.Contains("��������", _page.Title);
            _page.InformersContstructorGo();
            Assert.Contains("�����������", _page.Title);
            _page.InformersOfferGo();
            Assert.Contains("�������", _page.Title);
        }

        [Fact]
        public void NavigateSoftTest()
        {
            _page.Navigate();
            _page.SoftGo();
            Assert.Contains("�������� ����������", _page.Title);
            Assert.DoesNotContain("������ � ������", _page.Title);
            Assert.Throws<OpenQA.Selenium.NoSuchElementException>(() => _page.isInformerPage());

            _page.SoftMobileGo();
            Assert.Contains("��� ��������� ���������", _page.Title);
            _page.SoftDesktopGo();
            Assert.Contains("�� ������� ����", _page.Title);
            _page.SoftTVGo();
            Assert.Contains("��� �����������", _page.Title);
        }
    }
}