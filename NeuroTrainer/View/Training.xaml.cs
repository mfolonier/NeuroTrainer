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
            ColorWork.newboxColor(FrameboxColor);

            // Paso Color y nombre 
            ColorWork.newboxName(FrameboxName);
            ColorWork.newlabel(TxtBox);

            //Paso Numero
            ColorWork.newboxNumber(FrameboxNumber);
            ColorWork.newlabelNumber(TxtNumber);

            // Paso Flecha
            ColorWork.newImage(ImageArrow);




        }

       
      

       

        private void TapColor(object sender, EventArgs e) => ColorWork.newtapColor();
        private void TapName(object sender, EventArgs e) => ColorWork.newtapName();
        private void TapNumber(object sender, EventArgs e) => ColorWork.newtapNumber();
        private void TapImage(object sender, EventArgs e) => ColorWork.newtapImage();

    }
}