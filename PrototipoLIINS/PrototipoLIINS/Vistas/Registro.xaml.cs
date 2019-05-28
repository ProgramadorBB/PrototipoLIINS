using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrototipoLIINS.Modelo;
using PrototipoLIINS.Conexion;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrototipoLIINS.Vistas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Registro : ContentPage
	{
		public Registro ()
		{
			InitializeComponent ();
		}

        private void BtnCrearCuenta_Clicked(object sender, EventArgs e)
        {
            lblMensaje.Text = string.Empty;
            lblMensaje.TextColor = Color.DarkRed;
            //lblMensaje.Text = UsuarioRepository.Instancia.EstadoMensaje;

            string tipo = "user";
            string estado = "desbloqueado";

            if (string.IsNullOrEmpty(txtEmail.Text) &&
                string.IsNullOrEmpty(txtContraseña.Text) &&
                string.IsNullOrEmpty(txtNombre.Text) &&
                string.IsNullOrEmpty(txtApellido.Text))
            {
                lblMensaje.Text = string.Empty;
                lblMensaje.TextColor = Color.DarkRed;
                lblMensaje.Text = "Campos vacios";
            }
            else
            {
                UsuarioRepository.Instancia.AddNuevoUsuario(txtEmail.Text, txtContraseña.Text,
                txtNombre.Text, txtApellido.Text, tipo, estado);

                string mensaje = UsuarioRepository.Instancia.EstadoMensaje;

                if (mensaje.Equals("Constraint"))
                {
                    lblMensaje.Text = "El usuario ya se encuentra registrado";
                }
                else
                {
                    lblMensaje.Text = UsuarioRepository.Instancia.EstadoMensaje;
                }
            }                
        }
    }
}