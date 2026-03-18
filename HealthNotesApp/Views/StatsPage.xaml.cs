using HealthNotesApp.ViewModels;

namespace HealthNotesApp.Views;

public partial class StatsPage : ContentPage
{
    public StatsPage(StatsViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}