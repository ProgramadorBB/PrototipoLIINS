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
            lblMensaje.Text = string.Empty;

            string admin = "Admin";
            Usuario buscarAdmin = UsuarioRepository.Instancia.BuscarUsuario(admin);

            if(buscarAdmin == null)
            {
                UsuarioRepository.Instancia.AddNuevoUsuario(admin, "123", "Admin", "Admin", "Admin", "desbloqueado");
            }

        }

        private async void btnIngresar_Clicked(object sender, EventArgs e)
        {
            lblMensaje.Text = string.Empty;
            Boolean isUsuarioExist = UsuarioRepository.Instancia.AttempLogin(txtEmail.Text, txtContraseña.Text);
            lblMensaje.Text = UsuarioRepository.Instancia.EstadoMensaje;

            if (isUsuarioExist.Equals(true))
            {
                Usuario userSesion = UsuarioRepository.Instancia.userType(txtEmail.Text, txtContraseña.Text);

                if (userSesion.Tipo.Equals("Admin"))
                {
                    lblMensaje.Text = string.Empty;
                    await this.DisplayAlert("Bienvenido", userSesion.Tipo, "Acceder");
                    Application.Current.Properties["sesion"] = userSesion;

                    txtEmail.Text = string.Empty;
                    txtContraseña.Text = string.Empty;
                    await Navigation.PushAsync(new VistaAdmin());
                }
                else
                {

                    if (userSesion.Estado.Equals("bloqueado"))
                    {
                        txtEmail.Text = string.Empty;
                        txtContraseña.Text = string.Empty;
                        await this.DisplayAlert("Cuenta Bloqueada", "Para más información contactarse con el Administrador", "OK");
                    }
                    else
                    {
                        await this.DisplayAlert("Bienvenido: ", userSesion.Nombre + " " + userSesion.Apellido, "Acceder");
                        Application.Current.Properties["sesion"] = userSesion;
                        txtEmail.Text = string.Empty;
                        txtContraseña.Text = string.Empty;
                        await Navigation.PushAsync(new VistaUsuario());
                    }
                }
            }
        }

        private async void BtnRegistrarCuenta_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Registro() { Title = "Volver"});
        }
    }
}
