using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net;

namespace AppSemana6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Insertar : ContentPage
    {
        public Insertar()
        {
            InitializeComponent();
        }

        private void btnIngresar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient client = new WebClient();
                var parametro = new System.Collections.Specialized.NameValueCollection();
                parametro.Add("codigo", txtCodigo.Text);
                parametro.Add("nombre", txtNombre.Text);
                parametro.Add("apellido", txtApellido.Text);
                parametro.Add("edad", txtEdad.Text);
                


                client.UploadValues("http://192.168.1.5/Rest/post.php", "POST", parametro);
                
                var mensaje = "Dato ingresado Exitosamnte";
                DependencyService.Get<Mensaje>().LongAlert(mensaje);
                // Limpiar textos
                txtCodigo.Text = "";
                txtNombre.Text = "";
                txtApellido.Text = "";
                txtEdad.Text = "";
                
   

            }
            catch (Exception ex)
            {
                DependencyService.Get<Mensaje>().ShortAlert("Error");
            }

        }

        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());

        }
    }
}