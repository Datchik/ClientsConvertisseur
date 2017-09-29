using ClientConvertisseurV2.Model;
using ClientConvertisseurV2.service;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ClientConvertisseurV2.ViewModel
{
    public class MainViewModel : ConversionAbstraite
    {
        private WSService client;
        public ICommand BtnSetConversion { get; private set; }
        public MainViewModel()
        {
            ActionGetData();
            BtnSetConversion = new RelayCommand(ActionSetConversion);
        }
        protected override void ActionSetConversion()
        {
            //Code du calcul à écrire
            try { 
                MontantEnDevise = Convert.ToString((int)(Convert.ToDouble(MontantEuros) * ComboBoxDeviseItem.Taux));
            }
            catch (NullReferenceException e) {
                
            }
            catch (FormatException e)
            {

            }
           
        }
        
    }
}
