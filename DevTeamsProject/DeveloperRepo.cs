using DevTeamsProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DevTeamsProject
{  
    public class DeveloperRepo
    {
        private List<Developer> _developerDirectory = new List<Developer>();
        
        //Developer Create
        public void AddDeveloperToLists(Developer developer) 
        {
           _developerDirectory.Add(developer);
        }

        //Developer Read
        public List<Developer> GetDeveloperLists()
        {
            return _developerDirectory;

        }

        //Developer Update
         public bool UpdateExistingDeveloper(string employeeId, Developer NewDeveloper)
        {
            //Find Content
            Developer OldDeveloper = GetDeveloperById(employeeId);


            //Update Content
            if (OldDeveloper != null)  //Check content was returned
            {
                OldDeveloper.EmployeeName = NewDeveloper.EmployeeName;
                OldDeveloper.StartDate = NewDeveloper.StartDate;
                OldDeveloper.DevTeamId = NewDeveloper.DevTeamId;
                OldDeveloper.PluralsightLicence = NewDeveloper.PluralsightLicence;
                OldDeveloper.ActiveEmplyoee = NewDeveloper.ActiveEmplyoee;
                return true;
            }
            else
            {
                return false;
            }
        }

        //Developer Delete
         public bool RemoveDeveloperFromLists(string employeeId)
        {
            Developer developer = GetDeveloperById(employeeId);
            if (developer == null) 
            {
                return false;
            }


            int initialCount = _developerDirectory.Count;
            _developerDirectory.Remove(developer);

            if(initialCount > _developerDirectory.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //Developer Helper (Get Developer by ID)
          public Developer GetDeveloperById(string employeeId)
        {
            //Iterrate through the list
            foreach(Developer developer in _developerDirectory)
            {
                if (developer.EmployeeId.ToUpper() == employeeId.ToUpper())  //What if there are multiple with same title in list?
                {
                    return developer;
                }
            }

            return null;
        }

         // Developer Exists
         public bool FindDeveloper(string employeeId)
        {
            //Find Content
            Developer FindDeveloper = GetDeveloperById(employeeId);


            //Update Content
            if (FindDeveloper != null)  //Check content was returned
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
