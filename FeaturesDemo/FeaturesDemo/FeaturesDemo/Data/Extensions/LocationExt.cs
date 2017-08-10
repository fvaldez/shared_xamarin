using System.Collections.Generic;
using System.Linq;

namespace FeaturesDemo.Data.Extensions
{
    public static class LocationExt
    {
        public static List<Models.Location> GetAllLocationsTimeDescending(this Models.Location location)
        {
            return App.LocalDatabase.GetTable<Models.Location>().Result.OrderByDescending(x => x.Time).ToList();
        }

        public static bool GetLocationByID(this Models.Location location, int id)
        {
            Models.Location dbLocation = App.LocalDatabase.GetByIDAsync<Models.Location>(id).Result;

            if (dbLocation != null)
            {
                location.ID = dbLocation.ID;
                location.Latitude = dbLocation.Latitude;
                location.Longitude = dbLocation.Longitude;
                location.Time = dbLocation.Time;

                return true;
            }

            return false;
        }

        public static List<Models.Location> GetLastNLocations(int numberOfLocations)
        {
            return App.LocalDatabase.GetTable<Models.Location>().Result.OrderByDescending(x => x.Time).Take(numberOfLocations).ToList();
        }

        public static bool SaveLocation(this Models.Location location)
        {
            int id = App.LocalDatabase.SaveAsync<Models.Location>(location).Result;

            if (id > 0)
            {
                return location.GetLocationByID(id);
            }

            return false;
        }
    }
}
