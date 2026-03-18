using HealthNotesApp.ViewModels;

namespace HealthNotesApp.Views;

public partial class AddHabitPage : ContentPage
{
	public AddHabitPage(AddHabitViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}