using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePortal.Factory.AbstractFactory
{
    public class DellFactory : IComputerFactory
    {
        public IBrand Brand()
        {
            return new Dell();
        }

        public IProcessor Processor()
        {
            return new I7();
        }

        public virtual ISystemType SystemType()
        {
            return new Desktop();
        }
    }

    public class DellLeptopFactory : DellFactory
    {
        public override ISystemType SystemType()
        {
            return new Leptop();
        }
    }
}
