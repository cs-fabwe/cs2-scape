using System.Windows;
using Microsoft.AspNetCore.Components.WebView.Wpf;
using Microsoft.Extensions.DependencyInjection;

namespace cs2_scape;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    /// <summary>
    /// Startup Method for the Application. Takes care of setting up Services and
    /// showing windows.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Cs2scape_Startup(object sender, StartupEventArgs e)
    {
        // Create new ServiceCollection
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddWpfBlazorWebView();
        
        // Build service provider from service collection and add
        // it to resources
        var serviceProvider = serviceCollection.BuildServiceProvider();
        Resources.Add("services", serviceProvider);
        
        // Create new instance of the MainWindow class
        var mainWindow = new MainWindow
        {
            Title = "cs2-scape",
            ShowInTaskbar = true,
            WindowStartupLocation = WindowStartupLocation.CenterScreen
        };
        
        // Show main window
        mainWindow.Show();
    }
}