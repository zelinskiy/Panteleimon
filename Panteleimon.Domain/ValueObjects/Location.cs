namespace Panteleimon.Domain.ValueObjects;

public readonly record struct Location
{
    public double Lat { get; }
    public double Lon { get; }

    public Location(double lat, double lon)
    {
        if (!double.IsFinite(lat) || lat is < -90 or > 90)
            throw new ArgumentOutOfRangeException(nameof(lat));

        if (!double.IsFinite(lon) || lon is < -180 or > 180)
            throw new ArgumentOutOfRangeException(nameof(lon));

        Lat = lat;
        Lon = lon;
    }
}
