using OneOf;
using System.Net;

namespace TestTask.Domain;

public class GeoData
{
	public GeoData(OneOf<IPAddress,Uri> input)
	{
		IpAddress = input.IsT0 ? input.AsT0 : IPAddress.None;
		Uri = input.IsT1 ? input.AsT1 : null;
	}

	internal GeoData()
	{
		IpAddress = IPAddress.None;
	}

	public IPAddress IpAddress { get; internal set; }
	public Uri? Uri { get; internal set; }
	public string? Latitude { get; internal set; }
	public string? Longitude { get; internal set; }

	internal bool GeoDataIsFilled { get; set; } = false;

	public void ApplyGeoDataFrom(IPGeolocation.Geolocation geolocation)
	{
		if (GeoDataIsFilled)
		{
			return;
		}
		Latitude = geolocation.GetLatitude();
		Longitude = geolocation.GetLongitude();
		GeoDataIsFilled = true;
	}
}