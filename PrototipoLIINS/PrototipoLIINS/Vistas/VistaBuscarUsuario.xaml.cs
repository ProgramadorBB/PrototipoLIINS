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


            btnEditarUsuario.IsVisible = false;
            btnGuardarCambios.IsVisible = true;
        }

        private void BtnCargar_Clicked(object sender, EventArgs e)
        {
            Usuario u = Application.Current.Properties["datos"] as Usuario;

            lblEmail.Text = u.Email;
            lblContraseña.Text = u.Contraseña;
            lblNombre.Text = u.Nombre;
            lblApellido.Text = u.Apellido;
            lblEstado.Text = u.Estado;

            btnCargar.IsVisible = false;
            btnEditarUsuario.IsVisible = true;
        }

        private void BtnGuardarCambios_Clicked(object sender, EventArgs e)
        {

        }
    }
}