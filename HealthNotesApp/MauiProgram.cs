using Microsoft.Extensions.Logging;
using HealthNotesApp.Services;
using HealthNotesApp.ViewModels;
using HealthNotesApp.Views;
using Microcharts.Maui;

namespace HealthNotesApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Servicios
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "habits.db3");//Base de datos
            builder.Services.AddSingleton(new HabitDatabase(dbPath));
            builder.Services.AddSingleton<IHabitService, HabitService>();


            // ViewModels
            builder.Services.AddTransient<MainViewModel>();
            builder.Services.AddTransient<AddHabitViewModel>();
            builder.Services.AddTransient<StatsViewModel>();


            // Views
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<AddHabitPage>();
            builder.Services.AddTransient<StatsPage>();

            builder.UseMauiApp<App>()
                   .UseMicrocharts();

            return builder.Build();
        }
    }
}
