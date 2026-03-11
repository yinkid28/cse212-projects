public class CustomerService {
    public static void Run() {
        // Test 1
        // Scenario: Add one customer and serve them
        // Expected Result: Should display the customer that was added
        Console.WriteLine("Test 1");
        var service = new CustomerService(4);
        service.AddNewCustomer();
        service.ServeCustomer();
        // Defect Found: ServeCustomer was deleting before reading

        Console.WriteLine("=================");

        // Test 2
        // Scenario: Add two customers and serve them in order
        // Expected Result: Customers should come out in the same order they went in
        Console.WriteLine("Test 2");
        service = new CustomerService(4);
        service.AddNewCustomer();
        service.AddNewCustomer();
        Console.WriteLine($"Before: {service}");
        service.ServeCustomer();
        service.ServeCustomer();
        Console.WriteLine($"After: {service}");
        // Defect Found: None

        Console.WriteLine("=================");

        // Test 3
        // Scenario: Serve a customer when queue is empty
        // Expected Result: Should display an error message
        Console.WriteLine("Test 3");
        service = new CustomerService(4);
        service.ServeCustomer();
        // Defect Found: No empty queue check existed

        Console.WriteLine("=================");

        // Test 4
        // Scenario: Add more customers than the max size allows
        // Expected Result: Should display an error on the 5th add
        Console.WriteLine("Test 4");
        service = new CustomerService(4);
        service.AddNewCustomer();
        service.AddNewCustomer();
        service.AddNewCustomer();
        service.AddNewCustomer();
        service.AddNewCustomer(); // This one should fail
        Console.WriteLine($"Queue: {service}");
        // Defect Found: Used > instead of >= for max size check

        Console.WriteLine("=================");

        // Test 5
        // Scenario: Create a queue with invalid size (0)
        // Expected Result: Max size should default to 10
        Console.WriteLine("Test 5");
        service = new CustomerService(0);
        Console.WriteLine($"Size should be 10: {service}");
        // Defect Found: None
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    private void AddNewCustomer() {
        // FIX Bug 3: changed > to >=
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    private void ServeCustomer() {
        // FIX Bug 2: check if queue is empty
        if (_queue.Count <= 0) {
            Console.WriteLine("No Customers in the queue.");
            return;
        }

        // FIX Bug 1: save customer BEFORE removing
        var customer = _queue[0];
        _queue.RemoveAt(0);
        Console.WriteLine(customer);
    }

    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}