using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace drcjobs.Core.Controllers
{
    public class JobsItemController : RenderMvcController
    {
        public ActionResult Index(int id)
        {
            ViewBag.PositionId = id;
            return CurrentTemplate(CurrentPage);
        }
    }
}
