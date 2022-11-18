using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using drcjobs.Core.Recruiter;
using drcjobs.Core.Recruiter.Models;
using Newtonsoft.Json;
using Umbraco.Web.Mvc;

namespace drcjobs.Core.Controllers
{
    public class JobsListController : RenderMvcController
    {

        public ActionResult Index()
        {
            

            ViewBag.Countries = GetCountries();
            ViewBag.ContractTypes = GetContractTypes();
            ViewBag.Categories = GetCategories();

            return CurrentTemplate(CurrentPage);
        }

        private List<Location> GetCountries()
        {
            var allCountries = RecruiterDataCache.Instance.Locations.ToList();

            allCountries = allCountries.OrderBy(x => x.Name).ToList();
            allCountries.Insert(0, new Location { Id = 0, Name = "All" });

            return allCountries;
        }

        private List<ContractType> GetContractTypes()
        {
            var allContractTypes = RecruiterDataCache.Instance.ContractTypes.ToList();

            allContractTypes = allContractTypes.OrderBy(x => x.Name).ToList();
            allContractTypes.Insert(0, new ContractType() { Id = 0, Name = "All" });

            return allContractTypes;
        }

        private List<JobCategory> GetCategories()
        {
            var allJobCategories = RecruiterDataCache.Instance.JobCategories.ToList();

            allJobCategories = allJobCategories.OrderBy(x => x.Name).ToList();
            allJobCategories.Insert(0, new JobCategory() { Id = 0, Name = "All" });

            return allJobCategories;
        }
    }
}