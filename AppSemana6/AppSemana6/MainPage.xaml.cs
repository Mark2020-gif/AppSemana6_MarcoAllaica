using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Collections.ObjectModel;

namespace AppSemana6
{
    public partial class MainPage : ContentPage
    {
        private const string Url = "http://192.168.1.5/Rest/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<AppSemana6.WS.Dato> _post;
        public MainPage()
        {
            InitializeComponent();
            get();
        }

        public async void get()
        {
            var content = await client.GetStringAsync(Url);
            List<AppSemana6.WS.Dato> posts = JsonConvert.DeserializeObject<List<AppSemana6.WS.Dato>>(content);
            _post = new ObservableCollection<AppSemana6.WS.Dato>(posts);

            MyListView.ItemsSource = _post;
        }


        private async void btnInsertar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Insertar());

        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Actualizar());

        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Eliminar());

        }
    }

}
