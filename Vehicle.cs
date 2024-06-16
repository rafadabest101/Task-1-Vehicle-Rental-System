using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vehicleRentalSystem
{
    public abstract class Vehicle
    {
        // Properties used by all child classes
        public string VehicleBrand { get; set; }
        public string VehicleModel { get; set; }
        public int VehicleValue { get; set; }
        public int RentalPeriod { get; set; }

        // Constructor that sets values to the properties
        public Vehicle(string brand, string model, int value, int period)
        {
            VehicleBrand = brand;
            VehicleModel = model;
            VehicleValue = value;
            RentalPeriod = period;
        }

        // Abstract methods implemented by all child classes
        public abstract int CalculateRentalCost();

        public abstract double CalculateInsuranceCost();
        public abstract double CalculateInsuranceChange();
    }
}
