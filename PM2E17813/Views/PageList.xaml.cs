using PM2E17813.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace PM2E17813.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageList : ContentPage
    {
        public PageList()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            Listsitios.ItemsSource = await App.Instancia.GetAll();
        }

        private void Listsitios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Sitios selectedSitio = (Sitios)Listsitios.SelectedItem;

            if (selectedSitio != null)
            {
                bool confirmacion = await DisplayAlert("Confirmar", "¿Desea ir a la ubicación?", "Sí", "No");

                if (confirmacion)
                {
                    // Navegar a la página del mapa y pasar el objeto selectedSitio como parámetro
                    await Navigation.PushAsync(new PageMapa());
                }
            }



        }
    }
}