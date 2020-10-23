using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePortal.Builder.IBuilder
{
    //Build a system in a step by step process and return the built system at the end
    public interface ISystemBuilder
    {
        void AddMemory(string memory);
        void AddDriver(string size);
        void AddKeyoard(string type);
        void AddMouse(string type);
        void AddTouchScreen(string enabled);
        ComputerSystem GetSystem();
    }
}
