using AirTekCodingExercise.Models;
using System.Text.Json;

namespace AirTekCodingExercise
{
    internal class OrdersParser
    {
        public IList<Order> Parse(string filePath)
        {
            if (!File.Exists(filePath)) throw new Exception("Could not find file " + filePath);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            using FileStream stream = File.OpenRead(filePath);
            var readDictionary =  JsonSerializer.Deserialize<Dictionary<string, Order>>(stream, options);
            var orders = new List<Order>(readDictionary.Count);
            foreach (var item in readDictionary)
            {
                var order = item.Value;
                order.Id = item.Key;
                orders.Add(order);
            }
            return orders;
        }
    }
}
