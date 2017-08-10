using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FeaturesDemo.Data.Extensions;

namespace FeaturesDemo.Pages.Location
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GetLocationPage : ContentPage
    {
        public GetLocationPage()
        {
            InitializeComponent();
            LoadInfo();
        }
        
        private void btnOpenMaps_Clicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Models.Location selectedLocation = btn.CommandParameter as Models.Location;
        }

        private void LoadInfo()
        {
            lvwLocations.ItemsSource = LocationExt.GetLastNLocations(10);
        }

        private void lvwLocations_Refreshing(object sender, EventArgs e)
        {
            LoadInfo();

            lvwLocations.EndRefresh();
        }

        private void lvwLocations_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Models.Location selectedLocation = e.Item as Models.Location;

            string coordinates = selectedLocation.Latitude.ToString() + ',' + selectedLocation.Longitude.ToString();

            Device.OpenUri(new Uri("https://www.google.com/maps/search/?api=1&query=" + coordinates));
        }

        private void lvwLocations_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            lvwLocations.SelectedItem = null;

        }
    }
}