using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroTrainer.ViewModel;
using Xamarin.Forms;

using Xamarin.Forms.Xaml;

namespace NeuroTrainer.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Setting : ContentPage
    {
        public Setting()
        {
            InitializeComponent();
        }
        public Setting(ViewModel.ViewModel vm)
        {
           
            InitializeComponent();

            BindingContext = vm;

          
        }
        protected override void OnAppearing()
        {

            base.OnAppearing();

            ViewModel.ViewModel.RunThread = false; // To stop program when the user press back button

           
                      

        }
            private void Switch_Toggled(object sender, ToggledEventArgs e)
            {
                bool state = e.Value;

               

                ViewModel.ViewModel.TheSwitchState(state);
                Debug.WriteLine($"el switch esta en  estado: {state} //// ");


            }
    }
}