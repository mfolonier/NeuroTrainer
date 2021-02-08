
using System.Collections.Generic;
using Xamarin.Forms;
using NeuroTrainer.Model;
using NeuroTrainer.Helper;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Threading;
using Plugin.TextToSpeech;


namespace NeuroTrainer.ViewModel
{
    public class ColorWork
    {

        static CancellationTokenSource tokenColor = new CancellationTokenSource();
        static CancellationTokenSource tokenName = new CancellationTokenSource();
        static CancellationTokenSource tokenNumber = new CancellationTokenSource();
        static CancellationTokenSource tokenImage = new CancellationTokenSource();

        public static void newtapColor()
        {



            tokenColor.Cancel();

        }
        public static void newtapName()
        {



            tokenName.Cancel();

        }
        public static void newtapNumber()
        {



            tokenNumber.Cancel();

        }
        public static void newtapImage()
        {



            tokenImage.Cancel();

        }

        static Frame _frameColor;
        public static void newboxColor(Frame frame)
        {
            _frameColor = new Frame();
            _frameColor = frame;
        }
        static Frame _frameName;
        public static void newboxName(Frame frame)
        {
            _frameName = new Frame();
            _frameName = frame;
        }

        static Frame _frameNumber;
        public static void newboxNumber(Frame frame)
        {
            _frameNumber = new Frame();
            _frameNumber = frame;
        }
        static Label _txt;
        public static void newlabel(Label txt)
        {
            _txt = new Label();
            _txt = txt;
        }
        static Label _txtNumber;


        public static void newlabelNumber(Label txt)
        {
            _txtNumber = new Label();
            _txtNumber = txt;
        }

        static Image _image;
        public static void newImage(Image image)
        {
            _image = new Image();
            _image = image;

        }
        public static bool Mix { get; set; }
        

