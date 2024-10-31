using System.Net;
using TestTask.Domain;

namespace TestTask.Infrastructure;

public class IPStackGeographicCoordinatesService : IGeographicCoordinatesService
{
	private readonly HttpClient _client;
	private readonly string _apiKey;

	public IPStackGeographicCoordinatesService(HttpClient client, string apiKey)
	{
		_client = client;
		_apiKey = apiKey;
	}
	public Task<IGeographicCoordinatesService.GeoCoordinates> GetFor(IPAddress ipAddress)
	{
		throw new NotImplementedException();
	}


	public Task<IGeographicCoordinatesService.GeoCoordinates> GetFor(Uri uri) => throw new NotImplementedException();
	
	
}