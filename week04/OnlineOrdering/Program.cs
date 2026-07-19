using System;

class Program
{
    static void Main(string[] args)
    {
        // Order 1: US Customer
        Address address1 = new Address("123 Alpine Way", "Rexburg", "ID", "USA");
        Customer customer1 = new Customer("John Doe", address1);
        Order order1 = new Order(customer1);
        
        order1.AddProduct(new Product("Mechanical Keyboard", "K832", 89.99, 1));
        order1.AddProduct(new Product("Ergonomic Mouse", "M210", 45.50, 2));

        // Order 2: International Customer
        Address address2 = new Address("456 Sakura Dr", "Kyoto", "Kyoto Prefecture", "Japan");
        Customer customer2 = new Customer("Jane Smith", address2);
        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("Noise Cancelling Headphones", "H500", 249.99, 1));
        order2.AddProduct(new Product("USB-C Charging Cable", "C102", 12.00, 3));
        order2.AddProduct(new Product("Laptop Stand", "S044", 35.00, 1));

        // Display Order 1 Details
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Order Price: ${order1.CalculateTotalCost():F2}");
        Console.WriteLine(new string('=', 40));
        Console.WriteLine();

        // Display Order 2 Details
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Order Price: ${order2.CalculateTotalCost():F2}");
        Console.WriteLine(new string('=', 40));
    }
}