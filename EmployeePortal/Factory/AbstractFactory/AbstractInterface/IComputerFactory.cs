using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePortal.Factory.AbstractFactory
{
    public interface IComputerFactory
    {
        IProcessor Processor();
        ISystemType SystemType();
        IBrand Brand();
    }
}
