using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSystem
{
    public class Level
    {
        private int floor;
        private ParkingSpots[] spots;
        private int availableSpots = 0;
        private const int SPOTS_PER_ROW = 10;

        public Level(int flr, int numberSpots)
        {
            floor = flr;
            spots = new ParkingSpots[numberSpots];
            int largeSpot = numberSpots / 4;
            int bikeSpots = numberSpots / 4;
            int compactSpots = numberSpots - largeSpot - bikeSpots;
            //Allocate spots for parking on each level according to size/type of vehicle
            for (int i = 0; i < numberSpots; i++)
            {
                //Motorcycle can fit in any spot
                VehicleSize sz = VehicleSize.Motorcycle;
                if (i < largeSpot)
                {
                    //Large vehicle can only fit in Large Spot
                    sz = VehicleSize.Large;
                }
                else if (i < largeSpot + compactSpots)
                {
                    //Compact vehicle can fit in Compact & Large spot
                    sz = VehicleSize.Compact;
                }
                int row = i / SPOTS_PER_ROW;
                spots[i] = new ParkingSpots(this, row, i, sz);
            }
            availableSpots = numberSpots;
        }

        public int AvailableSpots()
        {
            return availableSpots;
        }

        //Try to find place to park this vehicle. Return false if failed
        public bool parkVehicle(Vehicle vehicle)
        {
            if(AvailableSpots() < vehicle.getSpotsNeeded())
            {
                return false;
            }

            int spotNumber = findAvailableSpots(vehicle);
            if (spotNumber < 0)
            {
                return false;
            }
            return parkStartingAtSpot(spotNumber, vehicle);
        }

        public bool parkStartingAtSpot(int spotNum, Vehicle vehicle)
        {
            vehicle.clearSpots();
            bool success = true;
            for (int i = spotNum; i < spotNum + vehicle.getSpotsNeeded(); i++)
            {
                success = spots[i].park(vehicle);
            }
            availableSpots -= vehicle.getSpotsNeeded();
            return success;
        }

        //Find a spot to park this vehicle; return index of spot -1 on failure
        public int findAvailableSpots(Vehicle vehicle)
        {
            int spotsNeeded = vehicle.getSpotsNeeded();
            int lastRow = -1;
            int spotsFound = 0;
            for (int i = 0; i < spots.Length; i++)
            {
                ParkingSpots spot = spots[i];
                if (lastRow != spot.getRow())
                {
                    spotsFound = 0;
                    lastRow = spot.getRow();
                }
                if (spot.canFitVehicle(vehicle))
                {
                    spotsFound++;
                }
                else
                {
                    spotsFound = 0;
                }
                if(spotsFound == spotsNeeded)
                {
                    return i - (spotsNeeded - 1);
                }
            }
            return -1;
        }
        public void spotFreed()
        {
            availableSpots++;
        }
    }
}
