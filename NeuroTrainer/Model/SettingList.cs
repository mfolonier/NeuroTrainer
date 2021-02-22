using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using NeuroTrainer.ViewModel;

namespace NeuroTrainer.Model 
{
    public class SettingList 
    {

        
       

        //Constructor
        public SettingList()
        {


            /// ViewModel.ViewModel.Setlistload(ListaModos);
        }

    }
    
    
    public class ListWork
    {
        public int Time { get; set; }
        public int Rests { get; set; }
        public int Delay { get; set; }
        public TimeSpan Time2 { get; set; }
        public TimeSpan Rests2 { get; set; }
        public TimeSpan Delay2 { get; set; }
        public string Value { get; set; }
        public bool SwitchState { get; set; }
    }

   

}
