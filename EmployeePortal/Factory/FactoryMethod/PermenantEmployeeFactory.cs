using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeePortal.Managers;
using EmployeePortal.Models;

namespace EmployeePortal.Factory.FactoryMethod
{
    public class PermenantEmployeeFactory : BaseEmployeeFactory
    {
        public PermenantEmployeeFactory(Employee emp) : base(emp)
        {

        }
        public override IEmployeeManager Create()
        {
            PermenantEmployeeManager manager = new PermenantEmployeeManager();
            _emp.HouseAllowance = manager.GetHouseAllowance();
            return manager;
        }
    }
}