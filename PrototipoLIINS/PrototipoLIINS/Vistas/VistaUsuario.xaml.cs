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
	public partial class VistaUsuario : ContentPage
	{
		public VistaUsuario ()
		{
			InitializeComponent ();
		}

        private void BtnInstrucciones_Clicked(object sender, EventArgs e)
        {

        }

        private void BtnVincularDispositivo_Clicked(object sender, EventArgs e)
        {

        }

        private void BtnTerminosLegales_Clicked(object sender, EventArgs e)
        {

        }

        private void BtnVerReglamentoGarzón_Clicked(object sender, EventArgs e)
        {

        }

        private async void BtnCerrarSesion_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        private void BtnMonitorearDispensadores_Clicked(object sender, EventArgs e)
        {

        }
    }
}