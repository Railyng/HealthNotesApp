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
        private async Task SaveHabit()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Name))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "El nombre es obligatorio", "OK");
                    return;
                }

                if (!int.TryParse(Goal, out int goalValue))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "La meta debe ser un número", "OK");
                    return;
                }

                var habit = new Habit
                {
                    Name = Name,
                    Goal = goalValue,
                    Progress = 0
                };

                await _habitService.AddHabitAsync(habit);

                await Shell.Current.GoToAsync(".."); // volver
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error real", ex.Message, "OK");
            }
        }
    }
}