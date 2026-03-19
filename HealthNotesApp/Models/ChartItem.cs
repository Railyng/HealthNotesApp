namespace HealthNotesApp.ViewModels;

public class ChartItem
{
    public string Name { get; set; }

    public double Scale { get; set; } // 🔥 valor entre 0 y 1

    public string PercentageText { get; set; }
}