using ClientConvertisseurV2.service;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ClientConvertisseurV2.ViewModel
{
    public class ConversionDeviseViewModel : ConversionAbstraite
    {
        public ICommand BtnSetConversion { get; private set; }
        public ConversionDeviseViewModel()
        {
            ActionGetData();
            BtnSetConversion = new RelayCommand(ActionSetConversion);
        }

        protected override void ActionSetConversion()
        {
            //Code du calcul à écrire
            try
            {
                MontantEuros = Convert.ToString((int)(Convert.ToDouble(MontantEnDevise) / ComboBoxDeviseItem.Taux));
            }
            catch (NullReferenceException e)
            {

            }
            catch (FormatException e)
            {

            }
        }
    }
}
