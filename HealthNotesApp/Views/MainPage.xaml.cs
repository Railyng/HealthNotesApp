namespace HealthNotesApp.Views;
using HealthNotesApp.ViewModels;
public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}