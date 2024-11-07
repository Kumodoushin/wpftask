using System.Net;

namespace TestTask.Domain;

public class GeoData
{
	public GeoData(IPAddress input)
	{
		
		IpAddress = input;
		Uri = null;
	}
	public GeoData(Uri input)
	{
		IpAddress = IPAddress.None;
		Uri = input;
	}


	internal GeoData()
	{
		IpAddress = IPAddress.None;
	}

	public Guid Id { get; internal set; }
	public IPAddress IpAddress { get; internal set; }
	public Uri? Uri { get; internal set; }
	public decimal? Latitude { get; internal set; }
	public decimal? Longitude { get; internal set; }

	public override string ToString() =>
		IpAddress != IPAddress.None
			? IpAddress.ToString()
			: Uri is not null
				? Uri.ToString()
				: throw new InvalidState(Id);

	public class InvalidState : Exception
	{
		public InvalidState(Guid id) : 
			base($"Turns out, this object of type ({typeof(GeoData)}) with id {id} is in invalid state. Investigation is in order.")
		{
		}
	}
}