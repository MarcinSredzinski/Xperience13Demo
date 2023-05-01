//DocSection:ExampleWidget
using BestPDemoSite.Components.PageBuilder.Widgets.NumberWidget;
using Kentico.PageBuilder.Web.Mvc;

[assembly: RegisterWidget("LearningKit.Widgets.NumberWidget",
                         "Number selector",
                         typeof(NumberWidgetProperties),
                         customViewName: "~/Components/PageBuilder/Widgets/NumberWidget/_NumberWidget.cshtml")]
//EndDocSection:ExampleWidget