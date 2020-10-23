using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public abstract class Account
    {
        private string id;
        private string password;
        private AccountStatus status;
        private Person person;

        public abstract bool resetPassword();
         
    }
}
