using ClientConvertisseurV1.Model;
using ClientConvertisseurV1.service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ClientConvertisseurV1
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private WSService client;
        public MainPage()
        {
            this.InitializeComponent();
            client = new WSService();
            ActionGetData();
        }
        private async void ActionGetData()
        {
            var result = await client.GetAllDevisesAsync();
            this.cbxDevise.DataContext = new List<Devise>(result);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int montantEuro = Convert.ToInt32(this.tbxMontantEuro.Text);
            double taux = ((Devise)this.cbxDevise.SelectedItem).Taux;
            int result = (int)((double)montantEuro * taux);
            this.tbxMontantDevise.Text = Convert.ToString(result);
        }
    }
}
