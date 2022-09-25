using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTekCodingExercise.Models
{
    internal class Flight
    {
        private const int StandartPlaneCapacity = 20;

        private List<Order> _orders = new List<Order>(StandartPlaneCapacity);

        public Flight(int number, Airport departure, Airport destination, int dayNumber)
        {
            Number = number;
            Departure = departure;
            Arrival = destination;
            DayNumber = dayNumber;
        }

        public int Number { get; }

        public Airport Departure { get;}

        public Airport Arrival { get; }

        public int DayNumber { get; }

        public bool IsFull => CurrentCapacity >= MaxCapacity;

        int MaxCapacity { get; } = StandartPlaneCapacity;

        int CurrentCapacity => _orders.Count;

        internal bool TryScheduleOrder(Order order)
        {
            if (CurrentCapacity >= MaxCapacity) return false;
            _orders.Add(order);
            order.ScheduledFlight = this;
            return true;
        }

        public override string? ToString()
        {
            return $"Flight: {Number}, departure: {Departure.Id}, arrival: {Arrival.Id}, day: {DayNumber}";
        }
    }
}
