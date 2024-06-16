using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vehicleRentalSystem
{
    public static class Invoice
    {
        public static void Print(string customerName, Vehicle vehicle, DateTime rentStartDate)
        {
            // Prints 10 X's at the start in a single line
            Console.WriteLine(new string('X', 10));

            Console.WriteLine($"Date: {DateTime.Today:yyyy-MM-dd}");
            Console.WriteLine($"Customer Name: {customerName}");
            Console.WriteLine($"Rented Vehicle: {vehicle.VehicleBrand} {vehicle.VehicleModel}");

            Console.WriteLine();

            Console.WriteLine($"Reservation start date: {rentStartDate:yyyy-MM-dd}");
            Console.WriteLine($"Reservation end date: {rentStartDate.AddDays(vehicle.RentalPeriod):yyyy-MM-dd}");
            Console.WriteLine($"Reserved rental days: {vehicle.RentalPeriod} days");

            Console.WriteLine();

            Console.WriteLine($"Actual return date: {DateTime.Today:yyyy-MM-dd}");
            int actualRentalDays = (DateTime.Today - rentStartDate).Days;
            Console.WriteLine($"Actual rental days: {actualRentalDays} days");

            Console.WriteLine();

            // Calculates daily costs for insurance and rent, as well as their daily discounts/increases
            double initialInsurancePerDay = vehicle.CalculateInsuranceCost() / vehicle.RentalPeriod;
            double insuranceChangePerDay = vehicle.CalculateInsuranceChange() / vehicle.RentalPeriod;
            double insurancePerDay = initialInsurancePerDay - insuranceChangePerDay;
            double rentPerDay = vehicle.CalculateRentalCost() / vehicle.RentalPeriod;

            Console.WriteLine($"Rental cost per day: ${rentPerDay:f2}");
            if(insuranceChangePerDay > 0)
            {
                Console.WriteLine($"Initial insurance per day: ${initialInsurancePerDay:f2}");
                // If the vehicle is a motorcycle the insurance cost will increase, not decrease
                if(vehicle is Motorcycle) Console.WriteLine($"Insurance addition per day: ${insuranceChangePerDay:f2}");
                else Console.WriteLine($"Insurance discount per day: ${insuranceChangePerDay:f2}");
            }
            Console.WriteLine($"Insurance per day: ${insurancePerDay:f2}");

            Console.WriteLine();

            // Calculates base total rent and insurance
            double totalRent = vehicle.CalculateRentalCost();
            double totalInsurance = vehicle.CalculateInsuranceCost() - vehicle.CalculateInsuranceChange();

            // Sets the total cost values to the early return discounts in order to subtract their updated values later on
            double earlyReturnRentDiscount = totalRent;
            double earlyReturnInsuranceDiscount = totalInsurance;
            if(vehicle.RentalPeriod != actualRentalDays)
            {
                int remainingDays = vehicle.RentalPeriod - actualRentalDays;

                // Updated the total rent and insurance costs based on the early return of the rented vehicle
                totalRent = actualRentalDays * rentPerDay + remainingDays * rentPerDay / 2;
                totalInsurance = actualRentalDays * insurancePerDay;

                /* Subtracts the updated total cost values from the base total ones which were already written in the
                early discount fields */
                earlyReturnRentDiscount -= totalRent;
                earlyReturnInsuranceDiscount -= totalInsurance;
                Console.WriteLine($"Early return discount for rent: ${earlyReturnRentDiscount:f2}");
                Console.WriteLine($"Early return discount for insurance: ${earlyReturnInsuranceDiscount:f2}");

                Console.WriteLine();
            }

            Console.WriteLine($"Total rent: ${totalRent:f2}");
            Console.WriteLine($"Total insurance: ${totalInsurance:f2}");
            Console.WriteLine($"Total: ${totalRent + totalInsurance:f2}");

            // Prints 10 X's at the end in a single line
            Console.WriteLine(new string('X', 10));
        }
    }
}
