using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSystem
{
    public class ParkingSpots
    {
        private Vehicle vehicle;
        private VehicleSize spotSize;
        private int row;
        private int spotNumber;
        private Level level;

        public ParkingSpots(Level lvl, int r, int n, VehicleSize sz)
        {
            level = lvl;
            row = r;
            spotNumber = n;
            spotSize = sz;
        }

        public bool isAvailable()
        {
            return vehicle == null;
        }

        //Check if the spot is big enoug to fit the vehicle and if it's available for parking
        public bool canFitVehicle(Vehicle vehicle)
        {
            return isAvailable();
        }
        public bool park(Vehicle v)
        {
            if (!canFitVehicle(v))
            {
                return false;
            }
            vehicle= v;
            vehicle.parkInSpot(this);
            return true;
        }
        public void removeVehicle()
        {
            level.spotFreed();
            vehicle = null;
        }

        public int getRow()
        {
            return row;
        }
    }
}
