using CommunityToolkit.Mvvm.ComponentModel;
using HealthNotesApp.Services;
using Microcharts;
using SkiaSharp;

namespace HealthNotesApp.ViewModels
{
    public partial class StatsViewModel : ObservableObject
    {
        private readonly IHabitService _habitService;

        [ObservableProperty]
        private Chart habitChart;

        [ObservableProperty]
        private int totalHabits;

        [ObservableProperty]
        private double completionRate;

        public StatsViewModel(IHabitService habitService)
        {
            _habitService = habitService;
            LoadStats();
        }

        private async void LoadStats()
        {
            var habits = await _habitService.GetHabitsAsync();

            TotalHabits = habits.Count;

            int completed = habits.Count(h => h.Progress >= h.Goal);

            CompletionRate = habits.Count == 0 ? 0 :
                (double)completed / habits.Count * 100;

            HabitChart = new DonutChart
            {
                Entries = new[]
                {
                    new ChartEntry(completed)
                    {
                        Label = "Completados",
                        ValueLabel = completed.ToString(),
                        Color = SKColor.Parse("#4CAF50")
                    },
                    new ChartEntry(habits.Count - completed)
                    {
                        Label = "Pendientes",
                        ValueLabel = (habits.Count - completed).ToString(),
                        Color = SKColor.Parse("#F44336")
                    }
                }
            };
        }
    }
}