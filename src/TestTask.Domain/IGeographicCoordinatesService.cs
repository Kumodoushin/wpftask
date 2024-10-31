using System.Net;

namespace TestTask.Domain;

public interface IGeographicCoordinatesService
{
	Task<GeoCoordinates> GetFor(IPAddress ipAddress);

	Task<GeoCoordinates> GetFor(Uri uri);

	public record GeoCoordinates(decimal Latitude, decimal Longitude);
}