        public static async Task ExColorWork(List<ColorPalet> list, int interval, int delay, bool speak)
        {

                
            _image.IsVisible = false;
            _frameName.IsVisible = false;
            _frameNumber.IsVisible = false;
            _frameColor.IsVisible = true;


            
            var repeat = interval / delay; ;
            var figuresnumbers = list.Count;
            int randomnumber;
            int k;

            if (Mix == false)
            {
                for (k = 0; k < repeat; k++)
                {
                    if (!ViewModel._runThread)
                        return;

                    tokenColor = new CancellationTokenSource();
                    randomnumber = RandomNum.RandomGenerate(figuresnumbers);
                    await _frameColor.FadeTo(0,100);
                    await _frameColor.FadeTo(1, 0);
                    _frameColor.BackgroundColor = list[randomnumber].BGColor;

                    if (speak == true)
                    {
                        if (ViewModel.numberlang == 1)
                            await CrossTextToSpeech.Current.Speak(list[randomnumber].NameColorEng);

                        if(ViewModel.numberlang == 2)
                            await CrossTextToSpeech.Current.Speak(list[randomnumber].NameColor);
                    }


                    Debug.WriteLine($"Color {k} es : {list[randomnumber].BGColor.ToString()}..... el numero es {randomnumber} //// ");
                    try
                    {

                        await Task.Delay(delay, tokenColor.Token);

                        tokenColor = new CancellationTokenSource();
                    }
                    catch (TaskCanceledException ex)
                    {
                        // Handle when task is cancelled.
                    }

                }

                _frameNumber.IsVisible = true;
                _frameColor.IsVisible = false;
                _txtNumber.TextColor = Color.White;
                _txtNumber.Scale = 5;
                if (ViewModel.numberlang == 1)
                    _txtNumber.Text = "REST";
                if (ViewModel.numberlang == 2)
                    _txtNumber.Text = "PARO";
            }
            else
            {
                
                tokenColor = new CancellationTokenSource();
                randomnumber = RandomNum.RandomGenerate(figuresnumbers);
                await _frameColor.FadeTo(0, 100);
                await _frameColor.FadeTo(1, 0);
                _frameColor.BackgroundColor = list[randomnumber].BGColor;
                if (speak == true)
                {
                    if (ViewModel.numberlang == 1)
                        await CrossTextToSpeech.Current.Speak(list[randomnumber].NameColorEng);

                    if (ViewModel.numberlang == 2)
                        await CrossTextToSpeech.Current.Speak(list[randomnumber].NameColor);
                }

                try
                {

                    await Task.Delay(delay, tokenColor.Token);

                    tokenColor = new CancellationTokenSource();
                }
                catch (TaskCanceledException ex)
                {
                    // Handle when task is cancelled.
                }
            }



        }
        public static async Task ExColorNameWork(List<ColorPalet> list, int interval, int delay, bool speak)
        {

            _image.IsVisible = false;
            _frameName.IsVisible = true;
            _frameNumber.IsVisible = false;
            _frameColor.IsVisible = false;

            var repeat = interval / delay;
            var numero = list.Count;
            int randomnumber;
            int j;

            if (Mix == false)
            {
                for (j = 0; j < repeat; j++)
                {
                    if (!ViewModel._runThread)
                        return;


                    tokenName = new CancellationTokenSource();
                    randomnumber = RandomNum.RandomGenerate(numero);
                    await _frameName.FadeTo(0, 100);
                    await _frameName.FadeTo(1, 0);
                    _frameName.BackgroundColor = list[randomnumber].BGColor;
                    _txt.Scale = 5;
                    _txt.TextColor = list[randomnumber].TxtColor;
                    if (ViewModel.numberlang == 1)
                    {
                        _txt.Text = list[randomnumber].TxtPaleteng;
                        
                    }

                    if (ViewModel.numberlang == 2) {

                        _txt.Text = list[randomnumber].TxtPalet;
                        
                    }
                       

                   

                    if (speak == true)
                    {
                        if (ViewModel.numberlang == 1)
                            await CrossTextToSpeech.Current.Speak(list[randomnumber].NameColorEng);

                        if (ViewModel.numberlang == 2)
                            await CrossTextToSpeech.Current.Speak(list[randomnumber].NameColor);
                    }
                       

                    Debug.WriteLine($"Color {j} es : {list[randomnumber].BGColor.ToString()} .... el numero es {randomnumber} //// ");
                    try
                    {

                        await Task.Delay(delay, tokenName.Token);

                        tokenName = new CancellationTokenSource();
                    }
                    catch (TaskCanceledException ex)
                    {
                        // Handle when task is cancelled.
                    }



                }
                _frameNumber.IsVisible = true;
                _frameName.IsVisible = false;
                _txtNumber.TextColor = Color.White;
                _txtNumber.Scale = 5;
                if (ViewModel.numberlang == 1)
                    _txtNumber.Text = "REST";
                if (ViewModel.numberlang == 2)
                    _txtNumber.Text = "PARO";
            }
            else
            {
                tokenName = new CancellationTokenSource();
                randomnumber = RandomNum.RandomGenerate(numero);
                await _frameName.FadeTo(0, 100);
                await _frameName.FadeTo(1, 0);
                _frameName.BackgroundColor = list[randomnumber].BGColor;
                _txt.Scale = 5;
               
                _txt.TextColor = list[randomnumber].TxtColor;

                if (ViewModel.numberlang == 1)
                {
                    _txt.Text = list[randomnumber].TxtPaleteng;

                }

                if (ViewModel.numberlang == 2)
                {

                    _txt.Text = list[randomnumber].TxtPalet;

                }




                if (speak == true)
                {
                    if (ViewModel.numberlang == 1)
                        await CrossTextToSpeech.Current.Speak(list[randomnumber].NameColorEng);

                    if (ViewModel.numberlang == 2)
                        await CrossTextToSpeech.Current.Speak(list[randomnumber].NameColor);
                }

                try
                {

                    await Task.Delay(delay, tokenName.Token);

                    tokenName = new CancellationTokenSource();
                }
                catch (TaskCanceledException ex)
                {
                    // Handle when task is cancelled.
                }

            }
        }



