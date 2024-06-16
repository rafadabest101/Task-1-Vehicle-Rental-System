using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vehicleRentalSystem
{
    public class CargoVan : Vehicle
    {
        // Unique property for this class
        public int DriverExperience { get; set; }

        // Constructor that sets values to the properties
        public CargoVan(string brand, string model, int value, int period, int exp)
            : base(brand, model, value, period)
        {
            DriverExperience = exp;
        }

        // Calculates total renting cost for the whole rental period
        public override int CalculateRentalCost()
        {
            if(RentalPeriod <= 7) return RentalPeriod * 50;
            else return RentalPeriod * 40;
        }

        // Calculates total insurance cost for the whole rental period
        public override double CalculateInsuranceCost()
        {
            return VehicleValue * 0.03 / 100 * RentalPeriod;
        }

        // Calculates whether the customer will receive an insurance discount based on their experience
        public override double CalculateInsuranceChange()
        {
            return (DriverExperience > 5) ? CalculateInsuranceCost() * 0.15 : 0;
        }
    }
}
