using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using drcjobs.Core.Recruiter;
using drcjobs.Core.Recruiter.Models;
using Umbraco.Web.Mvc;

namespace drcjobs.Core.Controllers
{
    public class SinglePositionController : SurfaceController
    {
        public ActionResult GetSinglePosition(string id)
        {
            return PartialView(@"~/Views/Partials/Recruiter/SinglePosition.cshtml", CurrentPosition(id));
        }

        public Position CurrentPosition(string PostionQuery)
        {
            try
            {
                return RecruiterDataCache.Instance.Positions.Where(p => p.Id == Int32.Parse(PostionQuery)).FirstOrDefault();
            }
            catch { return null; }
        }
    }
}
