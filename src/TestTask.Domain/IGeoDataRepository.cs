namespace TestTask.Domain;

public interface IGeoDataRepository
{
	Task<List<GeoData>> Get(CancellationToken cancellationToken);

	Task Update(GeoData geoData, CancellationToken cancellationToken);

	Task Delete(GeoData geoData, CancellationToken cancellationToken);
}