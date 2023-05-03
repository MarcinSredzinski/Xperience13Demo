using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using System.Reflection.Emit;

namespace BestPDemoSite.Components.PageBuilder.Widgets.HelloWidget
{
    public class BetterHelloWidgetProperties : IWidgetProperties
    {
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 0, Label = "Welcome text")]
        public string WelcomeText { get; set; } = "Better Hello"; 
    }
}
