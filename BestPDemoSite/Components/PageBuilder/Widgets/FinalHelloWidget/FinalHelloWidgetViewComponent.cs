using DemoCustomCode.Abstractions.Services;
using DemoDomainObjects.Models.Widgets.Properties;
using Kentico.PageBuilder.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BestPDemoSite.Components.PageBuilder.Widgets.FinalHelloWidget;

public class FinalHelloWidgetViewComponent : ViewComponent
{
    private readonly IFinalHelloWidgetService _finalHelloWidgetService;

    public FinalHelloWidgetViewComponent(IFinalHelloWidgetService finalHelloWidgetService)
    {
        _finalHelloWidgetService = finalHelloWidgetService;
    }
    public async Task<IViewComponentResult> InvokeAsync(ComponentViewModel<FinalHelloWidgetProperties> properties)
    {
        return View("~/Components/PageBuilder/Widgets/FinalHelloWidget/_FinalHelloWidget.cshtml",
                    await _finalHelloWidgetService.GetWidget(properties.Properties));
    }
}