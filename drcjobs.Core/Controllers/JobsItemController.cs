using System.Web.Mvc;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace drcjobs.Core.Controllers
{
    public class JobsItemController : RenderMvcController
    {
        public ActionResult Index(int? id)
        {
            if (!id.HasValue)
            {
                return new RedirectResult(CurrentPage.Parent.Url(), false);
            }
            ViewBag.PositionId = id;
            return CurrentTemplate(CurrentPage);
        }
    }
}
