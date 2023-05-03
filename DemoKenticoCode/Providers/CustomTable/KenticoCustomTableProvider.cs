using CMS.CustomTables;
using CMS.DataEngine;
using DemoCustomCode.Abstractions.Providers;

namespace DemoKenticoCode.Providers.CustomTable;

public class KenticoCustomTableProvider : ITableDataProvider
{
    public IEnumerable<string> GetValuesFromColumn<T>(string customTableClassName, string columnName,
                                                Func<T, string> selector) where T : CustomTableItem, new()
    {
        DataClassInfo customTable = DataClassInfoProvider.GetDataClassInfo(customTableClassName);
        if (customTable == null)
            return new List<string>();

        var dataFromColumn = CustomTableItemProvider.GetItems<T>()
                                                   .Columns(columnName)
                                                   .Select(selector);
        return dataFromColumn;
    }
}