using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using PerpetualEngine.Location;
using Android.Content;
using Xamarin.Forms;

namespace FeaturesDemo.Droid
{
    [Activity(Label = "FeaturesDemo", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            SimpleLocationManager.SetContext(this);
            SimpleLocationManager.HowOftenShowUseLocationDialog = SimpleLocationManager.ShowUseLocationDialog.Once;
            SimpleLocationManager.HandleLocationPermission = true;
            SimpleLocationManager.ShouldShowRequestPermissionRationale = false;

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());

            MessagingCenter.Subscribe<Messages.LocationServiceMessage>(this, "AppLocationServiceMessage", ReadLocationServiceMessage);
        }

        private void ReadLocationServiceMessage(Messages.LocationServiceMessage message)
        {
            Intent intent = new Intent(this, typeof(Services.LocationService));

            switch (message.Action)
            {
                case Messages.LocationServiceAction.Start:
                    intent.PutExtra("com.android.FeaturesDemo.LocationInterval", message.Settings.LocationInterval.Ticks);
                    intent.PutExtra("com.android.FeaturesDemo.SessionDuration", message.Settings.SessionDuration.Ticks);
                    StartService(intent);
                    break;

                case Messages.LocationServiceAction.Stop:
                    StopService(intent);
                    break;
            }
        }
    }
}

