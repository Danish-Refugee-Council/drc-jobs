using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace drcjobs.Core.Recruiter.Models
{
    [Serializable]
    public class JobCategory
    {
        public int ID => Id;
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
