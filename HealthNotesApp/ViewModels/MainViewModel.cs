using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HealthNotesApp.Models;
using HealthNotesApp.Services;
using System.Collections.ObjectModel;

namespace HealthNotesApp.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly IHabitService _habitService;

        public ObservableCollection<Habit> Habits { get; set; } = new();

        public MainViewModel(IHabitService habitService)
        {
            _habitService = habitService;
            LoadHabits();
        }

        private void LoadHabits()
        {
            var habits = _habitService.GetHabits();
            Habits.Clear();

            foreach (var habit in habits)
                Habits.Add(habit);
        }

        [RelayCommand]
        public void AddHabit()
        {
            _habitService.AddHabit(new Habit
            {
                Name = "Beber agua",
                Goal = 8,
                Progress = 0
            });

            LoadHabits();
        }
    }
}