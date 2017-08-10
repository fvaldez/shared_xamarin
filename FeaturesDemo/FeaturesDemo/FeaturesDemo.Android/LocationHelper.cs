using System;

using Xamarin.Forms;
using FeaturesDemo.Droid;
using FeaturesDemo.Data.Extensions;
using FeaturesDemo.Interfaces;
using PerpetualEngine.Location;
using FeaturesDemo.Models;

[assembly: Dependency(typeof(LocationHelper))]
namespace FeaturesDemo.Droid
{
    class LocationHelper : ILocationHelper
    {
        public static SimpleLocationManager manager;

        public Models.Location StartLocationManager()
        {
            Models.Location currentLocation = new Models.Location();

            manager = new SimpleLocationManager();
            manager.LocationUpdated += OnLocationUpdated;
            manager.StartLocationUpdates(LocationAccuracy.Balanced, 0, TimeSpan.FromHours(2), TimeSpan.FromMinutes(5));

            return currentLocation;
        }

        public void OnLocationUpdated()
        {
            Models.Location locModel = new Models.Location()
            {
                Latitude = manager.LastLocation.Latitude,
                Longitude = manager.LastLocation.Longitude,
                Time = DateTime.Now
            };

            locModel.SaveLocation();
        }
    }
}