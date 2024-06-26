using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using Microsoft.AspNetCore.Components.WebView.Wpf;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Web.WebView2.WinForms;

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
            Width = 1600,
            Height = 900,
            WindowStartupLocation = WindowStartupLocation.CenterScreen
        };
		mainWindow.SourceInitialized += windowMain_SourceInitialized;
        
        // Show main window
        mainWindow.Show();
    }
	//Taken from stackoverflow to prevent window overflowing. https://stackoverflow.com/a/71391896
	private void windowMain_SourceInitialized(object? sender, EventArgs e)
	{
		((HwndSource)PresentationSource.FromVisual(MainWindow)).AddHook(HookProc);
	}

	public static IntPtr HookProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
	{
		if (msg == WM_GETMINMAXINFO)
		{
			// We need to tell the system what our size should be when maximized. Otherwise it will
			// cover the whole screen, including the task bar.
			MINMAXINFO mmi = (MINMAXINFO)Marshal.PtrToStructure(lParam, typeof(MINMAXINFO));

			// Adjust the maximized size and position to fit the work area of the correct monitor
			IntPtr monitor = MonitorFromWindow(hwnd, MONITOR_DEFAULTTONEAREST);

			if (monitor != IntPtr.Zero)
			{


				MONITORINFO monitorInfo = new MONITORINFO();
				monitorInfo.cbSize = Marshal.SizeOf(typeof(MONITORINFO));
				GetMonitorInfo(monitor, ref monitorInfo);
				RECT rcWorkArea = monitorInfo.rcWork;
				RECT rcMonitorArea = monitorInfo.rcMonitor;
				mmi.ptMaxPosition.X = Math.Abs(rcWorkArea.Left - rcMonitorArea.Left);
				mmi.ptMaxPosition.Y = Math.Abs(rcWorkArea.Top - rcMonitorArea.Top);
				mmi.ptMaxSize.X = Math.Abs(rcWorkArea.Right - rcWorkArea.Left);
				mmi.ptMaxSize.Y = Math.Abs(rcWorkArea.Bottom - rcWorkArea.Top);
			}

			Marshal.StructureToPtr(mmi, lParam, true);
		}

		return IntPtr.Zero;
	}

	private const int WM_GETMINMAXINFO = 0x0024;

	private const uint MONITOR_DEFAULTTONEAREST = 0x00000002;

	[DllImport("user32.dll")]
	private static extern IntPtr MonitorFromWindow(IntPtr handle, uint flags);

	[DllImport("user32.dll")]
	private static extern bool GetMonitorInfo(IntPtr hMonitor, ref MONITORINFO lpmi);

	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
	public struct RECT
	{
		public int Left;
		public int Top;
		public int Right;
		public int Bottom;

		public RECT(int left, int top, int right, int bottom)
		{
			this.Left = left;
			this.Top = top;
			this.Right = right;
			this.Bottom = bottom;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct MONITORINFO
	{
		public int cbSize;
		public RECT rcMonitor;
		public RECT rcWork;
		public uint dwFlags;
	}

	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
	public struct POINT
	{
		public int X;
		public int Y;

		public POINT(int x, int y)
		{
			this.X = x;
			this.Y = y;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct MINMAXINFO
	{
		public POINT ptReserved;
		public POINT ptMaxSize;
		public POINT ptMaxPosition;
		public POINT ptMinTrackSize;
		public POINT ptMaxTrackSize;
	}
}