using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static EmployeePortal.Factory.AbstractFactory.Enumerations;


namespace EmployeePortal.Factory.AbstractFactory
{
    public class Leptop : ISystemType
    {
        public string GetSystemType()
        {
            return ComputerTypes.Leptop.ToString();
        }
    }
    public class Desktop : ISystemType
    {
        public string GetSystemType()
        {
            return ComputerTypes.Desktop.ToString();
        }
    }
}