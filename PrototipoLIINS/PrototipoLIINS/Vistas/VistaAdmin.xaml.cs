using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrototipoLIINS.Vistas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VistaAdmin : ContentPage
	{
		public VistaAdmin ()
		{
			InitializeComponent ();
		}

        private void OnUpdateUser(object sender, ItemTappedEventArgs e)
        {

        }

        private void OnDeleteUser(object sender, EventArgs e)
        {

        }
    }
}