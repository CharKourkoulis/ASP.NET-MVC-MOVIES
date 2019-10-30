using Imerologio.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Imerologio.EmployeeManagerFactory
{
    public class EmployeeManagerFactoryMethod
    {

        public IEmployeeManager GetEmployeeManager(int employeeTypeID)
        {
            IEmployeeManager returnValue = null;

            if (employeeTypeID == 3)
            {
                returnValue = new PermanentEmployeeManager();
            }
            else if(employeeTypeID == 4)
            {
                returnValue = new ContractEmployeeManager();
            }
            return returnValue;
        }

    }
}