        public static async Task ExNumbers(string number, int interval, int delay, bool speak)
        {
            _image.IsVisible = false;
            _frameName.IsVisible = false;
            _frameNumber.IsVisible = true;
            _frameColor.IsVisible = false;

            var repeat = interval / delay;

            
            int numero = int.Parse(number);
            int randomnumber;
            int j;
            if (Mix == false)
            {
                for (j = 0; j < repeat; j++)
                {
                    if (!ViewModel._runThread)
                        return;
                    randomnumber = RandomNum.RandomGenerateWithoutZero(numero + 1);
                    tokenNumber = new CancellationTokenSource();
                    await _frameNumber.FadeTo(0, 100);
                    await _frameNumber.FadeTo(1, 0);
                    _txtNumber.TextColor = Color.White;
                    _txtNumber.Scale = 20;
                    _txtNumber.Text = randomnumber.ToString();

                    if (speak == true)
                        await CrossTextToSpeech.Current.Speak(randomnumber.ToString());

                    Debug.WriteLine($"En {j}  .... el numero es {randomnumber} //// ");


                    try
                    {

                        await Task.Delay(delay, tokenNumber.Token);

                        tokenNumber = new CancellationTokenSource();
                    }
                    catch (TaskCanceledException ex)
                    {
                        // Handle when task is cancelled.
                    }


                    _txt.Text = null;
                    await Task.Delay(delay / 100);

                }
                _txtNumber.Scale = 5;
                if (ViewModel.numberlang == 1)
                    _txtNumber.Text = "REST";
                if (ViewModel.numberlang == 2)
                    _txtNumber.Text = "PARO";
            }
            else
            {
                randomnumber = RandomNum.RandomGenerateWithoutZero(numero + 1);
                tokenNumber = new CancellationTokenSource();
                await _frameNumber.FadeTo(0, 100);
                await _frameNumber.FadeTo(1, 0);
                _txtNumber.TextColor = Color.White;
                _txtNumber.Scale = 20;
                _txtNumber.Text = randomnumber.ToString();

                if (speak == true)
                    await CrossTextToSpeech.Current.Speak(randomnumber.ToString());

                try
                {

                    await Task.Delay(delay, tokenNumber.Token);

                    tokenNumber = new CancellationTokenSource();
                }
                catch (TaskCanceledException ex)
                {
                    // Handle when task is cancelled.
                }


                _txt.Text = null;
                await Task.Delay(delay / 100);


            }

        }
        public static async Task ExArrows(int interval, int delay, bool speak)
        {

            _image.IsVisible = true;
            _frameName.IsVisible = false;
            _frameNumber.IsVisible = false;
            _frameColor.IsVisible = false;

            var repeat = interval / delay;

            int z;
            int randomnumber;

            if (Mix == false)
            {
                for (z = 0; z < repeat; z++)
                {
                    if (!ViewModel._runThread)
                        return;
                    tokenImage = new CancellationTokenSource();
                    randomnumber = RandomNum.RandomGenerateWithoutZero(7);
                    await _image.FadeTo(0, 100);
                    await _image.FadeTo(1, 0);
                    if (randomnumber == 1)
                    {
                        _image.Source = "Left.png";
                        if (speak == true)
                        {
                            if (ViewModel.numberlang == 1)
                            {
                                await CrossTextToSpeech.Current.Speak("Left");

                            }
                            if (ViewModel.numberlang == 2)
                            {
                                await CrossTextToSpeech.Current.Speak("Izquierda");

                            }

                        }
                            
                    }

                    if (randomnumber == 2)
                    {
                        _image.Source = "Right.png";
                        if (speak == true)
                        {
                            if (ViewModel.numberlang == 1)
                            {
                                await CrossTextToSpeech.Current.Speak("Right");

                            }
                            if (ViewModel.numberlang == 2)
                            {
                                await CrossTextToSpeech.Current.Speak("Derecha");

                            }

                        }
                    }

                    if (randomnumber == 3)
                    {
                        _image.Source = "Down.png";
                        if (speak == true)
                        {
                            if (ViewModel.numberlang == 1)
                            {
                                await CrossTextToSpeech.Current.Speak("Down");

                            }
                            if (ViewModel.numberlang == 2)
                            {
                                await CrossTextToSpeech.Current.Speak("Abajo");

                            }

                        }
                    }

                    if (randomnumber == 4)
                    {
                        _image.Source = "Up.png";
                        if (speak == true)
                        {
                            if (ViewModel.numberlang == 1)
                            {
                                await CrossTextToSpeech.Current.Speak("Up");

                            }
                            if (ViewModel.numberlang == 2)
                            {
                                await CrossTextToSpeech.Current.Speak("Arriba");

                            }

                        }
                    }

                    if (randomnumber == 5)
                    {
                        _image.Source = "DownUp.png";
                        if (speak == true)
                        {
                            if (ViewModel.numberlang == 1)
                            {
                                await CrossTextToSpeech.Current.Speak("Down Up");

                            }
                            if (ViewModel.numberlang == 2)
                            {
                                await CrossTextToSpeech.Current.Speak("Abajo Arriba");

                            }

                        }
                    }
                    if (randomnumber == 6)
                    {
                        _image.Source = "UpDown.png";
                        if (speak == true)
                        {
                            if (ViewModel.numberlang == 1)
                            {
                                await CrossTextToSpeech.Current.Speak("Up Down");

                            }
                            if (ViewModel.numberlang == 2)
                            {
                                await CrossTextToSpeech.Current.Speak("Arriba Abajo");

                            }

                        }
                    }

                    Debug.WriteLine($"En {z}  .... el numero es {randomnumber} //// ");


                    try
                    {

                        await Task.Delay(delay, tokenImage.Token);


                    }
                    catch (TaskCanceledException ex)
                    {
                        // Handle when task is cancelled.
                    }

                }

                _image.IsVisible = false;
                _frameNumber.IsVisible = true;
                _txtNumber.TextColor = Color.White;
                _txtNumber.Scale =5;
                if (ViewModel.numberlang == 1)
                    _txtNumber.Text = "REST";
                if (ViewModel.numberlang == 2)
                    _txtNumber.Text = "PARO";
            }
            else
            {
                tokenImage = new CancellationTokenSource();
                randomnumber = RandomNum.RandomGenerateWithoutZero(7);
                await _image.FadeTo(0, 100);
                await _image.FadeTo(1, 0);
                if (randomnumber == 1)
                {
                    _image.Source = "Left.png";
                    if (speak == true)
                    {
                        if (ViewModel.numberlang == 1)
                        {
                            await CrossTextToSpeech.Current.Speak("Left");

                        }
                        if (ViewModel.numberlang == 2)
                        {
                            await CrossTextToSpeech.Current.Speak("Izquierda");

                        }

                    }

                }

                if (randomnumber == 2)
                {
                    _image.Source = "Right.png";
                    if (speak == true)
                    {
                        if (ViewModel.numberlang == 1)
                        {
                            await CrossTextToSpeech.Current.Speak("Right");

                        }
                        if (ViewModel.numberlang == 2)
                        {
                            await CrossTextToSpeech.Current.Speak("Derecha");

                        }

                    }
                }

                if (randomnumber == 3)
                {
                    _image.Source = "Down.png";
                    if (speak == true)
                    {
                        if (ViewModel.numberlang == 1)
                        {
                            await CrossTextToSpeech.Current.Speak("Down");

                        }
                        if (ViewModel.numberlang == 2)
                        {
                            await CrossTextToSpeech.Current.Speak("Abajo");

                        }

                    }
                }

                if (randomnumber == 4)
                {
                    _image.Source = "Up.png";
                    if (speak == true)
                    {
                        if (ViewModel.numberlang == 1)
                        {
                            await CrossTextToSpeech.Current.Speak("Up");

                        }
                        if (ViewModel.numberlang == 2)
                        {
                            await CrossTextToSpeech.Current.Speak("Arriba");

                        }

                    }
                }

                if (randomnumber == 5)
                {
                    _image.Source = "DownUp.png";
                    if (speak == true)
                    {
                        if (ViewModel.numberlang == 1)
                        {
                            await CrossTextToSpeech.Current.Speak("Down Up");

                        }
                        if (ViewModel.numberlang == 2)
                        {
                            await CrossTextToSpeech.Current.Speak("Abajo Arriba");

                        }

                    }
                }
                if (randomnumber == 6)
                {
                    _image.Source = "UpDown.png";
                    if (speak == true)
                    {
                        if (ViewModel.numberlang == 1)
                        {
                            await CrossTextToSpeech.Current.Speak("Up Down");

                        }
                        if (ViewModel.numberlang == 2)
                        {
                            await CrossTextToSpeech.Current.Speak("Arriba Abajo");

                        }

                    }
                }

                try
                {

                    await Task.Delay(delay, tokenImage.Token);


                }
                catch (TaskCanceledException ex)
                {
                    // Handle when task is cancelled.
                }


            }
        }

