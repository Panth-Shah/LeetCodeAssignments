using EmployeePortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeePortal.Factory.FactoryMethod
{
    public class EmployeeManagerFactory
    {
        public BaseEmployeeFactory CreateFactory(Employee  emp)
        {
            BaseEmployeeFactory returnValue = null;
            if (emp.EmployeeTypeID == 1)
            {
                returnValue = new PermenantEmployeeFactory(emp);
            }else if (emp.EmployeeTypeID == 2)
            {
                returnValue = new ContractEmployeeFactory(emp);
            }
            return returnValue;
        }
    }
}