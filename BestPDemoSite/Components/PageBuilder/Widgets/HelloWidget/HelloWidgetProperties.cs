using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;

namespace BestPDemoSite.Components.PageBuilder.Widgets.HelloWidget
{
    public class HelloWidgetProperties : IWidgetProperties
    {
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 0, Label = "Welcome text")]
        public string WelcomeText { get; set; } = "Hello";
    }
}
