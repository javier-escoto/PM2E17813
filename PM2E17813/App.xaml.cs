using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2E17813
{
    public partial class App : Application
    {
        static Controllers.BDSit BDSit;

        public static Controllers.BDSit Instancia
        {
            get 
            {
                if (BDSit == null)
                {
                    string dbname = "proc.db3";
                    string dbpath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    string dbfulp = Path.Combine(dbpath, dbname);
                    BDSit = new Controllers.BDSit(dbfulp);
                }

                return BDSit;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.PagePrincipal());
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
