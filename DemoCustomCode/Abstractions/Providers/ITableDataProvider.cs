﻿using CMS.CustomTables;

namespace DemoCustomCode.Abstractions.Providers;

public interface ITableDataProvider
{
    public IEnumerable<string> GetValuesFromColumn<T>(string customTableClassName, string columnName,
                                            Func<T, string> selector) where T : CustomTableItem, new();
}