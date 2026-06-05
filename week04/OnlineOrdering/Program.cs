class Program
{
    static void Main()
    {
        Address address1 = new Address("12 Lagos Street", "Lagos", "LA", "Nigeria");
        Customer customer1 = new Customer("John Doe", address1);

        Product p1 = new Product("Phone", "P100", 200, 1);
        Product p2 = new Product("Headphones", "H200", 50, 2);

        Order order1 = new Order(customer1);
        order1.AddProduct(p1);
        order1.AddProduct(p2);

        Console.WriteLine("PACKING LABEL:");
        Console.WriteLine(order1.GetPackingLabel());

        Console.WriteLine("SHIPPING LABEL:");
        Console.WriteLine(order1.GetShippingLabel());

        Console.WriteLine("TOTAL COST: $" + order1.GetTotalCost());
    }
}