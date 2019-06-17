﻿using System;
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

        private async void OnUpdateUser(object sender, ItemTappedEventArgs e)
        {
            Usuario u = (Usuario)e.Item;
            Application.Current.Properties["datos"] = u;
            await Navigation.PushAsync(new VistaBuscarUsuario() { Title = "Volver al Menú" });

            //await Navigation.PushAsync(new VistaBuscarUsuario());
        }

        private async void OnDeleteUser(object sender, EventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            Usuario user = (Usuario)item.CommandParameter;

            if (user != null)
            {
                if (await this.DisplayAlert("¿Borrar usuario [id: " + user.Id + "]?",
                    "El usuario [" + user.Nombre + " " + user.Apellido + "] Se eliminara de forma permanente",
                    "Eliminar usuario",
                    "Cancelar") == true)
                {
                    UsuarioRepository.Instancia.DeleteUsuario(user.Id);
                    users.Remove(user);
                }
            }
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

        
        private void BtnBuscarUsuario_Clicked(object sender, EventArgs e)
        {
            txtBuscar.IsVisible = true;
            btnBuscar.IsVisible = true;
            btnInformación.IsVisible = true;

            btnCerrarSesion.IsVisible = false;            
            btnBuscarUsuario.IsVisible = false;
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

        private async void BtnBuscar_Clicked(object sender, EventArgs e)
        {
            
            string uBuscado = txtBuscar.Text;
            txtBuscar.Text = "";
            if (UsuarioRepository.Instancia.BuscarUsuario(uBuscado) != null)
            {
                Usuario u = UsuarioRepository.Instancia.BuscarUsuario(uBuscado);
                Application.Current.Properties["datos"] = u;
                await Navigation.PushAsync(new VistaBuscarUsuario() { Title = "Volver al Menú" });
            }
            else
            {
                btnBuscarUsuario.IsVisible = true;
                btnCerrarSesion.IsVisible = true;

                txtBuscar.IsVisible = false;
                btnBuscar.IsVisible = false;
                btnInformación.IsVisible = false;

                await this.DisplayAlert("Resultados de la busqueda:", "No existen coincidencias", "Aceptar");
            }

        }
    }
}