using EmployeePortal.Builder.IBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeePortal.Builder.ConcreteBuilder
{
    public class DesktopBuilder : ISystemBuilder
    {
        ComputerSystem deskTop = new ComputerSystem();

        public void AddDriver(string size)
        {
            deskTop.HDDSize = size;
        }

        public void AddKeyoard(string type)
        {
            deskTop.KeyBoard = type;
        }

        public void AddMemory(string memory)
        {
            deskTop.RAM = memory;
        }

        public void AddMouse(string type)
        {
            deskTop.Mouse = type;
        }

        public void AddTouchScreen(string enabled)
        {
            return;
        }

        public ComputerSystem GetSystem()
        {
            return deskTop;
        }
    }
}