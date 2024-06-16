using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vehicleRentalSystem
{
    public class Motorcycle : Vehicle
    {
        public int RiderAge { get; set; }

        public Motorcycle(string brand, string model, int value, int period, int age) 
            : base(brand, model, value, period)
        {
            RiderAge = age;
        }

        public override int CalculateRentalCost()
        {
            if(RentalPeriod <= 7) return RentalPeriod * 15;
            else return RentalPeriod * 10;
        }

        public override double CalculateInsuranceCost()
        {
            return VehicleValue * 0.02 / 100 * RentalPeriod;
        }

        public override double CalculateInsuranceChange()
        {
            return (RiderAge < 25) ? CalculateInsuranceCost() * -0.2 : 0;
        }
    }
}
