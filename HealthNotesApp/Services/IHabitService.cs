using HealthNotesApp.Models;

namespace HealthNotesApp.Services
{
    public interface IHabitService
    {
        Task<List<Habit>> GetHabitsAsync();
        Task AddHabitAsync(Habit habit);
        Task DeleteHabitAsync(Habit habit);
        Task UpdateHabitAsync(Habit habit);
    }
}