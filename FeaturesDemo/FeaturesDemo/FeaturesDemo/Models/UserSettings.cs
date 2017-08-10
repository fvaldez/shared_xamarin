using System;

namespace FeaturesDemo.Models
{
    public class UserSettings : BaseModel
    {
        private int userID;

        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        private bool locationLog;

        public bool LocationLog
        {
            get { return locationLog; }
            set { locationLog = value; }
        }

        private TimeSpan locationInterval;

        public TimeSpan LocationInterval
        {
            get { return locationInterval; }
            set { locationInterval = value; }
        }

        private bool sessionValidation;

        public bool SessionValidation
        {
            get { return sessionValidation; }
            set { sessionValidation = value; }
        }


        private TimeSpan sessionDuration;

        public TimeSpan SessionDuration
        {
            get { return sessionDuration; }
            set { sessionDuration = value; }
        }

    }
}
