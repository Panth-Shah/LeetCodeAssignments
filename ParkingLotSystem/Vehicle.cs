using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSystem
{
    public abstract class Vehicle
    {
        protected List<ParkingSpots> parkingSpots = new List<ParkingSpots>();
        protected string LicensePlate;
        protected int spotsNeeded;
        protected VehicleSize size;

        public int getSpotsNeeded()
        {
            return spotsNeeded;
        }

        public VehicleSize getSize()
        {
            return size;
        }

        //Park vehicle int the spot
        public void parkInSpot(ParkingSpots spot)
        {
            parkingSpots.Add(spot);
        }

        //Remove car from parking spot
        public void clearSpots()
        {
            for (int i = 0; i < parkingSpots.Count; i++)
            {
                parkingSpots[i].removeVehicle();
            }
            parkingSpots.Clear();
        }
    }
}