        public static async Task ExVocals(int interval, int delay, bool speak)
        {

            _image.IsVisible = false;
            _frameName.IsVisible = false;
            _frameNumber.IsVisible = true;
            _frameColor.IsVisible = false;

            var repeat = interval / delay;
            

            int numberrand;
            List<string> vocal = new List<string>() { "A", "E", "I", "O", "U" };
            int j;
            if (Mix == false)
            {
                for (j = 0; j < repeat; j++)
                {
                    if (!ViewModel._runThread)
                        return;
                    tokenNumber = new CancellationTokenSource();
                    numberrand = RandomNum.RandomGenerateWithoutZero(6);
                    await _frameNumber.FadeTo(0, 100);
                    await _frameNumber.FadeTo(1, 0);
                    _txtNumber.TextColor = Color.White;
                    _txtNumber.Scale = 20;
                    if (numberrand == 1)
                    {

                        _txtNumber.Text = vocal[numberrand - 1];

                    }
                    if (numberrand == 2)
                    {

                        _txtNumber.Text = vocal[numberrand - 1];

                    }
                    if (numberrand == 3)
                    {

                        _txtNumber.Text = vocal[numberrand - 1];

                    }
                    if (numberrand == 4)
                    {

                        _txtNumber.Text = vocal[numberrand - 1];

                    }
                    if (numberrand == 5)
                    {
                        _txtNumber.Text = vocal[numberrand - 1];

                    }

                    if (speak == true)
                        await CrossTextToSpeech.Current.Speak(vocal[numberrand - 1]);


                    Debug.WriteLine($"En {j}  .... La vocal es {vocal[numberrand - 1]} //// ");

                    try
                    {

                        await Task.Delay(delay, tokenNumber.Token);

                        tokenNumber = new CancellationTokenSource();
                    }
                    catch (TaskCanceledException ex)
                    {
                        // Handle when task is cancelled.
                    }


                    _txt.Text = null;
                    await Task.Delay(delay / 100);


                }
                _txtNumber.Scale = 5;
                if (ViewModel.numberlang == 1)
                    _txtNumber.Text = "REST";
                if (ViewModel.numberlang == 2)
                    _txtNumber.Text = "PARO";
            }
            else
            {
                tokenNumber = new CancellationTokenSource();
                numberrand = RandomNum.RandomGenerateWithoutZero(6);
                await _frameNumber.FadeTo(0, 100);
                await _frameNumber.FadeTo(1, 0);
                _txtNumber.TextColor = Color.White;
                _txtNumber.Scale = 20;
                if (numberrand == 1)
                {

                    _txtNumber.Text = vocal[numberrand - 1];

                }
                if (numberrand == 2)
                {

                    _txtNumber.Text = vocal[numberrand - 1];

                }
                if (numberrand == 3)
                {

                    _txtNumber.Text = vocal[numberrand - 1];

                }
                if (numberrand == 4)
                {

                    _txtNumber.Text = vocal[numberrand - 1];

                }
                if (numberrand == 5)
                {
                    _txtNumber.Text = vocal[numberrand - 1];

                }

                if (speak == true)
                    await CrossTextToSpeech.Current.Speak(vocal[numberrand - 1]);

                try
                {

                    await Task.Delay(delay, tokenNumber.Token);

                    tokenNumber = new CancellationTokenSource();
                }
                catch (TaskCanceledException ex)
                {
                    // Handle when task is cancelled.
                }

            }
        }

