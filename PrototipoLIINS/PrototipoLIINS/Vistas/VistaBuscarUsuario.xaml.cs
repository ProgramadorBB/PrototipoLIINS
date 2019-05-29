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

            Usuario u = Application.Current.Properties["datos"] as Usuario;

            lblEmail.Text = u.Email;
            lblContraseña.Text = u.Contraseña;
            lblNombre.Text = u.Nombre;
            lblApellido.Text = u.Apellido;
            lblEstado.Text = u.Estado;

        }
    }
}