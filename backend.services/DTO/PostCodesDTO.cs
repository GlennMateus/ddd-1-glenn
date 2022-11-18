#region

using backend.services.Extensions;

#endregion

namespace backend.Services.DTO;

public class PostalCodesDTO
{
    public PostalCodesDTO()
    {
    }

    public PostalCodesDTO(string PostalCode
        , double Latitude
        , double Longitude
        , double DistanceInKM)
    {
        this.PostalCode = PostalCode;
        this.Latitude = Latitude;
        this.Longitude = Longitude;
        this.DistanceInKM = DistanceInKM;
        DistanceInMiles = DistanceInKM.ToMiles();
    }

    public string PostalCode { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public double DistanceInKM { get; set; }
    public double DistanceInMiles { get; set; }
}