using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HealthNotesApp.Models;
using HealthNotesApp.Services;
using System.Collections.ObjectModel;

namespace HealthNotesApp.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly IHabitService _habitService;

    public ObservableCollection<Habit> Habits { get; set; } = new();

    public MainViewModel(IHabitService habitService)
    {
        _habitService = habitService;
    }

    public async Task Init()
    {
        if (_habitService is HabitService service)
            await service.InitAsync();

        await LoadHabits();
    }

    public async Task LoadHabits()
    {
        Habits.Clear();

        var habits = await _habitService.GetHabitsAsync();

        foreach (var habit in habits)
        {
            Habits.Add(habit);
        }
    }

    [RelayCommand]
    public async Task AddHabit()
    {
        string nombre = await Application.Current.MainPage.DisplayPromptAsync(
            "Nuevo hábito",
            "Nombre:");

        if (string.IsNullOrWhiteSpace(nombre))
            return;

        string metaTexto = await Application.Current.MainPage.DisplayPromptAsync(
            "Meta",
            "Cantidad objetivo:",
            initialValue: "5");

        if (!int.TryParse(metaTexto, out int meta))
            meta = 5;

        var habit = new Habit
        {
            Name = nombre,
            Goal = meta,
            Progress = 0
        };

        await _habitService.AddHabitAsync(habit);
        await LoadHabits();
    }

    // 🗑️ ELIMINAR
    [RelayCommand]
    public async Task DeleteHabit(Habit habit)
    {
        if (habit == null) return;

        await _habitService.DeleteHabitAsync(habit);
        await LoadHabits();
    }

    // ➕ PROGRESO
    [RelayCommand]
    public async Task IncreaseProgress(Habit habit)
    {
        if (habit == null) return;

        if (habit.Progress < habit.Goal)
            habit.Progress++;

        await _habitService.UpdateHabitAsync(habit);
        await LoadHabits();
    }

    // ✏️ EDITAR
    [RelayCommand]
    public async Task EditHabit(Habit habit)
    {
        if (habit == null) return;

        string nuevoNombre = await Application.Current.MainPage.DisplayPromptAsync(
            "Editar hábito",
            "Nuevo nombre:",
            initialValue: habit.Name);

        if (!string.IsNullOrWhiteSpace(nuevoNombre))
        {
            habit.Name = nuevoNombre;
            await _habitService.UpdateHabitAsync(habit);
            await LoadHabits();
        }
    }
}