using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DevTeamRepo
    {
        private readonly List<DevTeam> _devTeams = new List<DevTeam>();

        //DevTeam Create
        public void AddDevTeamToList(DevTeam devTeam)
        {
            _devTeams.Add(devTeam);
        }

        //DevTeam Read
        public List<DevTeam> GetDevTeamList()
        {
            return _devTeams;
        }

        public bool UpdateDevTeams(int originalTeamId, DevTeam newTeam)
        {
            //Find the team
            DevTeam originalTeamInfo = GetDevTeamById(originalTeamId);

            //update the team
            if (originalTeamInfo != null)
            {
                originalTeamInfo.TeamID = newTeam.TeamID;
                originalTeamInfo.TeamName = newTeam.TeamName;
                return true;
            }
            else
            {
                return false;
            }
        }

        //DevTeam Delete
        public bool RevmoveDevTeamFromList(int teamId)
        {
            DevTeam devTeam = GetDevTeamById(teamId);
            if (devTeam == null)
            {
                return false;
            }

            int devTeamCount = _devTeams.Count;
            _devTeams.Remove(devTeam);
            if (devTeamCount > _devTeams.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //DevTeam Update
        public void AddDevToTeam(Developer newTeamDev, int teamId)
        {
            DevTeam addToTeam= GetDevTeamById(teamId);
            if(addToTeam != null)
          {
                addToTeam.DeveloperList.Add(newTeamDev);
            }
        }

        public void RemoveDevFromTeam(Developer oldTeamDev, int teamId)
        {
            DevTeam removeFromTeam = GetDevTeamById(teamId);
            if (removeFromTeam != null)
            {
                removeFromTeam.DeveloperList.Remove(oldTeamDev);
            }
        }

        //DevTeam Helper (Get Team by ID)
        public DevTeam GetDevTeamById(int teamId)
        {
            foreach (DevTeam devTeam in _devTeams)
            {
                if (devTeam.TeamID == teamId)
                {
                    return devTeam;
                }
            }
            return null;
        }
    }
}
