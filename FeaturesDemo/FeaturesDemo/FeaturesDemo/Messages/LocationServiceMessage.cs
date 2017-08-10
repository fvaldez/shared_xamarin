namespace FeaturesDemo.Messages
{
    public class LocationServiceMessage
    {
        private LocationServiceAction action;

        public LocationServiceAction Action
        {
            get { return action; }
            set { action = value; }
        }

        private Models.UserSettings settings;

        public Models.UserSettings Settings
        {
            get { return settings; }
            set { settings = value; }
        }
    }

    public enum LocationServiceAction
    {
        Start,
        Stop
    }
}
