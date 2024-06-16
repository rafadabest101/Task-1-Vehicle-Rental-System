using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vehicleRentalSystem
{
    public class Car : Vehicle
    {
        // Unique property for this class
        public int SafetyRating { get; set; }


        // Constructor that sets values to the properties
        public Car(string brand, string model, int value, int period, int rating)
            : base(brand, model, value, period)
        {
            // This is used to validate the rating so that it is from 1 to 5
            if(rating > 1 && rating < 5) SafetyRating = rating;
            else throw new Exception("Invalid safety rating!");
        }

        // Calculates total renting cost for the whole rental period
        public override int CalculateRentalCost()
        {
            if (RentalPeriod <= 7) return RentalPeriod * 20;
            else return RentalPeriod * 15;
        }

        // Calculates total insurance cost for the whole rental period
        public override double CalculateInsuranceCost()
        {
            return VehicleValue * 0.01 / 100 * RentalPeriod;
        }

        // Calculates whether the customer will receive an insurance discount based on the safety rating of the car
        public override double CalculateInsuranceChange()
        {
            return (SafetyRating >= 4) ? CalculateInsuranceCost() * 0.1 : 0;
        }
    }
}
