using System.Windows;

namespace cs2_scape;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    

    private void Cs2scape_Startup(object sender, StartupEventArgs e)
    {
        var mainWindow = new MainWindow
        {
            Title = "cs2-scape"
        };
        mainWindow.Show();
    }
}