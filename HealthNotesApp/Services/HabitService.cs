using HealthNotesApp.Models;

namespace HealthNotesApp.Services
{
    public class HabitService : IHabitService
    {
        private readonly HabitDatabase _db;

        public HabitService(HabitDatabase db)
        {
            _db = db;
        }

        public async Task<List<Habit>> GetHabitsAsync()
        {
            return await _db.GetHabitsAsync();
        }

        public async Task AddHabitAsync(Habit habit)
        {
            await _db.AddHabitAsync(habit);
        }
    }
}