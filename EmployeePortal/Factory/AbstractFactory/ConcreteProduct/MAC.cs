using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static EmployeePortal.Factory.AbstractFactory.Enumerations;

namespace EmployeePortal.Factory.AbstractFactory
{
    public class MAC : IBrand
    {
        public string GetBrand()
        {
            return Brands.Apple.ToString();
        }      
    }
}