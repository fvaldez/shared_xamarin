using System;

using Android.App;
using Android.Content;
using Android.OS;
using Xamarin.Forms;

namespace FeaturesDemo.Droid.Services
{
    [Service]
    public class LocationService : Service
    {
        public override IBinder OnBind(Intent intent)
        {
            return null;
        }

        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            TimeSpan locationInterval = TimeSpan.FromTicks(intent.GetLongExtra("com.android.FeaturesDemo.LocationInterval", TimeSpan.FromMinutes(5).Ticks));
            TimeSpan sessionDuration = TimeSpan.FromTicks(intent.GetLongExtra("com.android.FeaturesDemo.SessionDuration", TimeSpan.FromMinutes(5).Ticks));

            DependencyService.Get<Interfaces.ILocationHelper>().StartLocationManager();

            return StartCommandResult.RedeliverIntent;
        }

        public override void OnDestroy()
        {
            LocationHelper.manager.StopLocationUpdates();

            base.OnDestroy();
        }
    }
}