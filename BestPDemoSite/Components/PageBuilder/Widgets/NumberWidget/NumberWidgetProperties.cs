﻿using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using System.Reflection.Emit;

namespace BestPDemoSite.Components.PageBuilder.Widgets.NumberWidget
{
    public class NumberWidgetProperties : IWidgetProperties
    {
        // Defines a property and sets its default value
        // Assigns the default Xperience text input component, which allows users to enter
        // a numeric value for the property in the widget's configuration dialog
        [EditingComponent(IntInputComponent.IDENTIFIER, Order = 0, Label = "Number")]
        public int Number { get; set; } = 22;
    }
}
