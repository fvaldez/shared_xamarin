using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FeaturesDemo.Data.Extensions;

namespace FeaturesDemo.Pages.Settings
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
            LoadUserSettings();
        }

        private void LoadUserSettings()
        {
            if (App.CurrentUserSettings.UserID == App.CurrentUser.ID)
            {
                swcActivateLog.On = App.CurrentUserSettings.LocationLog;
                pckHour.SelectedItem = App.CurrentUserSettings.LocationInterval.Hours.ToString();
                pckMin.SelectedItem = App.CurrentUserSettings.LocationInterval.Minutes.ToString();

                swcActivateSession.On = App.CurrentUserSettings.SessionValidation;
                pckHourSession.SelectedItem = App.CurrentUserSettings.SessionDuration.Hours.ToString();
                pckMinSession.SelectedItem = App.CurrentUserSettings.SessionDuration.Minutes.ToString();

            }

            else
            {
                swcActivateLog.On = false;
                pckHour.SelectedIndex = 0;
                pckMin.SelectedIndex = 0;

                swcActivateSession.On = false;
                pckHourSession.SelectedIndex = 0;
                pckMinSession.SelectedIndex = 0;
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            App.CurrentUserSettings.UserID = App.CurrentUser.ID;
            App.CurrentUserSettings.LocationLog = swcActivateLog.On;
            App.CurrentUserSettings.SessionValidation = swcActivateSession.On;
            App.CurrentUserSettings.LocationInterval = new TimeSpan(Convert.ToInt32(pckHour.SelectedItem), Convert.ToInt32(pckMin.SelectedItem), 0);
            App.CurrentUserSettings.SessionDuration = new TimeSpan(Convert.ToInt32(pckHourSession.SelectedItem), Convert.ToInt32(pckMinSession.SelectedItem), 0);

            if (App.CurrentUserSettings.SaveUserSettings())
            {
                if (App.CurrentUserSettings.LocationLog)
                {
                    (App.Current as App).ReviewUserSettings();
                }

                if (App.CurrentUserSettings.SessionValidation)
                {
                    App.SaveAccountSessionInfo(false);
                }

                DisplayAlert("Settings", "Changes were saved correctly.", "OK");
            }
        }
    }
}