using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DndGameTracker.Entities
{
    public class Campaign
    {
        public Campaign()
        {
            this.Deleted = false;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public bool Deleted { get; set; }

        public virtual IList<Character> Characters { get; set; }
    }
}
