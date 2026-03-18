using Microsoft.Extensions.Logging;
using HealthNotesApp.Services;
using HealthNotesApp.ViewModels;
using HealthNotesApp.Views;

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


            // Views
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<AddHabitPage>();

            return builder.Build();
        }
    }
}
