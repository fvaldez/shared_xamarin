using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FeaturesDemo.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MainPageMenuItem;
            if (item == null)
                return;

            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;

            if (Detail.Navigation.NavigationStack.Count == 1)
            {
                await Detail.Navigation.PushAsync(page);
            }

            else
            {
                Page lastPage = Detail.Navigation.NavigationStack.LastOrDefault();

                Detail.Navigation.InsertPageBefore(page, lastPage);

                await lastPage.Navigation.PopAsync();
            }

            IsPresented = false;

            MasterPage.ListView.SelectedItem = null;
        }
    }
}