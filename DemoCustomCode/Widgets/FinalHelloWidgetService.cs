using DemoCustomCode.Abstractions.Providers;
using DemoDomainObjects.Models.Widgets.Properties;

namespace DemoCustomCode.Widgets
{
    public class FinalHelloWidgetService
    {
        private readonly ITableDataProvider _tableDataProvider;
        private const string CustomTableClassName = "demo.CityName";
        private const string CustomTableColumnName = "CityName";


        public object GetWidget(FinalHelloWidgetProperties properties)
        {
            //Get cities
            var cities = _tableDataProvider.GetValuesFromColumn<CMS.CustomTables.Types.Demo.CityNameItem>(CustomTableClassName,
                            CustomTableColumnName, c => c.CityName);
            //Get data from properties and do operations on them

            //Get weather data + log that the data was loaded
            //Combine into one object
            return new();
        }
    }
}