using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeaturesDemo.Models
{
    public class Location : BaseModel
    {
        private int userID;

        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }


        private double latitude;

        public double Latitude
        {
            get { return latitude; }
            set { latitude = value; }
        }

        private double longitude;

        public double Longitude
        {
            get { return longitude; }
            set { longitude = value; }
        }

        private DateTime time;

        public DateTime Time
        {
            get { return time; }
            set { time = value; }
        }

    }
}
