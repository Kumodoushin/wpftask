using System.Net;

namespace TestTask.Domain;

public interface IGeoDataRepository
{
	Task<List<GeoData>> Get(CancellationToken cancellationToken);

	Task<GeoData> Get(Guid id, CancellationToken cancellationToken);
	Task<GeoData> Update(Guid id, DataPatch data, CancellationToken cancellationToken);
	Task Delete(Guid id, CancellationToken cancellationToken);

	public class DataPatch
	{
		public decimal? Latitude { get; init; }
		public decimal? Longitude { get; init; }
	}
}

