using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class Developer
    {
        public string EmployeeId { get; set; }

        public int DevTeamId { get; set; }

        public string EmployeeName { get; set; }

        public bool ActiveEmplyoee { get; set; }

        public DateTime StartDate  { get; set; }

        public bool PluralsightLicence { get; set; } 

        public Developer() { }

        public Developer(string employeeId, int devTeamId, string employeename, bool activeEmployee, DateTime startDate, bool pluralsightLicence)
            {
            EmployeeId = employeeId;
            DevTeamId = devTeamId;
            EmployeeName = employeename;
            ActiveEmplyoee = activeEmployee;
            StartDate = startDate;            
            PluralsightLicence = pluralsightLicence;
            }

    }
}
