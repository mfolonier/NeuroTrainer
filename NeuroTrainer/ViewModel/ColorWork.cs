
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

        public static void NewtapColor()
        {



            tokenColor.Cancel();

        }
        public static void NewtapName()
        {



            tokenName.Cancel();

        }
        public static void NewtapNumber()
        {



            tokenNumber.Cancel();

        }
        public static void NewtapImage()
        {



            tokenImage.Cancel();

        }

        static Frame _frameColor;
        public static void NewboxColor(Frame frame)
        {
            _frameColor = new Frame();
            _frameColor = frame;
        }
        static Frame _frameName;
        public static void NewboxName(Frame frame)
        {
            _frameName = new Frame();
            _frameName = frame;
        }

        static Frame _frameNumber;
        public static void NewboxNumber(Frame frame)
        {
            _frameNumber = new Frame();
            _frameNumber = frame;
        }
        static Label _txt;
        public static void Newlabel(Label txt)
        {
            _txt = new Label();
            _txt = txt;
        }
        static Label _txtNumber;


        public static void NewlabelNumber(Label txt)
        {
            _txtNumber = new Label();
            _txtNumber = txt;
        }

        static Image _image;
        public static void NewImage(Image image)
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

            
            int milliseconds = interval - (int)((double)delay * 1.05);
            var index = list.Count;
            int randomnumber;
          

            if (Mix == false)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();

                while (sw.Elapsed.TotalMilliseconds <= milliseconds)
                {
                    if (!ViewModel.RunThread)
                        return;

                    tokenColor = new CancellationTokenSource();
                    randomnumber = RandomNum.RandomGenerate(index);
                    await _frameColor.FadeTo(0,100);
                    await _frameColor.FadeTo(1, 0);
                    _frameColor.BackgroundColor = list[randomnumber].BGColor;

                    if (speak == true)
                    {
                        if (ViewModel.numberlang == 1)
                            _= CrossTextToSpeech.Current.Speak(list[randomnumber].NameColorEng);

                        if(ViewModel.numberlang == 2)
                            _= CrossTextToSpeech.Current.Speak(list[randomnumber].NameColor);
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
                if ((interval - (int)sw.Elapsed.TotalMilliseconds) > 0)
                {
                    await Task.Delay((interval - (int)sw.Elapsed.TotalMilliseconds));
                }
                sw.Stop();

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
                randomnumber = RandomNum.RandomGenerate(index);
                await _frameColor.FadeTo(0, 100);
                await _frameColor.FadeTo(1, 0);
                _frameColor.BackgroundColor = list[randomnumber].BGColor;
                if (speak == true)
                {
                    if (ViewModel.numberlang == 1)
                        _= CrossTextToSpeech.Current.Speak(list[randomnumber].NameColorEng);

                    if (ViewModel.numberlang == 2)
                        _= CrossTextToSpeech.Current.Speak(list[randomnumber].NameColor);
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

            int milliseconds = interval - (int)((double)delay * 1.05);
            var numero = list.Count;
            int randomnumber;
            

            if (Mix == false)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();

                while (sw.Elapsed.TotalMilliseconds <= milliseconds)
                {
                    if (!ViewModel.RunThread)
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
                            _= CrossTextToSpeech.Current.Speak(list[randomnumber].NameColorEng);

                        if (ViewModel.numberlang == 2)
                            _= CrossTextToSpeech.Current.Speak(list[randomnumber].NameColor);
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

                if ((interval - (int)sw.Elapsed.TotalMilliseconds) > 0)
                {
                    await Task.Delay((interval - (int)sw.Elapsed.TotalMilliseconds));
                }

                sw.Stop();


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
                        _= CrossTextToSpeech.Current.Speak(list[randomnumber].NameColorEng);

                    if (ViewModel.numberlang == 2)
                        _= CrossTextToSpeech.Current.Speak(list[randomnumber].NameColor);
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

            int milliseconds = interval - (int)((double)delay * 1.05);


            int numero = int.Parse(number);
            int randomnumber;
           
            if (Mix == false)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();

                while (sw.Elapsed.TotalMilliseconds <= milliseconds)
                {
                    if (!ViewModel.RunThread)
                        return;
                    randomnumber = RandomNum.RandomGenerateWithoutZero(numero + 1);
                    tokenNumber = new CancellationTokenSource();
                    await _frameNumber.FadeTo(0, 100);
                    await _frameNumber.FadeTo(1, 0);
                    _txtNumber.TextColor = Color.White;
                    _txtNumber.Scale = 20;
                    _txtNumber.Text = randomnumber.ToString();

                    if (speak == true)
                        _= CrossTextToSpeech.Current.Speak(randomnumber.ToString());
                    
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
                if ((interval - (int)sw.Elapsed.TotalMilliseconds) > 0)
                {
                    await Task.Delay((interval - (int)sw.Elapsed.TotalMilliseconds));
                }

                sw.Stop();

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
                    _= CrossTextToSpeech.Current.Speak(randomnumber.ToString());

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
        public static async Task ExArrows(int interval, int delay, bool speak)
        {

            _image.IsVisible = true;
            _frameName.IsVisible = false;
            _frameNumber.IsVisible = false;
            _frameColor.IsVisible = false;

            int milliseconds = interval - (int)((double) delay * 1.05);
            int randomnumber;

            if (Mix == false)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();

                while (sw.Elapsed.TotalMilliseconds <= milliseconds)
                {
                    Debug.WriteLine("1." + (sw.Elapsed.TotalMilliseconds).ToString());
                    if (!ViewModel.RunThread)
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
                                _ = CrossTextToSpeech.Current.Speak("Left");

                            }
                            if (ViewModel.numberlang == 2)
                            {
                                _ = CrossTextToSpeech.Current.Speak("Izquierda");

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
                                _ =  CrossTextToSpeech.Current.Speak("Right");

                            }
                            if (ViewModel.numberlang == 2)
                            {
                                _ = CrossTextToSpeech.Current.Speak("Derecha");

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
                                _ = CrossTextToSpeech.Current.Speak("Down");

                            }
                            if (ViewModel.numberlang == 2)
                            {
                                _ = CrossTextToSpeech.Current.Speak("Abajo");

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
                                _ = CrossTextToSpeech.Current.Speak("Up");

                            }
                            if (ViewModel.numberlang == 2)
                            {
                                _ = CrossTextToSpeech.Current.Speak("Arriba");

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
                                _ = CrossTextToSpeech.Current.Speak("Down Up");

                            }
                            if (ViewModel.numberlang == 2)
                            {
                                _ = CrossTextToSpeech.Current.Speak("Abajo Arriba");

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
                                _ = CrossTextToSpeech.Current.Speak("Up Down");

                            }
                            if (ViewModel.numberlang == 2)
                            {
                                _ = CrossTextToSpeech.Current.Speak("Arriba Abajo");

                            }

                        }
                    }
                    Debug.WriteLine("2." + (sw.Elapsed.TotalMilliseconds).ToString());

                    try
                    {

                        await Task.Delay(delay, tokenImage.Token);


                    }
                    catch (TaskCanceledException ex)
                    {
                        // Handle when task is cancelled.
                    }

                }
                Debug.WriteLine((interval - (int)sw.Elapsed.TotalMilliseconds).ToString());

                if ((interval - (int)sw.Elapsed.TotalMilliseconds) > 0)
                {
                    await Task.Delay((interval - (int)sw.Elapsed.TotalMilliseconds));
                }
                
                sw.Stop();

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

            int milliseconds = interval - (int)((double)delay * 1.05);


            int numberrand;
            List<string> vocal = new List<string>() { "A", "E", "I", "O", "U" };
          
            if (Mix == false)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();

                while (sw.Elapsed.TotalMilliseconds <= milliseconds)
                {
                    if (!ViewModel.RunThread)
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
                        _= CrossTextToSpeech.Current.Speak(vocal[numberrand - 1]);


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

                if ((interval - (int)sw.Elapsed.TotalMilliseconds) > 0)
                {
                    await Task.Delay((interval - (int)sw.Elapsed.TotalMilliseconds));
                }

                sw.Stop();


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
                    _= CrossTextToSpeech.Current.Speak(vocal[numberrand - 1]);

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

            int milliseconds = interval - (int)((double)delay * 1.05);
            int NumberRand;

            Stopwatch sw = new Stopwatch();
            sw.Start();

            while (sw.Elapsed.TotalMilliseconds <= milliseconds)
            {
                if (!ViewModel.RunThread)
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


          
            }

            if ((interval - (int)sw.Elapsed.TotalMilliseconds) > 0)
            {
                await Task.Delay((interval - (int)sw.Elapsed.TotalMilliseconds));
            }

            sw.Stop();

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
