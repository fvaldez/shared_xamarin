using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Auth;
using Xamarin.Forms;
using FeaturesDemo.Models;
using Newtonsoft.Json;

namespace FeaturesDemo
{
    public partial class App : Application
    {
        public static readonly string AppName = "FeaturesDemo";

        private static Data.LocalDatabase localDatabase;
        private static User currentUser;
        private static UserSettings currentUserSettings;

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

        internal static User CurrentUser
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

        public static UserSettings CurrentUserSettings
        {
            get
            {
                return currentUserSettings;
            }

            set
            {
                currentUserSettings = value;
            }
        }

        public App()
        {
            InitializeComponent();

            App.CurrentUser = new User();
            App.CurrentUserSettings = new UserSettings();

            if (ValidateSession(true))
            {
                MainPage = new Pages.MainPage();
            }

            else
            {
                MainPage = new NavigationPage(new Pages.Security.LoginPage());
            }
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

        internal void ReviewUserSettings()
        {
            if (CurrentUserSettings.LocationLog)
            {
                MessagingCenter
                    .Send<Messages.LocationServiceMessage>(
                        new Messages.LocationServiceMessage()
                        {
                            Action = Messages.LocationServiceAction.Start,
                            Settings = CurrentUserSettings

                        },
                        "AppLocationServiceMessage");
            }
        }

        internal static bool ValidateSession(bool loadData)
        {
            Account acc = AccountStore.Create().FindAccountsForService(App.AppName).FirstOrDefault();

            if (acc != null)
            {
                Session currSession = JsonConvert.DeserializeObject<Session>(acc.Properties["sessionObj"]);

                if (DateTime.Now < currSession.Started + (currSession.UserSettings != null ? currSession.UserSettings.SessionDuration : new TimeSpan()))
                {
                    if (loadData)
                    {
                        CurrentUser = currSession.LoggedUser;
                        CurrentUserSettings = currSession.UserSettings;
                    }

                    return true;
                }
            };

            return false;
        }

        internal static void SaveAccountSessionInfo(bool resetSessionStart)
        {
            Session session;

            if (resetSessionStart)
            {

                session = new Session()
                {
                    Started = DateTime.Now,
                    LoggedUser = App.CurrentUser,
                    UserSettings = App.CurrentUserSettings
                };
            }

            else
            {
                Account savedAccount = AccountStore.Create().FindAccountsForService(App.AppName).FirstOrDefault();

                session = JsonConvert.DeserializeObject<Session>(savedAccount.Properties["sessionObj"]);
                session.LoggedUser = App.CurrentUser;
                session.UserSettings = App.CurrentUserSettings;
            }

            Account acc = new Account();

            acc.Properties.Add("sessionObj", JsonConvert.SerializeObject(session));

            AccountStore.Create().Save(acc, App.AppName);
        }
    }
}
