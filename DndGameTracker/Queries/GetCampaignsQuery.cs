using DndGameTracker.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DndGameTracker.Queries
{
    public class GetCampaignsQuery : IRequest<IList<Campaign>>
    {
    }
}
