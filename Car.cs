using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vehicleRentalSystem
{
    public class Car : Vehicle
    {
        public int SafetyRating { get; set; }

        public Car(string brand, string model, int value, int period, int rating)
            : base(brand, model, value, period)
        {
            if(rating > 1 && rating < 5) SafetyRating = rating;
            else throw new Exception("Invalid safety rating!");
        }

        public override int CalculateRentalCost()
        {
            if (RentalPeriod <= 7) return RentalPeriod * 20;
            else return RentalPeriod * 15;
        }

        public override double CalculateInsuranceCost()
        {
            return VehicleValue * 0.01 / 100 * RentalPeriod;
        }

        public override double CalculateInsuranceChange()
        {
            return (SafetyRating >= 4) ? CalculateInsuranceCost() * 0.1 : 0;
        }
    }
}
