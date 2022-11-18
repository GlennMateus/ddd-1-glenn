#region

using backend.services.Extensions;
using backend.services.Interfaces;

#endregion

namespace backend.services.Implementations;

public class CalculateDistanceInKm : ICalculateDistanceInKm
{
    public double Execute(double latitude, double longitude)
    {
        /*
         * ! Harvesine formula is used to calculate the distance between two points on a sphere, which is the earth
         * ? it could be used the Lambert's formula
         */
        var earhRadiusKM = 6371;
        var airportLatitude = 51.470022;
        var airportLongitude = -0.454295;

        var deltaLat = (latitude.ToRadians() - airportLatitude.ToRadians());
        var deltaLon = (longitude.ToRadians() - airportLongitude.ToRadians());
        var harvesineFormula = Math.Sin(deltaLat / 2) * Math.Sin(deltaLat / 2) +
                               Math.Cos(latitude.ToRadians()) * Math.Cos(airportLatitude.ToRadians()) *
                               Math.Sin(deltaLon / 2) * Math.Sin(deltaLon / 2);

        var hypotenuse = 2 * Math.Asin(Math.Sqrt(harvesineFormula));

        return (hypotenuse * earhRadiusKM);
    }
}