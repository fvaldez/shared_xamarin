using SQLite;

namespace FeaturesDemo.Models
{
    public class BaseModel
    {
        private int id;

        [PrimaryKey, AutoIncrement]
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

    }
}
