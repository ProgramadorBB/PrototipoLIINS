using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrototipoLIINS.Conexion;
using PrototipoLIINS.Modelo;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrototipoLIINS.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VistaBuscarUsuario : ContentPage
    {
        public VistaBuscarUsuario()
        {
            InitializeComponent();

            pkEstado.Items.Add("Desbloqueado");
            pkEstado.Items.Add("Bloqueado");
            pkEstado.SelectedIndex = 0;

            
        }

        private void BtnEditarUsuario_Clicked(object sender, EventArgs e)
        {
            lblEmail.IsVisible = false;
            lblContraseña.IsVisible = false;
            lblNombre.IsVisible = false;
            lblApellido.IsVisible = false;
            lblEstado.IsVisible = false;

            txtEmail.IsVisible = true;
            txtContraseña.IsVisible = true;
            txtNombre.IsVisible = true;
            txtApellido.IsVisible = true;
            pkEstado.IsVisible = true;

            Usuario u = Application.Current.Properties["datos"] as Usuario;

            txtNombre.Text = u.Nombre;
            txtApellido.Text = u.Apellido;
            txtEmail.Text = u.Email;
            txtContraseña.Text = u.Contraseña;

            btnEditarUsuario.IsVisible = false;
            btnGuardarCambios.IsVisible = true;
            btnEliminarUsuario.IsVisible = false;
        }

        private void BtnCargar_Clicked(object sender, EventArgs e)
        {
            Usuario u = Application.Current.Properties["datos"] as Usuario;

            lblEmail.Text = u.Email;
            lblContraseña.Text = u.Contraseña;
            lblNombre.Text = u.Nombre;
            lblApellido.Text = u.Apellido;
            lblEstado.Text = u.Estado;

            icono.Source = "userProfile.png";
            lblTitle.Text = "Perfil de Usuario:";

            btnCargar.IsVisible = false;
            btnEditarUsuario.IsVisible = true;
            btnEliminarUsuario.IsVisible = true;
        }

        private void BtnGuardarCambios_Clicked(object sender, EventArgs e)
        {

        }

        private async void BtnEliminarUsuario_Clicked(object sender, EventArgs e)
        {
            Usuario u = Application.Current.Properties["datos"] as Usuario;

            if (await this.DisplayAlert("¿Borrar usuario [id: " + u.Id + "]?",
                    "El usuario [" + u.Nombre + " " + u.Apellido + "] Se eliminara de forma permanente",
                    "Eliminar usuario",
                    "Cancelar") == true)
            {
                UsuarioRepository.Instancia.DeleteUsuario(u.Id);
            }
        }
    }
}