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
        public int delay { get; set; }
        public string Value { get; set; }
        public bool SwitchState { get; set; }
    }

   

}
