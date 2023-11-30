class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal PurchaseAmount { get; set; }
}

public class PLINQ
{
    public static void RunExample(bool throwException)
    {
        var customers = new List<Customer>
        {
            new Customer { Id = 1, Name = "John", PurchaseAmount = 100 },
            new Customer { Id = 2, Name = "Jane", PurchaseAmount = 200 },
            new Customer { Id = 3, Name = "Jack", PurchaseAmount = 300 },
            new Customer { Id = 4, Name = "Jill", PurchaseAmount = 400 },
            new Customer { Id = 5, Name = "Joe", PurchaseAmount = 500 },
            new Customer { Id = 6, Name = "Jen", PurchaseAmount = 600 },
            new Customer { Id = 7, Name = "Jim", PurchaseAmount = 700 },
            new Customer { Id = 8, Name = "Judy", PurchaseAmount = 800 },
            new Customer { Id = 9, Name = "Jerry", PurchaseAmount = 900 },
            new Customer { Id = 10, Name = "Jules", PurchaseAmount = 1000 }
        };

        try
        {
            var query = customers.AsParallel()
                .Where(c => c.PurchaseAmount > 100) // Filtering
                .Select(c =>
                {
                    if (throwException && c.Name == "Joe")
                    {
                        throw new InvalidOperationException("Sample exception. Joe was found!");
                    }
                    return new { c.Id, c.Name, DiscountedAmount = c.PurchaseAmount * 0.9M };
                })
                .OrderBy(c => c.Id) 
                .WithDegreeOfParallelism(4)
                .WithExecutionMode(ParallelExecutionMode.ForceParallelism) // Forcing parallelism
                .Aggregate(
                    seed: 0M,
                    func: (sum, customer) => sum + customer.DiscountedAmount, // Aggregation
                    resultSelector: sum => sum);

            Console.WriteLine($"Total discounted amount: {query}");
        }
        catch (AggregateException ae)
        {
            ae.Handle(x =>
            {
                if (x is InvalidOperationException)
                {
                    Console.WriteLine($"Handled exception: {x.Message}");
                    return true;
                }
                return false;
            });
        }
    }
}
