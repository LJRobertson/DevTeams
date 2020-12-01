using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DevTeam
    {
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public List<Developer> DeveloperList { get; set; } = new List<Developer>();

        public DevTeam() { }

        public DevTeam(int teamId, string teamName)
        {
            TeamID = teamId;
            TeamName = teamName;
        }
    }
}
