using _DevTeamsProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DevTeamRepo
    {
        private List<DevTeam> _developerTeamRepo = new List<DevTeam>();
      
        //DevTeam Create
        public void AddToTeamsLists(DevTeam devTeam)
        {
            _developerTeamRepo.Add(devTeam);
        }

        //DevTeam Read
        public List<DevTeam> GetDeveloperTeamLists()
        {
            return _developerTeamRepo;

        }

        //DevTeam Update

        public bool UpdateExistingDevTeam(int teamid, DevTeam NewDevTeam)
        {
            //Find Content
            DevTeam OldDevTeam = GetDevTeamById(teamid);


            //Update Content
            if (OldDevTeam != null)  //Check content was returned
            {
                // OldDeveloper.EmployeeName = NewDeveloper.EmployeeName;
                OldDevTeam.Employees = NewDevTeam.Employees;
                OldDevTeam.TeamDescription = NewDevTeam.TeamDescription;
                OldDevTeam.TeamActive = NewDevTeam.TeamActive;
                return true;
            }
            else
            {
                return false;
            }
        }


        //DevTeam Delete
        public bool RemoveDevTeamFromLists(int teamid)
        {
            DevTeam devTeam = GetDevTeamById(teamid);
            if (devTeam == null)
            {
                return false;
            }


            int initialCount = _developerTeamRepo.Count;
            _developerTeamRepo.Remove(devTeam);

            if (initialCount > _developerTeamRepo.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //DevTeam Helper (Get Team by ID)
        public DevTeam GetDevTeamById(int teamId)
        {
            //Iterrate through the list
            foreach (DevTeam devTeam in _developerTeamRepo)
            {
                if (devTeam.TeamId == teamId)  //What if there are multiple with same title in list?
                {
                    return devTeam;
                }
            }

            return null;
        }

        public int AreDevlopers(int teamid)
        { 
            DevTeam devTeam = GetDevTeamById(teamid);
            { if (devTeam.Employees == null)
                    {
                     return 0; 
                    }
               else {
                     return 1;
                    }
            }
        }
    }
}
