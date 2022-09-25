using AirTekCodingExercise.Models;
using System.Text;

namespace AirTekCodingExercise
{
    internal class ReportsGenerator
    {
        public string GenerateFlightsReport(DeliverySchedule deliverySchedule)
        {
            var stringBuilder = new StringBuilder();
            foreach (var flight in deliverySchedule.Flights)
            {
                stringBuilder.AppendLine(flight.ToString());
            }
            return stringBuilder.ToString();
        }

        public string GenerateOrdersReport(IEnumerable<Order> orders)
        {
            var stringBuilder = new StringBuilder();
            foreach(var order in orders)
            {
                stringBuilder.AppendLine(order.ToString());
            }
            return stringBuilder.ToString();
        }
    }
}
