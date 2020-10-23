using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSystem
{
    public class ParkingLot
    {
        private Level[] levels;
        private const int NUM_LEVELS = 5;

        public ParkingLot()
        {
            //Each parking lot has 5 Levels
            levels = new Level[NUM_LEVELS];
            for (int i = 0; i < NUM_LEVELS; i++)
            {
                //Each level has 30 parking spots
                levels[i] = new Level(i, 30);
            }
        }
        //Park the vehicle in the spot
        public bool parkVehicle(Vehicle vehicle)
        {
            //Try to park vehicle on any of the levels
            for (int i = 0; i < levels.Length; i++)
            {
                //Perform park vehicle operation on each level
                if (true)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
