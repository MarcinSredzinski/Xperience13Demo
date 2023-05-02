using BestPDemoSite.Components.PageBuilder.Widgets.HelloWidget;
using Kentico.PageBuilder.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BestPDemoSite.Components.PageBuilder.Widgets.BetterHelloWidget
{
    public class BetterHelloWidgetViewComponent : ViewComponent
    {
        public async Task InvokeAsync(ComponentViewModel<BetterHelloWidgetProperties> properties)
        {
            properties.Properties.WelcomeText += "Mordeczki";
        }
    }
}
