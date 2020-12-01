using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class Developer
    {
        public int UniqueID { get; set; }
        public string DevName { get; set; }
        public bool HasPluralsight { get; set; }

        public Developer() { }
        public Developer(int uniqueId, string devName, bool hasPluralsight)
        {
            UniqueID = uniqueId;
            DevName = devName;
            HasPluralsight = hasPluralsight;
        }
    }
}
