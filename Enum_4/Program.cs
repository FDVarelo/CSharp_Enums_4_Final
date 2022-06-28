using System;
using Enum_4.Entities.Enums;
using Enum_4.Entities;

namespace Enum_4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Client Initial data
            Console.WriteLine("Enter client data:");
            Console.Write("Name: ");
            string ClientName = Console.ReadLine();
            Console.Write("Email: ");
            string ClientEmail = Console.ReadLine();
            Console.Write("Birth Date (dd/mm/yyyy): ");
            DateTime BirthDate = DateTime.Parse(Console.ReadLine());

            Client client = new Client(ClientName,ClientEmail,BirthDate); // Passing the client data to the client

            // Order data
            Console.WriteLine("\nEnter order data:");
            Console.Write("Status: ");
            OrderStatus Status = Enum.Parse<OrderStatus>(Console.ReadLine());
            Console.Write("How many items to this order? ");
            int n = int.Parse(Console.ReadLine());

            Product product = new Product();
            OrderItem orderItem = new OrderItem();
            Order order = new Order();
            // Running n data(s)
            for (int i=0; i<n; i++)
            {
                Console.WriteLine($"Enter #{i} item data:");
                Console.Write("Product Name: ");
                string ProductName = Console.ReadLine();
                Console.Write("Product Price ");
                double ProductPrice = double.Parse(Console.ReadLine());
                Console.Write("Quantity: ");
                int Quantity = int.Parse(Console.ReadLine());

                product = new Product(ProductName,ProductPrice);
                orderItem = new OrderItem(Quantity,ProductPrice,product);
                order = new Order(DateTime.Now,Status,client);
                order.AddItem(orderItem);
            }
            /*ORDER SUMMARY:
            Order moment: 20/04/2018 11:25:09
            Order status: Processing
            Client: Alex Green (15/03/1985) - alex@gmail.com
            Order items:
            TV, $1000.00, Quantity: 1, Subtotal: $1000.00
            Mouse, $40.00, Quantity: 2, Subtotal: $80.00
            Total price: $1080.00*/
            Console.WriteLine("\n\nOrder Summary");
            Console.WriteLine("Order moment: "
                + order.Moment
                + "\nOrder Status: "
                + order.Status
                + "\nClient: "
                + client.Name
                + "("
                + client.BirthDate
                + ") - "
                + client.Email
                + "\nOrder items:\n");

            order.CallItems();

            Console.WriteLine("Total price: $"+order.Total);

        }
    }
}