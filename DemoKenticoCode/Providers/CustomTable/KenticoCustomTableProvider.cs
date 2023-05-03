﻿using CMS.CustomTables;
using CMS.DataEngine;

namespace DemoKenticoCode.Providers.CustomTable;

internal class KenticoCustomTableProvider
{
    public IEnumerable<string> GetValuesFromColumn<T>(string customTableClassName, string columnName,
                                                Func<System.Data.DataRow, string> selector) where T : CustomTableItem, new()
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