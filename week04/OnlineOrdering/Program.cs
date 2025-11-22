using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the OnlineOrdering Project.");
        // Order 1 - Customer in USA
        Address addr1 = new Address("123 Main St", "Portland", "OR", "USA");
        Customer cust1 = new Customer("Alice Johnson", addr1);

        Order order1 = new Order(cust1);
        order1.AddProduct(new Product("Coffee Mug", "CM-001", 9.99, 2)); // 2 x 9.99
        order1.AddProduct(new Product("T-Shirt", "TS-101", 19.95, 1));   // 1 x 19.95

        // Order 2 - Customer outside USA
        Address addr2 = new Address("456 King Road", "Toronto", "Ontario", "Canada");
        Customer cust2 = new Customer("Bob Martins", addr2);

        Order order2 = new Order(cust2);
        order2.AddProduct(new Product("Notebook", "NB-300", 4.50, 5));   // 5 x 4.50
        order2.AddProduct(new Product("Backpack", "BP-22", 39.99, 1));   // 1 x 39.99
        order2.AddProduct(new Product("Sticker Pack", "SP-5", 1.25, 3)); // 3 x 1.25

        // Display orders
        DisplayOrder(order1);
        Console.WriteLine(); // blank line between orders
        DisplayOrder(order2);
    }

    static void DisplayOrder(Order order)
    {
        Console.WriteLine("=======================================");
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine("Items detail:");

        foreach (var p in order.GetProducts())
        {
            Console.WriteLine($" - {p.Name} (ID: {p.ProductId}) qty: {p.Quantity} unit price: {p.PricePerUnit.ToString("C", CultureInfo.InvariantCulture)} total: {(p.GetTotalCost()).ToString("C", CultureInfo.InvariantCulture)}");
        }

        double shipping = (order.GetCustomer().LivesInUSA()) ? 5.0 : 35.0;
        Console.WriteLine($"Shipping: {shipping.ToString("C", CultureInfo.InvariantCulture)}");
        Console.WriteLine($"TOTAL: {order.CalculateTotalPrice().ToString("C", CultureInfo.InvariantCulture)}");
        Console.WriteLine("=======================================");
    }
}
