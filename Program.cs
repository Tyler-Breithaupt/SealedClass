namespace SealedClass;

interface IEmployee
{
    //Properties
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    //Methods
    public string Fullname();
    public double Pay();
}
class Program
{
    class Employee : IEmployee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Employee()
        {
            Id = 0;
            FirstName = string.Empty;
            LastName = string.Empty;
        }
        public Employee(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
        public string Fullname()
        {
            return FirstName + " " + LastName;
        }
        public virtual double Pay()
        {
            double salary;
            Console.WriteLine($"What is {this.Fullname()}'s weekly salary?");
            salary = double.Parse(Console.ReadLine());
            return salary;
        }
    }
    sealed class Executive : Employee
    {
        public string Title { get; set; }
        public double Salary { get; set; }

        public Executive() : base()
        {
            Title = string.Empty;
            Salary = 0.0;
        }

        public Executive(int id, string firstName, string lastName, string title, double salary)
            : base(id, firstName, lastName)
        {
            Title = title;
            Salary = salary;
        }

        public override double Pay()
        {
            Console.WriteLine($"What is {this.Fullname()}'s weekly salary?");
            Salary = double.Parse(Console.ReadLine());
            return Salary;
        }
    }
    static void Main(string[] args)
    {
        Employee employee = new Employee(1, "John", "Doe");

        Console.WriteLine("Employee Information:");
        Console.WriteLine($"ID: {employee.Id}");
        Console.WriteLine($"Name: {employee.Fullname()}");
        Console.WriteLine($"Weekly Salary: {employee.Pay()}");

        Console.WriteLine();

        Executive executive = new Executive(2, "Jane", "Smith", "CEO", 10000.00);

        Console.WriteLine("Executive Information:");
        Console.WriteLine($"ID: {executive.Id}");
        Console.WriteLine($"Name: {executive.Fullname()}");
        Console.WriteLine($"Title: {executive.Title}");
        Console.WriteLine($"Weekly Salary: {executive.Pay()}");

        Console.ReadLine(); // To keep the console window open
    }
}

