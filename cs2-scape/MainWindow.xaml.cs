using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using Microsoft.Extensions.DependencyInjection;


namespace cs2_scape;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
	public MainWindow()
    {
		InitializeComponent();
    }

	private void Grid_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
	{
        DragMove();
	}

	private void btnClose_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
	{
		
	}

	private void btnClose_Click(object sender, RoutedEventArgs e)
	{
		Application.Current.Shutdown();
	}

}