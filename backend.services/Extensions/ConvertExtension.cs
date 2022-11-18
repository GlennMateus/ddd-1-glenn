namespace backend.services.Extensions;

public static class ConvertExtension
{
    public static decimal ToMiles(this decimal value)
    {
        return value * 0.621371m;
    }

    public static double ToMiles(this double value)
    {
        return value * 0.621371;
    }

    public static double ToRadians(this double value)
    {
        return (value * Math.PI) / 180;
    }
}