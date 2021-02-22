using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using NeuroTrainer.Model;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace NeuroTrainer.ViewModel
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        // init text to change language 
        public static int numberlang = 1;
       
        private string _TxtOpt;
        public string TxtOpt { 
            get
            {

                return _TxtOpt;
            }

            set
            {
                _TxtOpt = value;
                OnPropertyChanged("");

            }
               
        }
       
        private string _EmptyList;
        public string EmptyList
        {
            get
            {

                return _EmptyList;
            }

            set
            {
                _EmptyList = value;
                OnPropertyChanged("");

            }

        }
        private string _Txtinterval;
        public string Txtinterval
        {
            get
            {

                return _Txtinterval;
            }

            set
            {
                _Txtinterval = value;
                OnPropertyChanged("");

            }

        }

        private string _BtnAddtxt;
        public string BtnAddtxt
        {
            get
            {

                return _BtnAddtxt;
            }

            set
            {
                _BtnAddtxt = value;
                OnPropertyChanged("");

            }

        }

        private string _BtnSettxt;
        public string BtnSettxt
        {
            get
            {

                return _BtnSettxt;
            }

            set
            {
                _BtnSettxt = value;
                OnPropertyChanged("");

            }

        }

        private string _BtnStarttxt;
        public string BtnStarttxt
        {
            get
            {

                return _BtnStarttxt;
            }

            set
            {
                _BtnStarttxt = value;
                OnPropertyChanged("");

            }

        }
        private string _Txtrest;
        public string Textrest
        {
            get
            {

                return _Txtrest;
            }

            set
            {
                _Txtrest = value;
                OnPropertyChanged("");

            }

        }
        private string _Txtdelay;
        public string Txtdelay
        {
            get
            {

                return _Txtdelay;
            }

            set
            {
                _Txtdelay = value;
                OnPropertyChanged("");

            }

        }
        private string _Txtround;
        public string Txtround
        {
            get
            {

                return _Txtround;
            }

            set
            {
                _Txtround = value;
                OnPropertyChanged("");

            }

        }

        private string _Txtnumber;
        public string Txtnumber
        {
            get
            {

                return _Txtnumber;
            }

            set
            {
                _Txtnumber = value;
                OnPropertyChanged("");

            }

        }

        private string _Txtsound;
        public string Txtsound
        {
            get
            {

                return _Txtsound;
            }

            set
            {
                _Txtsound = value;
                OnPropertyChanged("");

            }

        }

        private string _Txttime;
        public string Txttime
        {
            get
            {

                return _Txttime;
            }

            set
            {
                _Txttime = value;
                OnPropertyChanged("");

            }

        }
        private string _TxtPicker;
        public string TxtPicker
        {
            get
            {

                return _TxtPicker;
            }

            set
            {
                _TxtPicker = value;
                OnPropertyChanged("");

            }

        }
        private string _TxtPickerColor;
        public string TxtPickerColor
        {
            get
            {

                return _TxtPickerColor;
            }

            set
            {
                _TxtPickerColor = value;
                OnPropertyChanged("");

            }

        }

        // finish txt to change language 

        
        private ImageSource _lngicon; // to change language icon

           public ImageSource Lngicon {

               get
               {

                   return _lngicon;
               }

               set
               {
                   _lngicon = value;
                   OnPropertyChanged("");

               }

           }

          private Command _lngSelect;  // language select 
          public Command Lngselect
          {
              get
              {
                  _lngSelect = new Command( () => {

                      if(numberlang == 1 && (SelectedMode == null && SelectedColor == null))
                      {
                          numberlang = 2;
                          Debug.WriteLine($"Numerolang = {numberlang}");
                          Lngicon = "ESP.png";

                      }
                      else if (SelectedMode == null && SelectedColor== null)
                      {
                          numberlang = 1;
                          Debug.WriteLine($"Numerolang = {numberlang}");
                          Lngicon = "ENG.png";
                      }

                      Languages();

                  } );
                  return _lngSelect;
              }
          }

        private Command _cmdStart;  // init traingin 
        public Command CmdStart
        {
            get
            {
                _cmdStart = new Command(async () => await DisplayFunction());

                return _cmdStart;
            }

        }

        private Command _CmdAdd;  // add seting 
        public Command CmdAdd
        {
            get
            {
                _CmdAdd = new Command(async () => await LoadListAsync());




                return _CmdAdd;
            }

        }
        private Command _CmdClear; // cleat setting 
        public Command CmdClear
        {
            get
            {
                _CmdClear = new Command(ClearList);




                return _CmdClear;
            }

        }

        private bool Config { get; set; } // config color list 
        public static bool RunThread { get; set; } // to back page 


        private ObservableCollection<Modos> _setlist;  // list of works 
        public ObservableCollection<Modos> Setlist {

            get 
            {

                return _setlist;
            }
            
            set
            {
                _setlist = value;
                OnPropertyChanged("");
            }
                
        }
        public List<ListWork> ModesList { get; set; }   //

        private List<ColorPalet> _colorlist;  //
        public List<ColorPalet> ColorList
        {
            get
            {
                return _colorlist;
            }
            set
            {
                if (_colorlist != value)
                {
                    _colorlist = value;
                    OnPropertyChanged("");
                }

            }
        }
        public List<ColorPalet> SelectedColorList { get; set; }  // selected color to work 

        private ObservableCollection<ColorPalet> _ColorSelected;   // to show color in the listview with XAML 
        public ObservableCollection<ColorPalet> ColorSelected
        {
            get
            {
                return _ColorSelected;
            }
            set
            {
                if (_ColorSelected != value)
                {
                    _ColorSelected = value;
                    OnPropertyChanged("ColorSelected");
                }

            }
        }



        private string _Mymode;
        public string Mymode
        {
            get
            {
                return _Mymode;
            }
            set
            {
                _Mymode = value;
                OnPropertyChanged();

            }

        }
        private string _Interval;
        public string Interval
        {
            get => _Interval;
            set
            {
                if (_Interval != value)
                {
                    _Interval = value;
                    OnPropertyChanged();
                }

            }
        }

        private string _Rounds;
        public string Rounds
        {
            get => _Rounds;
            set
            {
                if (_Rounds != value)
                {
                    _Rounds = value;
                    OnPropertyChanged();
                }

            }
        }
        private string _Rest;
        public string Rest
        {
            get => _Rest;
            set
            {
                if (_Rest != value)
                {
                    _Rest = value;
                    OnPropertyChanged();
                }

            }
        }

        private string _Number;
        public string Number
        {
            get => _Number;
            set
            {
                if (_Number != value)
                {
                    _Number = value;
                    OnPropertyChanged();
                }

            }
        }

        private string _Delay;
        public string Delay
        {
            get => _Delay;
            set
            {
                if (_Delay != value)
                {
                    _Delay = value;
                    OnPropertyChanged();
                }

            }
        }


        static bool StateSwitch;
        public static void TheSwitchState(bool state)
        {
            StateSwitch = new bool();
            StateSwitch = state;
            
        }

        private int _TimeWork;
        public int TimeWork
        {
            get => _TimeWork;
            set
            {
                if (_TimeWork != value)
                {
                    _TimeWork = value;
                    OnPropertyChanged();
                }

            }
        }
        private string _TimeWorkstring;
        public string TimeWorkString
        {
            get => _TimeWorkstring;
            set
            {
                if (_TimeWorkstring != value)
                {
                    _TimeWorkstring = value;
                    OnPropertyChanged();
                }

            }
        }

        private Modos _SelectedMode;
        public Modos SelectedMode
        {
            get
            {
                return _SelectedMode;

            }
            set
            {
                if (_SelectedMode != value)
                {
                    _SelectedMode = value;
                    OnPropertyChanged("");
                    Mymode = SelectedMode.Type;

                }
            }

        }
        private ColorPalet _colordelete;
        public ColorPalet Colordelete
        {
            get
            {
                return _colordelete;
            }
            set
            {
                _colordelete = value;
                OnPropertyChanged("Colordelete");
            }
        }

        private ColorPalet _SelectedColor;
        public ColorPalet SelectedColor
        {
            get
            {
                return _SelectedColor;
            }
            set
            {
                if (_SelectedColor != value)
                {
                    _SelectedColor = value;
                    OnPropertyChanged();
                    Config = true;
                    ColorSelected.Add(new ColorPalet() { BGColor = SelectedColor.BGColor, NameColor = SelectedColor.NameColor, TxtColor = SelectedColor.TxtColor, TxtColorName = SelectedColor.TxtColorName, TxtPalet = SelectedColor.TxtPalet, NameColorEng= SelectedColor.NameColorEng, TxtColorNameEng= SelectedColor.TxtColorNameEng , TxtPaleteng = SelectedColor.TxtPaleteng , TxtList = SelectedColor.TxtList});


                    foreach (ColorPalet list in ColorSelected)
                    {
                        Debug.WriteLine($"Se selecciona el color : {list.NameColor} //// ");

                    }

                }

            }
        }

        private Command _removeColor;  // not use
        public Command RemoveColor
        {

            get
            {
                _removeColor = new Command(() => Debug.WriteLine($"Se ELIMINA  el color {Colordelete.NameColor} //// "));
                return _removeColor;
            }
        }


        public TimeSpan TimeCollect { get; set; }

        public ViewModel()
        {
            Setlist = new ObservableCollection<Modos>() {
                new Modos(){ Key = 1 ,  Type = "Arrow"},
                new Modos(){ Key = 2 ,  Type = "Numbers"},
                new Modos(){ Key = 3 ,  Type = "Colors"},
                new Modos(){ Key = 4 ,  Type = "Colors & Words"},
                new Modos(){ Key = 5 , Type = "Vocals" },
                new Modos(){ Key = 6 , Type = "Mix"}

             };
            ColorList = new List<ColorPalet>()
            {
                            new ColorPalet(){ BGColor = Color.Red,NameColor = "Rojo" , TxtColor = Color.Blue , TxtColorName = "Azul" ,TxtPalet = "Amarillo",NameColorEng ="Red" , TxtColorNameEng = "Blue", TxtPaleteng = "Yellow", TxtList = "Red"},
                            new ColorPalet(){ BGColor = Color.Green, NameColor = "Verde" ,TxtColor = Color.Purple, TxtColorName = "Violeta" , TxtPalet = "Violeta" , NameColorEng ="Green" , TxtColorNameEng = "Purple", TxtPaleteng = "Purple" , TxtList = "Green"},
                            new ColorPalet(){ BGColor = Color.Blue , NameColor = "Azul" ,TxtColor = Color.Purple , TxtColorName = "Violeta" ,TxtPalet = "Negro",NameColorEng ="Blue" , TxtColorNameEng = "Purple", TxtPaleteng = "Black" , TxtList ="Blue" },
                            new ColorPalet(){ BGColor = Color.Yellow, NameColor = "Amarillo" ,TxtColor = Color.Purple , TxtColorName = "Violeta" ,TxtPalet = "Verde",NameColorEng ="Yellow" , TxtColorNameEng = "Purple", TxtPaleteng = "Green", TxtList = "Yellow"},
                            new ColorPalet(){ BGColor = Color.Orange, NameColor = "Naranja" ,TxtColor = Color.Gray , TxtColorName = "Gris" ,TxtPalet = "Rosa",NameColorEng ="Orange" , TxtColorNameEng = "Gray", TxtPaleteng = "Pink", TxtList = "Orange"},
                            new ColorPalet(){ BGColor = Color.DarkViolet, NameColor = "Violeta" ,TxtColor = Color.Blue ,TxtColorName = "Azul" , TxtPalet = "Naranja",NameColorEng ="Violet" , TxtColorNameEng = "Blue", TxtPaleteng = "Orange" , TxtList = "Violet"},
                            new ColorPalet(){ BGColor = Color.Fuchsia, NameColor = "Fucsia" ,TxtColor = Color.Yellow ,TxtColorName = "Amarillo" , TxtPalet = "Azul",NameColorEng ="Fuchsia" , TxtColorNameEng = "Yellow", TxtPaleteng = "Blue", TxtList = "Fuchsia"},
                            new ColorPalet(){ BGColor = Color.Purple, NameColor = "Púrpura" ,TxtColor = Color.Black ,TxtColorName = "Negro" , TxtPalet = "Gris",NameColorEng ="Purple" , TxtColorNameEng = "Black", TxtPaleteng = "Gray", TxtList = "Purple"},
                            new ColorPalet(){ BGColor = Color.LightBlue, NameColor = "Celeste" ,TxtColor = Color.Orange ,TxtColorName = "Naranja" , TxtPalet = "Blanco",NameColorEng ="Light Blue" , TxtColorNameEng = "Orange", TxtPaleteng = "White" , TxtList = "Light Blue"},
                            new ColorPalet(){ BGColor = Color.Gray, NameColor = "Gris" ,TxtColor = Color.Green ,TxtColorName = "Verde" , TxtPalet = "Fucsia",NameColorEng ="Gray" , TxtColorNameEng = "Green", TxtPaleteng = "Fuchsia" , TxtList = "Gray"},
                            new ColorPalet(){ BGColor = Color.Black, NameColor = "Negro" ,TxtColor = Color.White ,TxtColorName = "Blanco" , TxtPalet = "Rojo",NameColorEng ="Black" , TxtColorNameEng = "White", TxtPaleteng = "Red", TxtList = "Black"},
                            new ColorPalet(){ BGColor = Color.White, NameColor = "Blanco" ,TxtColor = Color.Red , TxtColorName = "Rojo" , TxtPalet = "Celeste"  ,NameColorEng ="White" , TxtColorNameEng = "Red", TxtPaleteng = "Light Blue" , TxtList ="White"}
            };
           
            ModesList = new List<ListWork>();
            SelectedColorList = new List<ColorPalet>();
            ColorSelected = new ObservableCollection<ColorPalet>();
            TimeCollect = new TimeSpan(0, 0, 0);
            TimeWorkString = TimeCollect.ToString(@"hh\:mm\:ss");
            Config = false;
            ColorWork.Mix = false;
            /// Language default configuration equal English
            /// 
            Lngicon = "ENG.png";
            TxtOpt = "Options";
            TxtPicker = " --Select Work-- ";
            TxtPickerColor = "--Select Color--";
            EmptyList = "Empty list";
            Txtinterval = "Working Time";
            Textrest = "Rest";
            Txtdelay = "Delay";
            Txtround = "Rounds";
            Txtnumber = "Max. Number";
            Txtsound = "Sound";
            Txttime = "Total Time:";
            BtnAddtxt = "ADD SETTING";
            BtnSettxt = "CLEAR  SETTING";
            BtnStarttxt = "START";

        }

        public async Task LoadListAsync()
        {
            int i; 
            TimeCollect = new TimeSpan(0, 0, 0);
            try
            {
                if (Int32.Parse(Delay) > Int32.Parse(Interval))
                {
                    await App.Current.MainPage.DisplayAlert("Error!", "Invalid Delay", "OK");
                }
                else
                {



                    ModesList.Add(new ListWork()
                    {

                        Time = Int32.Parse(Interval) * 1000,
                        Rests = Int32.Parse(Rest) * 1000,
                        Delay = Int32.Parse(Delay) * 1000,
                        Time2 = TimeSpan.FromSeconds(Double.Parse(Interval)),
                        Rests2 = TimeSpan.FromSeconds(Double.Parse(Rest)),
                        Delay2 = TimeSpan.FromSeconds(Double.Parse(Delay)),
                        Value = Mymode,
                        SwitchState = StateSwitch
                    }
                      );

                    if (Interval != null && Rest != null)
                    {
                     
                        foreach (ListWork list in ModesList)
                        {
                            for (i = 0; i < int.Parse(Rounds); i++)
                            {
                                TimeCollect += list.Time2;
                                TimeCollect += list.Rests2;
                            }

                        }
                        TimeWorkString = TimeCollect.ToString(@"hh\:mm\:ss");
                    }



                    foreach (ListWork list in ModesList)
                    {
                        Debug.WriteLine($"Lista tiene: {list.Time}  Work time//// ");
                        Debug.WriteLine($"Lista tiene: {list.Rests} Rest //// ");
                        Debug.WriteLine($"Lista tiene: {list.Delay} Delay //// ");
                        Debug.WriteLine($"Lista tiene: {list.Value}  Work//// ");


                        Debug.WriteLine($"Lista tiene el switch en estado: {list.SwitchState} //// ");

                    }


                }
            }
            catch
            {

            }

        }

        public  void ClearList()
        {

          

            if (ModesList != null)
            {
                ModesList.Clear();

            }
            if (ColorSelected != null)
            {
                ColorSelected.Clear();
            }


            TimeCollect = new TimeSpan(0, 0, 0);
            TimeWorkString = TimeCollect.ToString(@"hh\:mm\:ss");
            Interval = "";
            Delay = "";
            Rest = "";
            Number = "";
            Rounds = "";
            Config = false;
            if(SelectedColorList != null)
            SelectedColorList.Clear();

           


        }

        
        public async void Languages()
        {
            
            /// falta poner un if si las configuraciones estan vacías dejar cambiar lenguaje, sino mensaje para indicar que no se puede. 
            if (SelectedMode == null && SelectedColor == null) { 
                switch (numberlang)
                {
                    case 1:
                        TxtOpt = "Options";
                        TxtPicker = "--Select Work--";
                        TxtPickerColor = "--Select Color--";
                        EmptyList = "Empty list";
                        Txtinterval = "Working Time";
                        Textrest = "Rest";
                        Txtdelay = "Delay";
                        Txtround = "Rounds";
                        Txtnumber = "Max. Number";
                        Txtsound = "Sound";
                        Txttime = "Total time:";
                        BtnAddtxt = "ADD SETTING";
                        BtnSettxt = "CLEAR  SETTING";
                        BtnStarttxt = "START";

                        Setlist = new ObservableCollection<Modos>() {
                        new Modos(){ Key = 1 ,  Type = "Arrow"},
                        new Modos(){ Key = 2 ,  Type = "Numbers"},
                        new Modos(){ Key = 3 ,  Type = "Colors"},
                        new Modos(){ Key = 4 ,  Type = "Colors & Words"},
                        new Modos(){Key = 5 , Type = "Vocals" },
                        new Modos(){Key = 6 , Type = "Mix"}

                          };
                        ColorList = new List<ColorPalet>()
                        {
                            new ColorPalet(){ BGColor = Color.Red,NameColor = "Rojo" , TxtColor = Color.Blue , TxtColorName = "Azul" ,TxtPalet = "Amarillo",NameColorEng ="Red" , TxtColorNameEng = "Blue", TxtPaleteng = "Yellow", TxtList = "Red"},
                            new ColorPalet(){ BGColor = Color.Green, NameColor = "Verde" ,TxtColor = Color.Purple, TxtColorName = "Violeta" , TxtPalet = "Violeta" , NameColorEng ="Green" , TxtColorNameEng = "Purple", TxtPaleteng = "Purple" , TxtList = "Green"},                            
                            new ColorPalet(){ BGColor = Color.Blue , NameColor = "Azul" ,TxtColor = Color.Purple , TxtColorName = "Violeta" ,TxtPalet = "Negro",NameColorEng ="Blue" , TxtColorNameEng = "Purple", TxtPaleteng = "Black" , TxtList ="Blue" },
                            new ColorPalet(){ BGColor = Color.Yellow, NameColor = "Amarillo" ,TxtColor = Color.Purple , TxtColorName = "Violeta" ,TxtPalet = "Verde",NameColorEng ="Yellow" , TxtColorNameEng = "Purple", TxtPaleteng = "Green", TxtList = "Yellow"},
                            new ColorPalet(){ BGColor = Color.Orange, NameColor = "Naranja" ,TxtColor = Color.Gray , TxtColorName = "Gris" ,TxtPalet = "Rosa",NameColorEng ="Orange" , TxtColorNameEng = "Gray", TxtPaleteng = "Pink", TxtList = "Orange"},
                            new ColorPalet(){ BGColor = Color.DarkViolet, NameColor = "Violeta" ,TxtColor = Color.Blue ,TxtColorName = "Azul" , TxtPalet = "Naranja",NameColorEng ="Violet" , TxtColorNameEng = "Blue", TxtPaleteng = "Orange" , TxtList = "Violet"},
                            new ColorPalet(){ BGColor = Color.Fuchsia, NameColor = "Fucsia" ,TxtColor = Color.Yellow ,TxtColorName = "Amarillo" , TxtPalet = "Azul",NameColorEng ="Fuchsia" , TxtColorNameEng = "Yellow", TxtPaleteng = "Blue", TxtList = "Fuchsia"},
                            new ColorPalet(){ BGColor = Color.Purple, NameColor = "Púrpura" ,TxtColor = Color.Black ,TxtColorName = "Negro" , TxtPalet = "Gris",NameColorEng ="Purple" , TxtColorNameEng = "Black", TxtPaleteng = "Gray", TxtList = "Purple"},
                            new ColorPalet(){ BGColor = Color.LightBlue, NameColor = "Celeste" ,TxtColor = Color.Orange ,TxtColorName = "Naranja" , TxtPalet = "Blanco",NameColorEng ="Light Blue" , TxtColorNameEng = "Orange", TxtPaleteng = "White" , TxtList = "Light Blue"},
                            new ColorPalet(){ BGColor = Color.Gray, NameColor = "Gris" ,TxtColor = Color.Green ,TxtColorName = "Verde" , TxtPalet = "Fucsia",NameColorEng ="Gray" , TxtColorNameEng = "Green", TxtPaleteng = "Fuchsia" , TxtList = "Gray"},
                            new ColorPalet(){ BGColor = Color.Black, NameColor = "Negro" ,TxtColor = Color.White ,TxtColorName = "Blanco" , TxtPalet = "Rojo",NameColorEng ="Black" , TxtColorNameEng = "White", TxtPaleteng = "Red", TxtList = "Black"},
                            new ColorPalet(){ BGColor = Color.White, NameColor = "Blanco" ,TxtColor = Color.Red , TxtColorName = "Rojo" , TxtPalet = "Celeste"  ,NameColorEng ="White" , TxtColorNameEng = "Red", TxtPaleteng = "Light Blue" , TxtList ="White"}

                        };


                        break;

                    case 2:

                        TxtOpt = "Opciones";
                        TxtPicker = "--Selec. Trabajo--";
                        TxtPickerColor = "--Selec. Color--";
                        EmptyList = "Lista vacía";
                        Txtinterval = "Tiempo de trabajo";
                        Textrest = "Descanso";
                        Txtdelay = "Retardo";
                        Txtround = "Rondas";
                        Txtnumber = "Numero Max.";
                        Txtsound = "Sonido";
                        Txttime = "Tiempo total:";
                        BtnAddtxt = "AGREGAR";
                        BtnSettxt = "BORRAR";
                        BtnStarttxt = "EMPEZAR";


                        Setlist = new ObservableCollection<Modos>() {
                        new Modos(){ Key = 1 ,  Type = "Flechas"},
                        new Modos(){ Key = 2 ,  Type = "Numeros"},
                        new Modos(){ Key = 3 ,  Type = "Colores"},
                        new Modos(){ Key = 4 ,  Type = "Colores y Nombres"},
                        new Modos(){Key = 5 , Type = "Vocales" },
                        new Modos(){Key = 6 , Type = "Mixto"}

                          };
                        ColorList = new List<ColorPalet>()
                        {
                            new ColorPalet(){ BGColor = Color.Red,NameColor = "Rojo" , TxtColor = Color.Blue , TxtColorName = "Azul" ,TxtPalet = "Amarillo",NameColorEng ="Red" , TxtColorNameEng = "Blue", TxtPaleteng = "Yellow", TxtList = "Red"},
                            new ColorPalet(){ BGColor = Color.Green, NameColor = "Verde" ,TxtColor = Color.Purple, TxtColorName = "Violeta" , TxtPalet = "Violeta" , NameColorEng ="Green" , TxtColorNameEng = "Purple", TxtPaleteng = "Purple" , TxtList = "Green"},
                            new ColorPalet(){ BGColor = Color.Blue , NameColor = "Azul" ,TxtColor = Color.Purple , TxtColorName = "Violeta" ,TxtPalet = "Negro",NameColorEng ="Blue" , TxtColorNameEng = "Purple", TxtPaleteng = "Black" , TxtList ="Blue" },
                            new ColorPalet(){ BGColor = Color.Yellow, NameColor = "Amarillo" ,TxtColor = Color.Purple , TxtColorName = "Violeta" ,TxtPalet = "Verde",NameColorEng ="Yellow" , TxtColorNameEng = "Purple", TxtPaleteng = "Green", TxtList = "Yellow"},
                            new ColorPalet(){ BGColor = Color.Orange, NameColor = "Naranja" ,TxtColor = Color.Gray , TxtColorName = "Gris" ,TxtPalet = "Rosa",NameColorEng ="Orange" , TxtColorNameEng = "Gray", TxtPaleteng = "Pink", TxtList = "Orange"},
                            new ColorPalet(){ BGColor = Color.DarkViolet, NameColor = "Violeta" ,TxtColor = Color.Blue ,TxtColorName = "Azul" , TxtPalet = "Naranja",NameColorEng ="Violet" , TxtColorNameEng = "Blue", TxtPaleteng = "Orange" , TxtList = "Violet"},
                            new ColorPalet(){ BGColor = Color.Fuchsia, NameColor = "Fucsia" ,TxtColor = Color.Yellow ,TxtColorName = "Amarillo" , TxtPalet = "Azul",NameColorEng ="Fuchsia" , TxtColorNameEng = "Yellow", TxtPaleteng = "Blue", TxtList = "Fuchsia"},
                            new ColorPalet(){ BGColor = Color.Purple, NameColor = "Púrpura" ,TxtColor = Color.Black ,TxtColorName = "Negro" , TxtPalet = "Gris",NameColorEng ="Purple" , TxtColorNameEng = "Black", TxtPaleteng = "Gray", TxtList = "Purple"},
                            new ColorPalet(){ BGColor = Color.LightBlue, NameColor = "Celeste" ,TxtColor = Color.Orange ,TxtColorName = "Naranja" , TxtPalet = "Blanco",NameColorEng ="Light Blue" , TxtColorNameEng = "Orange", TxtPaleteng = "White" , TxtList = "Light Blue"},
                            new ColorPalet(){ BGColor = Color.Gray, NameColor = "Gris" ,TxtColor = Color.Green ,TxtColorName = "Verde" , TxtPalet = "Fucsia",NameColorEng ="Gray" , TxtColorNameEng = "Green", TxtPaleteng = "Fuchsia" , TxtList = "Gray"},
                            new ColorPalet(){ BGColor = Color.Black, NameColor = "Negro" ,TxtColor = Color.White ,TxtColorName = "Blanco" , TxtPalet = "Rojo",NameColorEng ="Black" , TxtColorNameEng = "White", TxtPaleteng = "Red", TxtList = "Black"},
                            new ColorPalet(){ BGColor = Color.White, NameColor = "Blanco" ,TxtColor = Color.Red , TxtColorName = "Rojo" , TxtPalet = "Celeste"  ,NameColorEng ="White" , TxtColorNameEng = "Red", TxtPaleteng = "Light Blue" , TxtList ="White"}
                        };

                        Debug.WriteLine($"Idioma Español");

                        break;

                }
            }
            else
            {

                
                if (numberlang == 1)
                {
                    await App.Current.MainPage.DisplayAlert("Configuration started ", "Reset the app to change de language ", "OK");

                }
                if(numberlang == 2)
                {
                    await App.Current.MainPage.DisplayAlert("Configuracion inciada", "Reinicia la aplicación para cambiar el idioma ", "OK");

                }

            }


        }
        public async Task DisplayFunction()
        {

            await ((NavigationPage)App.Current.MainPage).PushAsync(new View.Training(App.vm));
            RunThread = true;


            int i, j, rounds;

            rounds = int.Parse(Rounds);
            if (!Config)
            {
                foreach (ColorPalet list in ColorList)
                {
                    SelectedColorList.Add(list);
                }

            }
            else
            {
                foreach (ColorPalet list in ColorSelected)
                {
                    SelectedColorList.Add(list);

                }


            }
           
            for (j = 0; j < rounds; j++)
            {
                
                for (i = 0; i < ModesList.Count; i++)
                {
                    if (!RunThread)
                        return;
                    if (ModesList[i].Value == "Flechas" || ModesList[i].Value == "Arrow")
                    {
                        await ColorWork.ExArrows(ModesList[i].Time, ModesList[i].Delay, ModesList[i].SwitchState);
                        await Task.Delay(ModesList[i].Rests);

                    }
                    if (ModesList[i].Value == "Numeros" || ModesList[i].Value == "Numbers")
                    {
                        await ColorWork.ExNumbers(Number, ModesList[i].Time, ModesList[i].Delay, ModesList[i].SwitchState);
                        await Task.Delay(ModesList[i].Rests);

                    }
                    if (ModesList[i].Value == "Colores" || ModesList[i].Value == "Colors")
                    {
                        await ColorWork.ExColorWork(SelectedColorList, ModesList[i].Time, ModesList[i].Delay, ModesList[i].SwitchState);
                        await Task.Delay(ModesList[i].Rests);
                    }
                    if (ModesList[i].Value == "Colores y Nombres" || ModesList[i].Value == "Colors & Words")
                    {
                        await ColorWork.ExColorNameWork(SelectedColorList, ModesList[i].Time, ModesList[i].Delay, ModesList[i].SwitchState);
                        await Task.Delay(ModesList[i].Rests);

                    }
                    if (ModesList[i].Value == "Vocales" || ModesList[i].Value == "Vocals")
                    {
                        await ColorWork.ExVocals(ModesList[i].Time, ModesList[i].Delay, ModesList[i].SwitchState);
                        await Task.Delay(ModesList[i].Rests);

                    }
                    if (ModesList[i].Value == "Mixto" || ModesList[i].Value == "Mix")
                    {
                        await ColorWork.ExMix(SelectedColorList, ModesList[i].Time, ModesList[i].Delay, ModesList[i].SwitchState, Number);
                        await Task.Delay(ModesList[i].Rests);

                    }

                    
                }

            }


            await ((NavigationPage)App.Current.MainPage).PopAsync();





        }




       



        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Modos : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int _key;
        public int Key
        {
            get
            {

                return _key;
            }

            set
            {
                _key = value;
                OnPropertyChanged("");

            }
        }
        private string _type;

        public string Type
        {
            get
            {

                return _type;
            }

            set
            {
                _type = value;
                OnPropertyChanged("");

            }
        }





        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
