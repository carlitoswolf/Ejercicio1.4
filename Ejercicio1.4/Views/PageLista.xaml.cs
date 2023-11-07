using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Ejercicio1._4.Models;


namespace Ejercicio1._4.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageLista : ContentPage
    {

        public int id;
        public PageLista()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            list.ItemsSource = await App.Instancia.GetListPople();
        }

        private async void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var SelectedItem = e.CurrentSelection[0] as Data;
            id = SelectedItem.id;
            await Navigation.PushAsync(new Views.PageDetalleRegistro(id));
            Console.WriteLine(SelectedItem.id);
             
        }

        private Task DisplayAlert(string v1, object value1, string v2, object value2, ContentPage customPage)
        {
            throw new NotImplementedException();
        }
    }
}