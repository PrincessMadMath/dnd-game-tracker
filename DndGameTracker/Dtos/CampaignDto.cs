using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DndGameTracker.Dtos
{
    public class CampaignDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IList<CharacterDto> Characters { get; set; }
    }
}
