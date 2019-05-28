using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using PrototipoLIINS.Modelo;
using PrototipoLIINS.Vistas;

namespace PrototipoLIINS
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            Application.Current.Properties.Clear();
        }

        private void BtnIngresar_Clicked(object sender, EventArgs e)
        {

        }

        private async void BtnRegistrarCuenta_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Registro() { Title = "Registro LIINS"});
        }
    }
}
