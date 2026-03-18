using HealthNotesApp.Models;

namespace HealthNotesApp.Services
{
    public interface IHabitService
    {
        Task<List<Habit>> GetHabitsAsync();
        Task AddHabitAsync(Habit habit);
    }
}