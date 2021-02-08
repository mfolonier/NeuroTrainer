using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace NeuroTrainer
{
    public partial class App : Application
    {

        public static ViewModel.ViewModel vm;
        public App()
        {


            Device.SetFlags(new[] { "Shapes_Experimental", "Brush_Experimental" });
            InitializeComponent();

            vm = new ViewModel.ViewModel();
            MainPage = new NavigationPage(new View.Setting(vm));

           
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
