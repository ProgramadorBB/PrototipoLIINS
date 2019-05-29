using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrototipoLIINS.Conexion;
using PrototipoLIINS.Modelo;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrototipoLIINS.Vistas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VistaAdmin : ContentPage
	{
        IList<Usuario> users = new ObservableCollection<Usuario>();

        public VistaAdmin ()
		{
            BindingContext = users;
            InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void OnUpdateUser(object sender, ItemTappedEventArgs e)
        {

        }

        private void OnDeleteUser(object sender, EventArgs e)
        {

        }

        private void BtnGetAllUser_Clicked(object sender, EventArgs e)
        {
            string btnText = btnGetAllUser.Text;

            if(btnText == "Mostrar Lista de Usuarios")
            {
                var allUsers = UsuarioRepository.Instancia.GetAllUsuarios();

                foreach (Usuario user in allUsers)
                    if (users.All(u => u.Id != user.Id))
                    {
                        if (user.Tipo.Equals("Usuario"))
                            users.Add(user);
                    }
                grLista.IsVisible = true;
                btnGetAllUser.ImageSource = "backlista.png";
                btnGetAllUser.Text = "Ocultar Lista de Usuarios";
            }
            else
            {
                grLista.IsVisible = false;
                btnGetAllUser.ImageSource = "lista.png";
                btnGetAllUser.Text = "Mostrar Lista de Usuarios";
            }
        }

        private void BtnEditarUsuario_Clicked(object sender, EventArgs e)
        {

        }

        private void BtnEliminarUsuario_Clicked(object sender, EventArgs e)
        {

        }

        private void BtnBuscarUsuario_Clicked(object sender, EventArgs e)
        {

        }

        private async void BtnInformación_Clicked(object sender, EventArgs e)
        {
            await this.DisplayAlert("Información: ","Para buscar un usuario debe ingresar el E-mail del Usuario", "OK");
        }

        private async void BtnInstrucciones_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VistaInstrucciones() { Title = "Volver al Menú" });
        }

        private async void BtnTerminosLegales_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VistaLegal() {  Title = "Volver al Menú" });
        }

        private async void BtnKpiConsumo_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VistaKpi() { Title = "Volver al Menú" });
        }

        private async void BtnLiquidoPopular_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VistaLiquidoPopular() { Title = "Volver al Menú" });
        }

        private async void BtnCerrarSesion_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}