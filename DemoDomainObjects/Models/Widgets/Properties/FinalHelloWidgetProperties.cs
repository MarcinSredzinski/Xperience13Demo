using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;

namespace DemoDomainObjects.Models.Widgets.Properties
{
    public class FinalHelloWidgetProperties : IWidgetProperties
    {
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 0, Label = "Welcome text")]
        public string WelcomeText { get; set; } = "Hello";
    }
}
