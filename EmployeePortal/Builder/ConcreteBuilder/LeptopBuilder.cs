using EmployeePortal.Builder.IBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeePortal.Builder.ConcreteBuilder
{
    public class LeptopBuilder : ISystemBuilder
    {
        ComputerSystem leptop = new ComputerSystem();
        public void AddDriver(string size)
        {
            leptop.HDDSize = size;
        }

        public void AddKeyoard(string type)
        {
            return;
        }

        public void AddMemory(string memory)
        {
            leptop.RAM = memory;
        }

        public void AddMouse(string type)
        {
            return;
        }

        public void AddTouchScreen(string enabled)
        {
            leptop.TouchScreen = enabled;
        }

        public ComputerSystem GetSystem()
        {
            return leptop;
        }
    }
}