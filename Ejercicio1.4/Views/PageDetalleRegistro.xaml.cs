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
    public partial class PageDetalleRegistro : ContentPage
    {
        private int idSearch;
        public PageDetalleRegistro(int id)
        {
            InitializeComponent();
            idSearch = id;
            Console.WriteLine(id);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            lista.ItemsSource = await App.Instancia.GetPersonForId(idSearch);


        }


        private void lista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}