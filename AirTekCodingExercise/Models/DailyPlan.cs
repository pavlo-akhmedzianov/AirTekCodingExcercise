namespace AirTekCodingExercise.Models
{
    internal class DailyPlan
    {
        private const int MaxDailyFlights = 3;

        private Dictionary<string, Flight> _destinationToFlights;

        private List<Flight> _orderedFlights;

        public DailyPlan(int dayNumber)
        {
            DayNumber = dayNumber;
            _destinationToFlights = new Dictionary<string, Flight>();
            _orderedFlights = new List<Flight>(MaxDailyFlights);
        }

        public int DayNumber { get; }

        public IReadOnlyList<Flight> Flights => _orderedFlights;

        public bool TryAddFlight(int flightNumber, Airport departure, Airport destination)
        {
            if (_destinationToFlights.Count >= MaxDailyFlights) return false;
            var newFlight = new Flight(flightNumber, departure, destination, DayNumber);
            _destinationToFlights.Add(destination.Id, newFlight);
            _orderedFlights.Add(newFlight);
            return true;
        }

        public bool TryGetFlight(string destination, out Flight flight) => 
            _destinationToFlights.TryGetValue(destination, out flight);
    }
}
