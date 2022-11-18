namespace backend.services.Interfaces;

public interface ICalculateDistanceInKm
{
    double Execute(double latitude, double longitude);
}