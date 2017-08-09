using System;

namespace FeaturesDemo.Models
{
    public class Session
    {
        private DateTime started;
        private User loggedUser;
        private UserSettings userSettings;

        public DateTime Started
        {
            get { return started; }
            set { started = value; }
        }

        public User LoggedUser
        {
            get { return loggedUser; }
            set { loggedUser = value; }
        }

        public UserSettings UserSettings
        {
            get
            {
                return userSettings;
            }

            set
            {
                userSettings = value;
            }
        }
    }
}
