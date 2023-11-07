using Plugin.Media;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace Ejercicio1._4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        Plugin.Media.Abstractions.MediaFile photo = null;
        public MainPage()
        {
            InitializeComponent();
        }

        public byte[] ImagetoArrayByte()
        {
            if (photo != null)
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    Stream stream = photo.GetStream();
                    stream.CopyTo(memory);
                    byte[] data = memory.ToArray();
                    return data;
                }
            }

            return null;
        }

        private async void btnfoto_Clicked(object sender, EventArgs e)
        {

            photo = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "MIALBUM",
                Name = "Foto.jpg",
                SaveToAlbum = true
            });

            if (photo != null)
            {
                foto.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
            }
        }

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            var information = new Models.Data
            {
                nombres = _nombre.Text,
                descripcion = _des.Text,
                foto = ImagetoArrayByte()
            };

            if (await App.Instancia.AddPeople(information) > 0)
            {
                await DisplayAlert("INFORMACION", "Registro Hecho", "OK");
                clean();
            }
            else
            {
                await DisplayAlert("ERROR", "Ha Ocurrido un Error", "OK");
            }
        }

        private async void btnLista_Clicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new Views.PageLista());
        }

        private void clean()
        {
            _nombre.Text = "";
            _des.Text = "";
            foto.Source = null;

        }
    }
}
