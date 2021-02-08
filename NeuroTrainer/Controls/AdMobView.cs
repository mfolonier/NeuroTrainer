using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace NeuroTrainer.Controls
{
    public class AdControlView : Xamarin.Forms.View
    {

        public static readonly BindableProperty AdUnitIdProperty = BindableProperty.Create(
            nameof(AdUnitId),
            typeof(string),
            typeof(AdControlView));

        public string AdUnitId
        {
            get => (string)GetValue(AdUnitIdProperty);
            set => SetValue(AdUnitIdProperty, value);
        }


    }
}
