using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TestTask.Domain;

namespace TestTask.Presentation.HostsList;

public partial class ListVM : ObservableObject
{
	private readonly IGeoDataRepository _geoDataRepository;

	[ObservableProperty]
	private IEnumerable<ItemVM> _items;
	public ListVM(IGeoDataRepository geoDataRepository)
	{
		_geoDataRepository = geoDataRepository;
	}

	public partial class ItemVM : ObservableObject
	{
		
		private Guid _id;
		[ObservableProperty]
		private string _domainObjectName;

		public ItemVM(GeoData inputData)
		{
			_domainObjectName = inputData.ToString();
			_id = inputData.Id;
		}

		[RelayCommand]
		private Task Edit(CancellationToken arg)
		{
			throw new NotImplementedException();
		}
		
		[RelayCommand]
		private Task Delete(CancellationToken arg)
		{
			throw new NotImplementedException();
		}
	}
}