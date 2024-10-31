using System.Windows;
using TestTask.Presentation.Views;

namespace TestTask.Presentation;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
	protected override void OnStartup(StartupEventArgs e)
	{
		var window = new MainWindow();
		window.Show();
		base.OnStartup(e);
	}
}