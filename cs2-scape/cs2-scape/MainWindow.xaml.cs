using System.Windows;
using cs2_scape.Enums;
using cs2_scape.Repositories;
using Microsoft.Extensions.DependencyInjection;


namespace cs2_scape;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        UserFilesRepository files = new();
        files.AddFile(ConfigFileTypes.Autoexec, "C:\\autoexec.cfg");
        files.AddFile(ConfigFileTypes.VideoSettings, "C:\\videosettings.cfg");
        //files.AddFile(ConfigFileTypes.Custom, "C:\\custom1.cfg");
        //files.AddFile(ConfigFileTypes.Custom, "C:\\custom2.cfg");
        //files.AddFile(ConfigFileTypes.Custom, "C:\\custom3.cfg");

        string autoexecPath = files.GetExclusiveConfigFile(ConfigFileTypes.Autoexec);
        string videoSettingsPath = files.GetExclusiveConfigFile(ConfigFileTypes.VideoSettings);
        List<string> customPaths = files.GetCustomConfigFiles() ?? new List<string>();

        MessageBox.Show($"Autoexec path is: {autoexecPath}");
        MessageBox.Show($"Videosettings path is: {videoSettingsPath}");
        foreach (var customConfig in customPaths)
        {
            MessageBox.Show($"Custom Config {customPaths.IndexOf(customConfig) + 1} Path: {customConfig}");
        }
        InitializeComponent();
    }
}