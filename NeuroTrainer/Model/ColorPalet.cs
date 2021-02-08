using Xamarin.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NeuroTrainer.Model
{
    public class ColorPalet : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;



        private Color _bgcolor;
        public Color BGColor
        {

            get
            {
                return _bgcolor;
            }
            set
            {
                _bgcolor = value;
                OnPropertyChanged("BGColor");
            }
        }


        private string _namecolor;
        public string NameColor
        {
            get
            {
                return _namecolor;
            }
            set
            {
                _namecolor = value;
                OnPropertyChanged("NameColor");
            }

        }


        private string _namecoloreng;
        public string NameColorEng
        {
            get
            {
                return _namecoloreng;
            }
            set
            {
                _namecoloreng = value;
                OnPropertyChanged("NameColoreng");
            }

        }



        
        private Color _txtcolor;
        public Color TxtColor
        {
            get
            {
                return _txtcolor;
            }
            set
            {
                _txtcolor = value;
                OnPropertyChanged("TxtColor");
            }
        }

        private string _txtcolorname;
        public string TxtColorName
        {
            get
            {
                return _txtcolorname;
            }
            set
            {
                _txtcolorname = value;
                OnPropertyChanged("TxtColorName");
            }
        }


        private string _txtcolornameEng;
        public string TxtColorNameEng
        {
            get
            {
                return _txtcolornameEng;
            }
            set
            {
                _txtcolornameEng = value;
                OnPropertyChanged("TxtColorNameeng");
            }
        }
        private string _txtpalet;
        public string TxtPalet
        {
            get
            {
                return _txtpalet;
            }
            set
            {
                _txtpalet = value;
                OnPropertyChanged("TxtPalet");
            }
        }
        private string _txtpaleteng;
        public string TxtPaleteng
        {
            get
            {
                return _txtpaleteng;
            }
            set
            {
                _txtpaleteng = value;
                OnPropertyChanged("TxtPaleteng");
            }
        }

        private string _txtList;
        public string TxtList
        {
            get
            {
                return _txtList;
            }
            set
            {
                _txtList = value;
                OnPropertyChanged("TxtPalet");
            }
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
