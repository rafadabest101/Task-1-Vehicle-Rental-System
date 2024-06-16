namespace vehicleRentalSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter customer name: ");
            string customerName = Console.ReadLine();

            Console.Write("Enter rent start date (yyyy-mm-dd): ");
            DateTime rentStartDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Vehicle details: ");
            Console.Write("Enter type of vehicle (motorcycle/car/cargo van): ");
            string type = Console.ReadLine();
            Console.Write("Enter vehicle brand: ");
            string brand = Console.ReadLine();
            Console.Write("Enter vehicle model: ");
            string model = Console.ReadLine();
            Console.Write("Enter vehicle value (in dollars): ");
            int value = int.Parse(Console.ReadLine());
            Console.Write("Enter rental period (in days): ");
            int rentPeriod = int.Parse(Console.ReadLine());

            switch(type.ToLower())
            {
                case "motorcycle":
                    Console.Write("Enter driver age: ");
                    int age = int.Parse(Console.ReadLine());
                    Invoice.Print(customerName, new Motorcycle(brand, model, value, rentPeriod, age), rentStartDate);
                    break;
                case "car":
                    Console.Write("Enter safety rating (1 - 5): ");
                    int rating = int.Parse(Console.ReadLine());
                    Invoice.Print(customerName, new Car(brand, model, value, rentPeriod, rating), rentStartDate);
                    break;
                case "cargo van":
                    Console.Write("Enter driver experience (in years): ");
                    int exp = int.Parse(Console.ReadLine());
                    Invoice.Print(customerName, new CargoVan(brand, model, value, rentPeriod, exp), rentStartDate);
                    break;
                default:
                    throw new Exception("Invalid vehicle type!");
                    break;
            }
        }
    }
}