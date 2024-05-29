using System.Data.SQLite;

namespace BLAAutomation
{
    public class BasicObject
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public BasicObject(int id)
        {
            Id = id;
        }
    }
}