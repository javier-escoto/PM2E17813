using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using PM2E17813.Models;
using System.IO;
using Plugin.Media.Abstractions;

namespace PM2E17813.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PagePrincipal : ContentPage
    {
        Plugin.Media.Abstractions.MediaFile photo = null;


        public PagePrincipal()
        {
            InitializeComponent();
        }

        public string Getimagen64()
        {
            if(photo != null) 
            {
                using(MemoryStream memory = new MemoryStream())
                {
                    Stream stream =photo.GetStream();
                    stream.CopyTo(memory);
                    byte[] fotobyte = memory.ToArray();

                    string Base64 = Convert.ToBase64String(fotobyte);

                    return Base64;
                }
            }
           return null; 
        }

        public byte[] GetimagenBytes()
        {
            if (photo != null)
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    Stream stream = photo.GetStream();
                    stream.CopyTo(memory);
                    byte[] fotobyte = memory.ToArray();
                    return fotobyte;
                }
            }
            return null;
        }


        private async void btnfoto_Clicked(object sender, EventArgs e)
        {
            photo = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory= "MYAPP",
                Name = "fot.jpg",
                SaveToAlbum = true,
            });
            if(photo != null ) 
            {
                foto.Source = ImageSource.FromStream(()=> { return photo.GetStream(); });
            }

        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.PageList());
        }

        private async void ToolbarItem_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.PageMapa());
        }



        protected override async void OnAppearing()
        {
            base.OnAppearing();

            while (true)
            {
                try
                {
                    var location = await Geolocation.GetLocationAsync();

                    if (location != null)
                    {
                        longitud.Text = location.Longitude.ToString();
                        latitud.Text = location.Latitude.ToString();
                    }
                }
                catch (Exception ex)
                {
                    // Manejar cualquier excepción que pueda ocurrir al obtener la ubicación
                    // Aquí puedes mostrar un mensaje de error o realizar cualquier otra acción necesaria
                }

                // Espera un intervalo de tiempo antes de obtener la siguiente ubicación
                await Task.Delay(TimeSpan.FromSeconds(10)); // Por ejemplo, 10 segundos
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }


        private async void add_Clicked(object sender, EventArgs e)
        {
            var sit = new Models.Sitios
            {
                Latitud = longitud.Text,
                Longitud = latitud.Text,
                Descripcion = description.Text,
                Foto = GetimagenBytes()

            };

           if (await App.Instancia.Addsitio(sit) > 0)
            {
                await DisplayAlert("Aviso", "ingreso con exito", "OK");
            }
            else
            {
                await DisplayAlert("Aviso", "error ", "OK");
            }


        }
    }
}