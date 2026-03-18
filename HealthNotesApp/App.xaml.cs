namespace HealthNotesApp;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        MainPage = new AppShell();
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