using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HealthNotesApp.Models;
using HealthNotesApp.Services;
using System.Collections.ObjectModel;
using HealthNotesApp.Views;

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

        public async void LoadHabits()
        {
            Habits.Clear();

            var habits = await _habitService.GetHabitsAsync();

            foreach (var habit in habits)
                Habits.Add(habit);
        }

        [RelayCommand]
        public async Task GoToAddHabit()
        {
            await Shell.Current.GoToAsync(nameof(AddHabitPage));
        }
    }
}