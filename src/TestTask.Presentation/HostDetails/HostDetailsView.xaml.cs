using System.Net;
using System.Windows.Controls;
using TestTask.Domain;

namespace TestTask.Presentation.HostDetails;

public partial class HostDetailsView : UserControl
{
	public HostDetailsView(DetailsVM viewModel)
	{
		DataContext = viewModel;
		InitializeComponent();
	}
}