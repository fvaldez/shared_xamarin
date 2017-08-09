using System.Linq;

namespace FeaturesDemo.Data.Extensions
{
    public static class UserSettingsExt
    {
        public static bool LoadUserSettingsByID(this Models.UserSettings userSettings, int id)
        {
            Models.UserSettings settings = App.LocalDatabase.GetByIDAsync<Models.UserSettings>(id).Result;

            if (settings != null && settings.ID > 0)
            {
                userSettings.ID = settings.ID;
                userSettings.LocationLog = settings.LocationLog;
                userSettings.Interval = settings.Interval;
                userSettings.UserID = settings.UserID;
                userSettings.SessionValidation = settings.SessionValidation;
                userSettings.SessionDuration = settings.SessionDuration;

                return true;
            }

            return false;
        }

        public static bool LoadUserSettingsByUserID(this Models.UserSettings userSettings, int userID)
        {
            Models.UserSettings settings = App.LocalDatabase.GetTable<Models.UserSettings>().Result.Where(x => x.UserID == userID).FirstOrDefault();

            if (settings != null && settings.ID > 0)
            {
                userSettings.ID = settings.ID;
                userSettings.LocationLog = settings.LocationLog;
                userSettings.Interval = settings.Interval;
                userSettings.UserID = settings.UserID;
                userSettings.SessionValidation = settings.SessionValidation;
                userSettings.SessionDuration = settings.SessionDuration;

                return true;
            }

            return false;
        }

        public static bool SaveUserSettings(this Models.UserSettings userSettings)
        {
            int id = App.LocalDatabase.SaveAsync<Models.UserSettings>(userSettings).Result;

            if (id > 0)
            {
                return userSettings.LoadUserSettingsByID(id);
            }

            return false;
        }
    }
}
