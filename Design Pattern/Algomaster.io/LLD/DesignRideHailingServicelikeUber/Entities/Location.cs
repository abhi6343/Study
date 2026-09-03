namespace RideHailingServicelikeUber.Entities
{
    internal class Location(double lat, double lng)
    {
        public double DistanceTo(Location other)
        {
            double dx = lat - other.Latitude;
            double dy = lng - other.Longitude;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        public double Latitude => lat;
        public double Longitude => lng;

        public override string ToString() => $"Location({lat}, {lng})";
    }
}
