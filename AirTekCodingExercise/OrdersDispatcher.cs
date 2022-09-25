using AirTekCodingExercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTekCodingExercise
{
    internal class OrdersDispatcher
    {
        public IList<Order> TryDispatch(IList<Order> orders, DeliverySchedule schedule)
        {
            var failedToScheduleOrders = new List<Order>();
            foreach(var order in orders)
            {
                var flight = schedule.FirstOrDefault(order.Destination);
                if (flight == null || flight.TryScheduleOrder(order)) failedToScheduleOrders.Add(order);
            }
            return failedToScheduleOrders;
        }
    }
}
