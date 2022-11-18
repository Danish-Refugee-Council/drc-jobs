using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace drcjobs.Core.Recruiter.Models
{
    public class RecruiterPositionResponse
    {
        public bool MorePositionsToLoad { get; set; }
        public List<Position> Positions { get; set; }
    }
}
