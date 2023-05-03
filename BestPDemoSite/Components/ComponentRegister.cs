//DocSection:ExampleWidget
using BestPDemoSite.Components.PageBuilder.Widgets.FinalHelloWidget;
using BestPDemoSite.Components.PageBuilder.Widgets.HelloWidget;
using BestPDemoSite.Components.PageBuilder.Widgets.NumberWidget;
using DemoDomainObjects.Models.Widgets.Properties;
using Kentico.PageBuilder.Web.Mvc;

[assembly: RegisterWidget("LearningKit.Widgets.NumberWidget",
                         "Number selector",
                         typeof(NumberWidgetProperties),
                         customViewName: "~/Components/PageBuilder/Widgets/NumberWidget/_NumberWidget.cshtml")]
//EndDocSection:ExampleWidget


//DocSection:HelloWidget

[assembly: RegisterWidget("BestPDemoSite.Widgets.HelloWidget",
                         "Hello widget",
                         typeof(HelloWidgetProperties),
                         customViewName: "~/Components/PageBuilder/Widgets/HelloWidget/_HelloWidget.cshtml")]
//EndDocSection:HelloWidget


//DocSection:BetterHelloWidget

[assembly: RegisterWidget("BestPDemoSite.Widgets.BetterHelloWidget",
                         typeof(BetterHelloWidgetViewComponent),
                         "Better Hello widget",
                         //customViewName: "~/Components/PageBuilder/Widgets/BetterHelloWidget/_BetterHelloWidget.cshtml",
                         typeof(BetterHelloWidgetProperties))]
//EndDocSection:BetterHelloWidget


//DocSection:FinalHelloWidget

[assembly: RegisterWidget("BestPDemoSite.Widgets.FinalHelloWidget",
                         typeof(FinalHelloWidgetViewComponent),
                         "Final Hello widget",
                         //customViewName: "~/Components/PageBuilder/Widgets/BetterHelloWidget/_BetterHelloWidget.cshtml",
                         typeof(FinalHelloWidgetProperties))]
//EndDocSection:FinalHelloWidget