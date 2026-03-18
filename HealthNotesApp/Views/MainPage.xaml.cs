using HealthNotesApp.ViewModels;

namespace HealthNotesApp
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage(MainViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }

}
