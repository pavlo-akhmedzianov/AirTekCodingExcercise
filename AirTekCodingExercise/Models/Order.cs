namespace AirTekCodingExercise.Models
{
    internal class Order
    {
        public string Id { get; set; }

        public string Destination { get; set; }

        public Flight? ScheduledFlight { get; set; }

        public override string? ToString()
        {
            if (ScheduledFlight == null)
            {
                return $"order: {Id}, flightNumber: not scheduled";
            }
            else
                return $"order: {Id}, flightNumber: {ScheduledFlight.Number}, departure: {ScheduledFlight.Departure.Id}, arrival: {ScheduledFlight.Arrival.Id}, day: {ScheduledFlight.DayNumber}";
        }
    }
}
