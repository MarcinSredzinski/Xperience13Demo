//DocSection:ExampleWidget
using BestPDemoSite.Components.PageBuilder.Widgets.HelloWidget;
using BestPDemoSite.Components.PageBuilder.Widgets.NumberWidget;
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


//DocSection:HelloWidget

[assembly: RegisterWidget("BestPDemoSite.Widgets.BetterHelloWidget",
                         "Better Hello widget",
                         typeof(BetterHelloWidgetProperties),
                         customViewName: "~/Components/PageBuilder/Widgets/BetterHelloWidget/_BetterHelloWidget.cshtml")]
//EndDocSection:HelloWidget