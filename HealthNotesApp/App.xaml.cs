namespace HealthNotesApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }

        protected override void OnStart()
        {
            Console.WriteLine("App inició");
        }

        protected override void OnSleep()
        {
            Console.WriteLine("App en segundo plano");
        }

        protected override void OnResume()
        {
            Console.WriteLine("App reanudada");
        }
    }
}