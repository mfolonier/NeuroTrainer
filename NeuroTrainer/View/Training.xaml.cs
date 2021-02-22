using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NeuroTrainer.ViewModel;
using System.Threading;

namespace NeuroTrainer.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Training : ContentPage
    {
        public Training()
        {
            InitializeComponent();
        }
        public Training(ViewModel.ViewModel vm)
        {

            InitializeComponent();
            BindingContext = vm;
            //Paso Color
            ColorWork.NewboxColor(FrameboxColor);

            // Paso Color y nombre 
            ColorWork.NewboxName(FrameboxName);
            ColorWork.Newlabel(TxtBox);

            //Paso Numero
            ColorWork.NewboxNumber(FrameboxNumber);
            ColorWork.NewlabelNumber(TxtNumber);

            // Paso Flecha
            ColorWork.NewImage(ImageArrow);




        }

       
      

       

        private void TapColor(object sender, EventArgs e) => ColorWork.NewtapColor();
        private void TapName(object sender, EventArgs e) => ColorWork.NewtapName();
        private void TapNumber(object sender, EventArgs e) => ColorWork.NewtapNumber();
        private void TapImage(object sender, EventArgs e) => ColorWork.NewtapImage();

    }
}