        public static async Task ExMix(List<ColorPalet> list, int interval, int delay, bool speak, string number)
        {
            Mix = true;
            var repeat = interval / delay;
            int NumberRand;
            int j;
            for (j = 0; j < repeat; j++)
            {
                if (!ViewModel._runThread)
                    return;
                NumberRand = RandomNum.RandomGenerateWithoutZero(6);

                if (NumberRand == 1)
                {

                    await ExColorWork(list, interval, delay, speak);

                }

                if (NumberRand == 2)
                {

                    await ExColorNameWork(list, interval, delay, speak);

                }

                if (NumberRand == 3)
                {

                    await ExNumbers(number, interval, delay, speak);

                }

                if (NumberRand == 4)
                {

                    await ExArrows(interval, delay, speak);

                }

                if (NumberRand == 5)
                {

                    await ExVocals(interval, delay, speak);

                }


                Debug.WriteLine($"En {j}  .... el numero en Mixto es {NumberRand} //// ");
            }

            Mix = false;
            _image.IsVisible = false;
            _frameColor.IsVisible = false;
            _frameName.IsVisible = false;
            _frameNumber.IsVisible = true;
            _txtNumber.TextColor = Color.White;
            _txtNumber.Scale = 5;
            if (ViewModel.numberlang == 1)
                _txtNumber.Text = "REST";
            if (ViewModel.numberlang == 2)
                _txtNumber.Text = "PARO";


        }

    }
}
