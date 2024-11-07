using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Net;
using TestTask.Domain;

namespace TestTask.Presentation.HostDetails;

public partial class DetailsVM : ObservableObject
{
	private readonly IGeographicCoordinatesService _geographicCoordinatesService;
	private readonly IGeoDataRepository _geoDataRepository;

	[ObservableProperty]
	private Guid _id;
	[ObservableProperty]
	private string _domainObjectName;
	[ObservableProperty]
	private decimal? _longitude;
	[ObservableProperty]
	private decimal? _latitude;
	private Uri? _uri;
	private IPAddress _ipAddress;

	public DetailsVM(
		GeoData domainObject,
		IGeographicCoordinatesService geographicCoordinatesService,
		IGeoDataRepository geoDataRepository)
	{
		FillFrom(domainObject);

		_geographicCoordinatesService = geographicCoordinatesService;
		_geoDataRepository = geoDataRepository;
	}

	private void FillFrom(GeoData domainObject)
	{
		Id = domainObject.Id;
		DomainObjectName = domainObject.ToString();
		Latitude = domainObject.Latitude;
		Longitude = domainObject.Longitude;
		_ipAddress = domainObject.IpAddress;
		_uri = domainObject.Uri;
	}

	[RelayCommand]
	private async Task Refresh(CancellationToken cancellationToken)
	{
		var refreshedData = await _geoDataRepository.Get(Id, cancellationToken);
		FillFrom(refreshedData);
	}
	
	[RelayCommand]
	private async Task UpdateGeoData(CancellationToken cancellationToken)
	{
		var data = (_ipAddress,_uri) switch
		{
			(_ipAddress: var ip, _) when !Equals(ip, IPAddress.None) => 
				await _geographicCoordinatesService.GetFor(ip),
			(_, _uri: { IsAbsoluteUri: true } uri) => 
				await _geographicCoordinatesService.GetFor(uri),
			_ => null
		};

		if (data is null)
		{
			return;
		}

		var dataPatch = new IGeoDataRepository.DataPatch()
		{
			Latitude = data.Latitude,
			Longitude = data.Longitude,
		};
		var domainObject = await _geoDataRepository.Update(_id, dataPatch, cancellationToken);
		FillFrom(domainObject);
	}
}