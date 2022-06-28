using System;
using Enum_4.Entities.Enums;
using Enum_4.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enum_4.Entities
{
    internal class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        List<OrderItem> orderItem = new List<OrderItem>();
        public Client _client { get; set; }

        public Order()
        {

        }
        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            _client = client;
        }

        public void AddItem(OrderItem item)
        {
            orderItem.Add(item);
        }
        public void RemoveItem(OrderItem item)
        {
            orderItem.Remove(item);
        }

        public double Total()
        {
            double sum = 0;
            foreach(OrderItem item in orderItem)
            {
                sum += item.SubTotal(item.Quantity, item.Price);
            }
            return sum;
        }

        public void CallItems()
        {
            foreach (OrderItem item in orderItem)
            {
                Console.WriteLine(item);
            }
        }
    }
}
