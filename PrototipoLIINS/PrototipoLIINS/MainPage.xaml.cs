﻿using System;
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
                UsuarioRepository.Instancia.AddNuevoUsuario(admin, "123", "Admin", "Admin", "Admin", "Desbloqueado");
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
                    Application.Current.Properties["sesion"] = userSesion;
                    txtEmail.Text = string.Empty;
                    txtContraseña.Text = string.Empty;
                    if (userSesion.Contraseña.Equals("123"))
                    {
                        await this.DisplayAlert("LIINS: ", "Hola Admin, Detectamos que es la primera vez que ingresas al sistema, es necesario por la seguridad de sus datos cambiar la contraseña que viene por defecto", "OK");
                        await Navigation.PushAsync(new VistaCambiarContraseña());
                    }
                    else
                    {                        
                        await this.DisplayAlert("Bienvenido", userSesion.Tipo, "Acceder");                       
                        await Navigation.PushAsync(new VistaAdmin());
                    }
                }
                else
                {

                    if (userSesion.Estado.Equals("Bloqueado"))
                    {
                        txtEmail.Text = string.Empty;
                        txtContraseña.Text = string.Empty;
                        await this.DisplayAlert("Cuenta Bloqueada", "Para más información contactarse con el Administrador", "OK");
                    }
                    else
                    {

                        await this.DisplayAlert("Bienvenido: ", userSesion.Nombre + " " + userSesion.Apellido, "Acceder");
                        Application.Current.Properties["sesion"] = userSesion;
                        Usuario u = UsuarioRepository.Instancia.BuscarUsuario(txtEmail.Text);
                        Application.Current.Properties["datos"] = u;
                        txtEmail.Text = string.Empty;
                        txtContraseña.Text = string.Empty;
                        lblMensaje.Text = string.Empty;
                        await Navigation.PushAsync(new VistaUsuario());
                    }
                }
            }
        }

        private async void BtnRegistrarCuenta_Clicked(object sender, EventArgs e)
        {
            txtEmail.Text = "";
            txtContraseña.Text = "";
            await Navigation.PushAsync(new Registro() { Title = "Volver"});
            // para dejar admin x defecto y borrar toda la bdd de ser necesario
            //UsuarioRepository.Instancia.DeleteAllUsers();
        }
    }
}
