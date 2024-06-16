using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vehicleRentalSystem
{
    public class Motorcycle : Vehicle
    {
        // Unique property for this class
        public int RiderAge { get; set; }

        // Constructor that sets values to the properties
        public Motorcycle(string brand, string model, int value, int period, int age) 
            : base(brand, model, value, period)
        {
            RiderAge = age;
        }

        // Calculates total renting cost for the whole rental period
        public override int CalculateRentalCost()
        {
            if(RentalPeriod <= 7) return RentalPeriod * 15;
            else return RentalPeriod * 10;
        }

        // Calculates total insurance cost for the whole rental period
        public override double CalculateInsuranceCost()
        {
            return VehicleValue * 0.02 / 100 * RentalPeriod;
        }

        // Calculates whether the customer will receive an insurance increase based on their age
        public override double CalculateInsuranceChange()
        {
            return (RiderAge < 25) ? CalculateInsuranceCost() * -0.2 : 0;
        }
    }
}
