using System.Linq;

namespace FeaturesDemo.Data.Extensions
{
    public static class UserExt
    {
        public static void GetUserByID(this Models.User user, int id)
        {
            user = App.LocalDatabase.GetByIDAsync<Models.User>(id).Result;
        }

        public static void SaveUser(this Models.User user)
        {
            int id = App.LocalDatabase.SaveAsync<Models.User>(user).Result;

            user.GetUserByID(id);
        }

        public static bool ValidateUserLogin(this Models.User user)
        {
            Models.User dbUser = App.LocalDatabase.GetTable<Models.User>().Result.Where(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault();

            if (dbUser != null && dbUser.ID > 0)
            {
                user.ID = dbUser.ID;
                user.Username = dbUser.Username;

                return true;
            }

            return false;
        }
    }
}
