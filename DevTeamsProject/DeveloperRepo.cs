using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DeveloperRepo
    {
        private readonly List<Developer> _developerDirectory = new List<Developer>();

        //Developer Create
        public void AddDeveloperToList(Developer developer)
        {
            _developerDirectory.Add(developer);
        }

        //Developer Read
        public List<Developer> GetDeveloperList()
        {
            return _developerDirectory;
        }

        //Developer Update
        public bool UpdateDeveloperInfo(int existingId, Developer newDeveloper)
        {
            //find the developer to update
            Developer oldInfo = GetDeveloperById(existingId);

            //update developer
            if (oldInfo != null)
            {
                oldInfo.UniqueID = newDeveloper.UniqueID;
                oldInfo.DevName = newDeveloper.DevName;
                oldInfo.HasPluralsight = newDeveloper.HasPluralsight;

                return true;
            }
            else
            {
                return false;
            }

        }

        //Developer Delete
        public bool RemoveDeveloperFromList(int uniqueId)
        {
            Developer developer = GetDeveloperById(uniqueId);
            if (developer == null)
            {
                return false;
            }

            int initialDevCount = _developerDirectory.Count;
            _developerDirectory.Remove(developer);

            if (initialDevCount > _developerDirectory.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Developer Helper (Get Developer by ID)
        public Developer GetDeveloperById(int id)
        {
            foreach (Developer developer in _developerDirectory)
            {
                if (developer.UniqueID == id)
                {
                    return developer;
                }
            }
            return null;
        }
    }
}
