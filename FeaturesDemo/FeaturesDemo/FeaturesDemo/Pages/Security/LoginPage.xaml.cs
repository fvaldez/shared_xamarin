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
        }

        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            App.CurrentUser.Email = txtEmail.Text;
            App.CurrentUser.Password = txtPassword.Text;

            if (App.CurrentUser.ValidateUserLogin())
            {
                App.Current.MainPage = new MainPage();
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
    }
}