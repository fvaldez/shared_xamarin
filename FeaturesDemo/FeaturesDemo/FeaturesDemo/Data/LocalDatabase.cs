using SQLite;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FeaturesDemo.Data
{
    public class LocalDatabase
    {
        readonly SQLiteAsyncConnection database;

        public LocalDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);

            database.CreateTableAsync<Models.User>().Wait();
            database.CreateTableAsync<Models.UserSettings>().Wait();
            database.CreateTableAsync<Models.Location>().Wait();
        }

        public Task<T> GetByIDAsync<T>(int id) where T : Models.BaseModel, new()
        {
            return database.Table<T>().Where(x => x.ID == id).FirstOrDefaultAsync();
        }

        public Task<List<T>> GetTable<T>() where T : new()
        {
            return database.Table<T>().ToListAsync();
        }

        public Task<int> SaveAsync<T>(T item) where T : Models.BaseModel
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }

            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteAsync<T>(T item) where T : Models.BaseModel
        {
            return database.DeleteAsync(item);
        }
    }
}
