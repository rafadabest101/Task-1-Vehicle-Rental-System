using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vehicleRentalSystem
{
    public class CargoVan : Vehicle
    {
        public int DriverExperience { get; set; }

        public CargoVan(string brand, string model, int value, int period, int exp)
            : base(brand, model, value, period)
        {
            DriverExperience = exp;
        }

        public override int CalculateRentalCost()
        {
            if(RentalPeriod <= 7) return RentalPeriod * 50;
            else return RentalPeriod * 40;
        }

        public override double CalculateInsuranceCost()
        {
            return VehicleValue * 0.03 / 100 * RentalPeriod;
        }

        public override double CalculateInsuranceChange()
        {
            return (DriverExperience > 5) ? CalculateInsuranceCost() * 0.15 : 0;
        }
    }
}