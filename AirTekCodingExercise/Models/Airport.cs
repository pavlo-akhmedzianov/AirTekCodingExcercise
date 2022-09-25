namespace AirTekCodingExercise.Models
{
    internal class Airport
    {
        public Airport(string id, string city)
        {
            Id = id;
            City = city;
        }

        public string Id { get; }

        public string City { get; }
    }
}
