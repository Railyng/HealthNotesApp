using HealthNotesApp.Views;
namespace HealthNotesApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(AddHabitPage), typeof(AddHabitPage));

        }
    }
}
