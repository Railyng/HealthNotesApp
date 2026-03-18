using HealthNotesApp.Models;
using System.Collections.Generic;

namespace HealthNotesApp.Services
{
    public interface IHabitService
    {
        List<Habit> GetHabits();
        void AddHabit(Habit habit);
    }
}