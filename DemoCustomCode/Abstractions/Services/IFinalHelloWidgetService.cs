using DemoDomainObjects.Models.Widgets.Properties;
using DemoDomainObjects.Models.Widgets.ViewModels;

namespace DemoCustomCode.Abstractions.Services;

public interface IFinalHelloWidgetService
{
    public Task<FinalHelloWidgetViewModel> GetWidget(FinalHelloWidgetProperties properties);
}