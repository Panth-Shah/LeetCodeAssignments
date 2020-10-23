using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeePortal.Managers;

namespace EmployeePortal.Factory
{
    public class EmployeeManagerFactory
    {
        //Here, House and Medical Allowance is not at the Interface Level
        //We can't add that logic in this factory as it violated the rule for Creational Pattern
        public IEmployeeManager GetEmployeeManager(int employeeTypeId)
        {
            IEmployeeManager returnValue = null;
            if (employeeTypeId == 1)
            {
                returnValue = new PermenantEmployeeManager();
            }
            else if (employeeTypeId == 2)
            {
                returnValue = new ContractEmployeeManager();
            }
            return returnValue;
        }
    }
}