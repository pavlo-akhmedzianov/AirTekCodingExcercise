using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTekCodingExercise.Models
{
    internal class DeliverySchedule
    {
        private int _currentNumberOfFlights;

        private List<DailyPlan> _dailyPlans;

        public DeliverySchedule()
        {
            _dailyPlans = new List<DailyPlan>();
        }

        public IEnumerable<Flight> Flights 
        { 
            get 
            {
                foreach (var dailyPlan in _dailyPlans)
                {
                    foreach (var flight in dailyPlan.Flights)
                    {
                        yield return flight;
                    }
                }
            } 
        }

        public void AddFlight(Airport departure, Airport destination)
        {
            var currentDailyPlan = _dailyPlans.LastOrDefault() ?? CreateDailyPlan();
            var newFlightNumber = ++_currentNumberOfFlights;
            if(!currentDailyPlan.TryAddFlight(newFlightNumber, departure, destination))
            {
                currentDailyPlan = CreateDailyPlan();
                currentDailyPlan.TryAddFlight(newFlightNumber, departure, destination);
            }
        }

        public Flight? FirstOrDefault(string destination)
        {
            foreach (var dailyPlan in _dailyPlans)
            {
                if (dailyPlan.TryGetFlight(destination, out var flight) && !flight.IsFull) return flight;
            }
            return null;
        }

        private DailyPlan CreateDailyPlan()
        {
            var newDailyPlan = new DailyPlan(_dailyPlans.Count + 1);
            _dailyPlans.Add(newDailyPlan);
            return newDailyPlan;
        }
    }
}
