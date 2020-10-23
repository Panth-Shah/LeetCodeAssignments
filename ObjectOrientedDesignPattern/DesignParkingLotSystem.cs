using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedDesignPattern
{
    //Based on requriements, we will create an abstract class Vehicle, from which Car, Truck & Motorcycle can inherit
    //ParkingSpot class to handle parkining spot allocation
    public class DesignParkingLotSystem
    {

    }
    public enum VehicleSize
    {
        Motorcycle,
        Compact,
        Large
    }

    public abstract class Vehicle
    {
        protected List<ParkingSpot>
    }

    public class ParkingSpot
    {

    }

    //Represents Level in parking garage
    public class Level
    {
        private int floor;
    }

    //The Parking Spot is implemented by having just a variable which represents the size of the spot.
    //Hierarchy: ParkingSot -> Parking Level -> Parking Building <- Occupied By Vehicle
    public class ParkingSpot
    {

    }

}
