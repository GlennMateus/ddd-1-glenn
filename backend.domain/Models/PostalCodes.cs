namespace backend.domain.Models;

public class PostalCodes : BaseEntity
{
    public string PostalCode { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public double DistanceInKM { get; set; }
    public double DistanceInMiles { get; set; }
}