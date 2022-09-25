using AirTekCodingExercise.Models;

namespace AirTekCodingExercise
{
    internal class Program
    {
        private static readonly Dictionary<string, Airport> Airports = new Dictionary<string, Airport>
        {
            { "YUL", new Airport("YUL", "Montreal")},
            { "YYZ", new Airport("YYZ", "Toronto")},
            { "YYC", new Airport("YYC", "Calgary")},
            { "YVR", new Airport("YVR", "Vancouver")},
        };

        private static readonly string OrdersFilePath = "C:\\Code\\coding-assigment-orders.json";

        static void Main(string[] args)
        {
            var ordersParser = new OrdersParser();
            var orders = ordersParser.Parse(OrdersFilePath);
            var schedule = CreateEmptyDeliverySchedule(Airports);
            var ordersDispatcher = new OrdersDispatcher();
            ordersDispatcher.TryDispatch(orders, schedule);
            Output(schedule, orders);
        }

        private static DeliverySchedule CreateEmptyDeliverySchedule(IDictionary<string, Airport> airports)
        {
            var newDeliverySchedule = new DeliverySchedule();
            void SetFlight(string departure, string arrival) => newDeliverySchedule.AddFlight(airports[departure], airports[arrival]);

            SetFlight("YUL", "YYZ");
            SetFlight("YUL", "YYC");
            SetFlight("YUL", "YVR");

            SetFlight("YUL", "YYZ");
            SetFlight("YUL", "YYC");
            SetFlight("YUL", "YVR");
            return newDeliverySchedule;
        }

        private static void Output(DeliverySchedule deliverySchedule, IList<Order> orders)
        {
            var reportsGenerator = new ReportsGenerator();
            var flightsReport = reportsGenerator.GenerateFlightsReport(deliverySchedule);
            var ordersReport = reportsGenerator.GenerateOrdersReport(orders);
            Console.WriteLine("USER STORY #1");
            Console.Write(flightsReport);
            Console.WriteLine("USER STORY #2");
            Console.Write(ordersReport);
        }
    }
}