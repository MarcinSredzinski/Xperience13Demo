using CMS.Core;
using DemoCustomCode.Abstractions.Providers;
using DemoCustomCode.Abstractions.Services;
using DemoCustomCode.Widgets;
using DemoDomainObjects.Models.WeatherStack;
using DemoDomainObjects.Models.Widgets.Properties;
using FluentAssertions;
using Moq;

namespace DemoCustomCode.Tests.Widgets
{
    public class FinalHelloWidgetServiceTests
    {
        FinalHelloWidgetService finalHelloWidgetService;
        Mock<ITableDataProvider> tableProviderMock;

        [SetUp]
        public void Setup()
        {
            var warsaw = "Warsaw";
            var london = "London";
            tableProviderMock = new Mock<ITableDataProvider>();
            var weatherstackServiceMock = new Mock<IWeatherstackClientService>();
            var eventLogServiceMock = new Mock<IEventLogService>();

            tableProviderMock.Setup(t =>
             t.GetValuesFromColumn<CMS.CustomTables.Types.Demo.CityNameItem>
                 (It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Func<CMS.CustomTables.Types.Demo.CityNameItem, string>>())).Returns(new List<string> { warsaw, london });
            var responseTaskWarsaw = Task.FromResult(new WeatherForecast() { Current = new Current() { Temperature = 20 } });
            weatherstackServiceMock.Setup(w => w.GetCurrentWeatherForCity(warsaw))
                .Returns(responseTaskWarsaw);
            var responseTaskLondon = Task.FromResult(new WeatherForecast() { Current = new Current() { Temperature = 10 } });
            weatherstackServiceMock.Setup(w => w.GetCurrentWeatherForCity(london))
                .Returns(responseTaskLondon);


            ITableDataProvider tableProviderObject = tableProviderMock.Object;
            IWeatherstackClientService weatherstackClientServiceObject = weatherstackServiceMock.Object;
            IEventLogService eventLogServiceObject = eventLogServiceMock.Object;

            finalHelloWidgetService = new FinalHelloWidgetService(tableProviderObject, weatherstackClientServiceObject, eventLogServiceObject);
        }

        [Test]
        public void GetWidget_ShouldReturnWidgetModel()
        {
            //Arrange
            var widgetProperties = new FinalHelloWidgetProperties() { WelcomeText = "hello" };

            //Act
            var result = finalHelloWidgetService.GetWidget(widgetProperties).Result;

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.WeatherInfo, Is.Not.Null);
        }
        [Test]
        public void GetWidget_ResponseShouldContainTemperatureForWarsaw()
        {
            //Arrange
            var widgetProperties = new FinalHelloWidgetProperties() { WelcomeText = "hello" };

            //Act
            var result = finalHelloWidgetService.GetWidget(widgetProperties).Result;
            //Assert
            result.WeatherInfo.Should().Contain("Temperature for: Warsaw is 20 <br/>");
        }
        [Test]
        public void GetWidget_ResponseShouldCallGetValuesFromColumn()
        {
            //Arrange
            var widgetProperties = new FinalHelloWidgetProperties() { WelcomeText = "hello" };

            //Act
            var result = finalHelloWidgetService.GetWidget(widgetProperties).Result;

            //Assert
            tableProviderMock.Verify(t => t.GetValuesFromColumn<CMS.CustomTables.Types.Demo.CityNameItem>
                   (It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Func<CMS.CustomTables.Types.Demo.CityNameItem, string>>()),
                      Times.Once());
        }

    }
}