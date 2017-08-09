using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FeaturesDemo.Data.Extensions;

namespace FeaturesDemo.Pages.Security
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateAccountPage : ContentPage
    {
        public CreateAccountPage()
        {
            InitializeComponent();
        }

        private void btnCreate_Clicked(object sender, EventArgs e)
        {
            Models.User newUser = new Models.User();

            newUser.Email = txtEmail.Text;
            newUser.Password = txtPassword.Text;
            newUser.Username = txtName.Text;

            newUser.SaveUser();

            DisplayAlert("User Created", "The user was created correctly. User Name: " + newUser.Username.ToString() + " Email: " + newUser.Email, "OK");
        }

        private async void btnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}