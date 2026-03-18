using HealthNotesApp.Models;
using System.Collections.Generic;

namespace HealthNotesApp.Services
{
    public class HabitService : IHabitService
    {
        private List<Habit> _habits = new();

        public List<Habit> GetHabits()
        {
            return _habits;
        }

        public void AddHabit(Habit habit)
        {
            _habits.Add(habit);
        }
    }
}