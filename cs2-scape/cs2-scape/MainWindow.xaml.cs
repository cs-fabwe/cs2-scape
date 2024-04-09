using System.Windows;
using Microsoft.Extensions.DependencyInjection;


namespace cs2_scape;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddWpfBlazorWebView();

        var serviceProvider = serviceCollection.BuildServiceProvider();
        Resources.Add("services", serviceProvider);
        
        InitializeComponent();
    }
}