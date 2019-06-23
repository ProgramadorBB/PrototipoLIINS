using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrototipoLIINS.Conexion;
using PrototipoLIINS.Modelo;
using PrototipoLIINS.Vistas;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrototipoLIINS.Vistas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VistaUsuario : ContentPage
	{
		public VistaUsuario ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void BtnInstrucciones_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VistaInstrucciones() { Title = "Volver al Menú" });
        }

        private void BtnVincularDispositivo_Clicked(object sender, EventArgs e)
        {
            btnMonitorearDispensadores.IsEnabled = true;
            btnMonitorearDispensadores.IsVisible = true;
            btnVincularDispositivo.IsEnabled = false;
            btnVincularDispositivo.IsVisible = false;
            
        }

        private async void BtnTerminosLegales_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VistaLegal() { Title = "Volver al Menú" });
        }

        private async void BtnVerReglamentoGarzón_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VistaReglamentoGarzon() { Title = "Volver al Menú" });
        }

        private async void BtnCerrarSesion_Clicked(object sender, EventArgs e)
        {
            if (await this.DisplayAlert("LIINS:",
                    "¿Desea Cerrar Sesión? ",
                    "Si",
                    "Cancelar") == true)
            {
                await Navigation.PopToRootAsync();
            }
        }

        private void BtnMonitorearDispensadores_Clicked(object sender, EventArgs e)
        {

        }

        private void BtnVerPerfil_Clicked(object sender, EventArgs e)
        {
            lblTitulo.Text = "Perfil de Usuario";
            btnVerPerfil.IsVisible = false;
            btnInstrucciones.IsVisible = false;
            btnVerReglamentoGarzón.IsVisible = false;            
            btnTerminosLegales.IsVisible = false;
            btnCerrarSesion.IsVisible = false;

            if(btnVincularDispositivo.IsEnabled == true)
            {
                btnVincularDispositivo.IsVisible = false;
            }
            if(btnMonitorearDispensadores.IsEnabled == true)
            {
                btnMonitorearDispensadores.IsVisible = false;
            }

            slCuadro.IsVisible = true;
            btnModificarPerfil.IsVisible = true;
            btnEliminarCuenta.IsVisible = true;
            btnVolver.IsVisible = true;

            Usuario u = Application.Current.Properties["datos"] as Usuario;

            lblNombre.Text = u.Nombre;
            lblApellido.Text = u.Apellido;
            lblEmail.Text = u.Email;
            lblContraseña.Text = u.Contraseña;
        }

        private void BtnModificarPerfil_Clicked(object sender, EventArgs e)
        {
            lblNombre.IsVisible = false;
            lblApellido.IsVisible = false;
            lblEmail.IsVisible = false;
            lblContraseña.IsVisible = false;

            txtNombre.IsVisible = true;
            txtApellido.IsVisible = true;
            txtEmail.IsVisible = true;
            txtContraseña.IsVisible = true;

            Usuario u = Application.Current.Properties["datos"] as Usuario;

            txtNombre.Text = u.Nombre;
            txtApellido.Text = u.Apellido;
            txtEmail.Text = u.Email;
            txtContraseña.Text = u.Contraseña;

            btnEliminarCuenta.IsVisible = false;
            btnModificarPerfil.IsVisible = false;
            btnVolver.IsVisible = false;

            btnGuardarCambios.IsVisible = true;
            btnVolver2.IsVisible = true;
        }

        private async void BtnEliminarCuenta_Clicked(object sender, EventArgs e)
        {
            Usuario u = Application.Current.Properties["datos"] as Usuario;

            if (await this.DisplayAlert("¡ATENCIÓN!",
                    "Esta a punto de eliminar su cuenta de forma permanente en el sistema, ¿Se encuentra seguro de realizar esta acción? ",
                    "Si, Eliminar cuenta",
                    "No, Cancelar") == true)
            {
                UsuarioRepository.Instancia.DeleteUsuario(u.Id);
                await this.DisplayAlert("LIINS: ", "Cuenta Eliminada", "Aceptar");
                await Navigation.PopToRootAsync();
            }
        }

        private void BtnVolver_Clicked(object sender, EventArgs e)
        {
            lblTitulo.Text = "Menú Usuario";
            btnVerPerfil.IsVisible = true;
            btnInstrucciones.IsVisible = true;
            btnVerReglamentoGarzón.IsVisible = true;
            btnTerminosLegales.IsVisible = true;
            btnCerrarSesion.IsVisible = true;

            if (btnVincularDispositivo.IsEnabled == true)
            {
                btnVincularDispositivo.IsVisible = true;
            }
            if (btnMonitorearDispensadores.IsEnabled == true)
            {
                btnMonitorearDispensadores.IsVisible = true;
            }

            slCuadro.IsVisible = false;
            btnModificarPerfil.IsVisible = false;
            btnEliminarCuenta.IsVisible = false;
            btnVolver.IsVisible = false;
        }

        private async void BtnGuardarCambios_Clicked(object sender, EventArgs e)
        {
            Usuario u = Application.Current.Properties["datos"] as Usuario;
            u.Nombre = txtNombre.Text;
            u.Apellido = txtApellido.Text;
            u.Contraseña = txtContraseña.Text;
            u.Email = txtEmail.Text;

            if (await this.DisplayAlert("¿Guardar cambios del Usuario?",
                    "IMPORTANTE: Los datos se cambiaran de forma permanente",
                    "Guardar",
                    "Cancelar") == true)
            {
                UsuarioRepository.Instancia.UpdateUser(u);
                await this.DisplayAlert("LIINS: ", "Usuario actualizado en la base de datos", "Aceptar");
                Application.Current.Properties["datos"] = u;
            }
        }

        private void BtnVolver2_Clicked(object sender, EventArgs e)
        {
            lblNombre.IsVisible = true;
            lblApellido.IsVisible = true;
            lblEmail.IsVisible = true;
            lblContraseña.IsVisible = true;

            txtNombre.IsVisible = false;
            txtApellido.IsVisible = false;
            txtEmail.IsVisible = false;
            txtContraseña.IsVisible = false;

            btnEliminarCuenta.IsVisible = true;
            btnModificarPerfil.IsVisible = true;
            btnVolver.IsVisible = true;

            btnGuardarCambios.IsVisible = false;
            btnVolver2.IsVisible = false;

            Usuario u = Application.Current.Properties["datos"] as Usuario;

            lblNombre.Text = u.Nombre;
            lblApellido.Text = u.Apellido;
            lblEmail.Text = u.Email;
            lblContraseña.Text = u.Contraseña;
        }
    }
}