<<<<<<< Updated upstream
﻿namespace DalTest
{
    internal class Program
    {
        static void Main(string[] args)

        {
            Console.WriteLine("Hello, World!");
=======
﻿using Dal;
using DalFacade;
using DalFacade.DO;
using DO;
>>>>>>> Stashed changes

namespace DalTest;

internal class Program
{
    static readonly IProduct s_dalProduct = new DalProduct();
    static readonly ICustomer s_dalCustomer = new DalCustomer();
    static readonly IOrder s_dalOrder = new DalOrder();

    static void Main(string[] args)
    {
        Console.WriteLine("=== Starting DAL Tests ===");

        TestProduct();
        TestCustomer();
        TestOrder();

        Console.WriteLine("\n=== All Tests Completed Successfully! ===");
    }

    private static void TestProduct()
    {
        Console.WriteLine("\n--- Testing Product ---");
        Product p = new(100, "Laptop", 3500);
        s_dalProduct.Add(p);

        var readP = s_dalProduct.Read(100);
        Console.WriteLine($"Read Product: {readP}");
    }

    private static void TestCustomer()
    {
        Console.WriteLine("\n--- Testing Customer ---");
        Customer c = new() { Id = 200, Name = "Israel", Email = "israel@example.com"}; s_dalCustomer.Add(c);

        var readC = s_dalCustomer.Read(200);
        Console.WriteLine($"Read Customer: {readC}");
    }

    private static void TestOrder()
    {
        Console.WriteLine("\n--- Testing Order ---");
        Order o = new() { Id = 300, CustomerId = 100, OrderDate = DateTime.Now }; s_dalOrder.Add(o);

        var readO = s_dalOrder.Read(300);
        Console.WriteLine($"Read Order: {readO}");
    }
}
