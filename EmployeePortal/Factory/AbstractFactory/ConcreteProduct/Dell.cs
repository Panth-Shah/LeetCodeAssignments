using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static EmployeePortal.Factory.AbstractFactory.Enumerations;


namespace EmployeePortal.Factory.AbstractFactory
{
    public class Dell : IBrand
    {
        public string GetBrand()
        {
            return Brands.Dell.ToString();
        }
    }
}