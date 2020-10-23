using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeePortal.Managers
{
    //House alloance feature is only application to Permenant Employees and not Contract,
    //We will be making this change in this class and not in Interface
    public class PermenantEmployeeManager : IEmployeeManager
    {
        public decimal GetBonus()
        {
            return 10;
        }

        public decimal GetPay()
        {
            return 8;
        }

        public decimal GetHouseAllowance()
        {
            return 150;
        }
    }
}