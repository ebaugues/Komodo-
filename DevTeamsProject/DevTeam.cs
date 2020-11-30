using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DevTeam
    {
      public List<Developer> Employees { get; set; }

      public String TeamDescription  { get; set; }

      public int TeamId  { get; set; }
            
      public bool TeamActive  { get; set; }


      public DevTeam() { }

      public DevTeam(List<Developer> employees, String teamDescription, int teamId, bool teamActive )
            {
                Employees = employees;
                TeamDescription = teamDescription;
                TeamId = teamId;
                TeamActive = teamActive;
        
            }

    }
}
