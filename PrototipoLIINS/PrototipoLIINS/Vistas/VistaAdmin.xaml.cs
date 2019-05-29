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
            var allUsers = UsuarioRepository.Instancia.GetAllUsuarios();


            foreach (Usuario user in allUsers)
                if (users.All(u => u.Id != user.Id))
                {
                    if(user.Tipo.Equals("Usuario"))                
                    users.Add(user);
                }
        }

        private void EliminarUsuario_Clicked(object sender, EventArgs e)
        {

        }

        private void EditarUsuario_Clicked(object sender, EventArgs e)
        {

        }
    }
}