using System;
using Enum_4.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enum_4.Entities
{
    internal class OrderItem
    {
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Product Products { get; set; }

        public OrderItem()
        {

        }
        public OrderItem(int quantity, double price, Product products)
        {
            Quantity = quantity;
            Price = price;
            Products = products;
        }

        public double SubTotal(int quantity, double price)
        {
            return quantity * price;
        }

        
        public override string ToString()
        {
            return  Products.Name
                +", $"
                + Price
                +", Quantity: "
                +Quantity
                +"Subtotal: $"
                +SubTotal(Quantity,Price);
                //TV, $1000.00, Quantity: 1, Subtotal: $1000.00;
        }
    }
}
