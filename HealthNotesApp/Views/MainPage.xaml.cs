namespace HealthNotesApp.Views;
using HealthNotesApp.ViewModels;
public partial class MainPage : ContentPage
{
    private readonly MainViewModel _vm;

    public MainPage(MainViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        _vm = vm;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        _vm.LoadHabits();
    }
}