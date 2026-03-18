using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HealthNotesApp.Models;
using HealthNotesApp.Services;

namespace HealthNotesApp.ViewModels
{
    public partial class AddHabitViewModel : ObservableObject
    {
        private readonly IHabitService _habitService;

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private string goal;

        public AddHabitViewModel(IHabitService habitService)
        {
            _habitService = habitService;
        }

        [RelayCommand]
        public async Task Save()
        {
            if (string.IsNullOrWhiteSpace(Name))
                return;

            _habitService.AddHabit(new Habit
            {
                Name = Name,
                Goal = int.TryParse(Goal, out int g) ? g : 0,
                Progress = 0
            });

            await Shell.Current.GoToAsync("..");
        }
    }
}