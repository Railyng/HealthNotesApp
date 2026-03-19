using CommunityToolkit.Mvvm.ComponentModel;
using HealthNotesApp.Services;
using System.Collections.ObjectModel;

namespace HealthNotesApp.ViewModels;

public partial class StatsViewModel : ObservableObject
{
    private readonly IHabitService _habitService;

    public ObservableCollection<ChartItem> ChartData { get; set; } = new();

    public StatsViewModel(IHabitService habitService)
    {
        _habitService = habitService;
    }

    public async Task LoadChart()
    {
        ChartData.Clear();

        var habits = await _habitService.GetHabitsAsync();

        foreach (var habit in habits)
        {
            double percentage = habit.Goal == 0
                ? 0
                : (habit.Progress * 1.0 / habit.Goal);

            ChartData.Add(new ChartItem
            {
                Name = habit.Name,
                Scale = percentage, // 🔥 0 a 1 (clave)
                PercentageText = $"{percentage * 100:F0}%"
            });
        }
    }
}