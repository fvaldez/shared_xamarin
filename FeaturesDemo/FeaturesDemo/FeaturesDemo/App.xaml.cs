using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using FeaturesDemo.Models;

namespace FeaturesDemo
{
    public partial class App : Application
    {
        private static Data.LocalDatabase localDatabase;
        private static Models.User currentUser;

        internal static Data.LocalDatabase LocalDatabase
        {
            get
            {
                if (localDatabase == null)
                {
                    localDatabase = new Data.LocalDatabase(DependencyService.Get<Interfaces.IFileHelper>().GetLocalFilePath("LocalDB.db3"));
                }

                return localDatabase;
            }
        }

        internal static Models.User CurrentUser
        {
            get
            {
                return currentUser;
            }

            set
            {
                currentUser = value;
            }
        }

        public App()
        {
            InitializeComponent();

            App.CurrentUser = new User();

            MainPage = new NavigationPage(new Pages.Security.LoginPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
