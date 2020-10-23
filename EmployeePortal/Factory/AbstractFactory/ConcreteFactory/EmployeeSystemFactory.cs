using EmployeePortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeePortal.Factory.AbstractFactory
{
    public class EmployeeSystemFactory
    {
        public IComputerFactory Create(Employee employee)
        {
            IComputerFactory returnValue = null;
            if (employee.EmployeeTypeID == 1)
            {
                if (employee.JobDescription == "Manager")
                {
                    returnValue = new MACLeptopFactory();
                }
                else
                {
                    returnValue = new MACFactory();
                }
            }else if (employee.EmployeeTypeID == 2)
            {
                if (employee.JobDescription == "Manager")
                {
                    returnValue = new DellLeptopFactory();
                }
                else
                {
                    returnValue = new DellFactory();
                }
            }
            return returnValue;
        }
    }
}