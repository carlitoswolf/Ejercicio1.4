using System;
using Xamarin.Forms;
using System.IO;

namespace Ejercicio1._4
{
    public partial class App : Application
    {
        static Controllers.dbController db;

        public static Controllers.dbController Instancia
        {
            get
            {
                if (db == null)
                {
                    string dbname = "Test.db3";
                    string dbpath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    string dbfull = Path.Combine(dbpath, dbname);
                    db = new Controllers.dbController(dbfull);
                }

                return db;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
