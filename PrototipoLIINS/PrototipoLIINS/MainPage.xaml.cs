using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using PrototipoLIINS.Modelo;
using PrototipoLIINS.Vistas;
using PrototipoLIINS.Conexion;

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
            lblMensaje.Text = string.Empty;
            Boolean isUsuarioExist = UsuarioRepository.Instancia.AttempLogin(txtEmail.Text, txtContraseña.Text);
            lblMensaje.Text = UsuarioRepository.Instancia.EstadoMensaje;

            if (isUsuarioExist.Equals(true))
            {
                lblMensaje.Text = "usuario correcto";
            }
        }

        private async void BtnRegistrarCuenta_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Registro() { Title = "Registro LIINS"});
        }
    }
}
