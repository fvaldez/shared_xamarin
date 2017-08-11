using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FeaturesDemo.Data.Extensions;

namespace FeaturesDemo.Pages.Security
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            DefineLayout();

            SizeChanged += OnSizeChanged;
        }

        private void OnSizeChanged(object sender, EventArgs e)
        {
            DefineLayout();
        }

        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            App.CurrentUser.Email = txtEmail.Text;
            App.CurrentUser.Password = txtPassword.Text;

            if (App.CurrentUser.ValidateUserLogin())
            {
                App.CurrentUserSettings.LoadUserSettingsByUserID(App.CurrentUser.ID);
                App.SaveAccountSessionInfo(true);
                App.Current.MainPage = new Pages.MainPage();
            }

            else
            {
                DisplayAlert("Login", "Incorrect credentials", "OK");
            }
        }

        private async void btnCreateAccount_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pages.Security.CreateAccountPage());
        }

        private void DefineLayout()
        {
            if (Device.Idiom == TargetIdiom.Tablet)
            {
                if (Width > Height)
                {
                    grdMainGrid.ColumnDefinitions[1].Width = new GridLength(1, GridUnitType.Star);
                }

                else
                {
                    grdMainGrid.ColumnDefinitions[1].Width = new GridLength(2, GridUnitType.Star);
                }
            }

            else if (Device.Idiom == TargetIdiom.Phone)
            {
                grdMainGrid.ColumnDefinitions[0].Width = new GridLength(20);
                grdMainGrid.ColumnDefinitions[2].Width = new GridLength(20);
            }
        }
    }
}