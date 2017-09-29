using ClientConvertisseurV2.Model;
using ClientConvertisseurV2.service;
using ClientConvertisseurV2.View;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ClientConvertisseurV2.ViewModel
{
    public abstract class ConversionAbstraite : ViewModelBase
    {

        protected abstract void ActionSetConversion();
        

        private string _montantEuros;
        public string MontantEuros
        {
            get { return _montantEuros; }
            set
            {
                _montantEuros = value;
                RaisePropertyChanged();
            }
        }

        private Devise _devisetaux;
        public Devise ComboBoxDeviseItem
        {
            get { return _devisetaux; }
            set
            {
                _devisetaux = value;
                RaisePropertyChanged();
            }
        }

        private string _montantEnDevise;
        public string MontantEnDevise
        {
            get { return _montantEnDevise; }
            set
            {
                _montantEnDevise = value;
                RaisePropertyChanged();
            }
        }


        protected async void ActionGetData()
        {
            var result = await WSService.Instance.GetAllDevisesAsync();
            ComboBoxDevises = new ObservableCollection<Devise>(result);
        }

        private ObservableCollection<Devise> _comboBoxDevises;
        public ObservableCollection<Devise> ComboBoxDevises
        {
            get { return _comboBoxDevises; }
            set
            {
                _comboBoxDevises = value;
                RaisePropertyChanged();// Pour notifier de la modification de ses données
            }
        }

        private void ActionChangeConvertisseur()
        {
            RootPage r = (RootPage)Window.Current.Content;
            SplitView sv = (SplitView)(r.Content);
            (sv.Content as Frame).Navigate(typeof(MainPage));
        }

        public object Console { get; private set; }
    }
}
