using SQLite;

namespace HealthNotesApp.Models
{
    public class Habit
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }
        public int Goal { get; set; }
        public int Progress { get; set; }
    }
}