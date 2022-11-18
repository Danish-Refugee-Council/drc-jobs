using drcjobs.Core.Recruiter;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using drcjobs.Core.Recruiter.Models;
using Umbraco.Web.Mvc;
using System.Web.Mvc;

namespace drcjobs.Core.Controllers
{
	public class RecruiterSurfaceController : SurfaceController
	{
        public ActionResult Positions(RecruiterPositionParameters parameters = null)
        {

            var allPositions = RecruiterDataCache.Instance.Positions.ToList();
            var morePositionsToLoad = true;

            if (parameters != null)
            {
                if (parameters.SortBy != RecruiterPositionParameters.PositionSortBy.None)
                {
                    allPositions = SortPositions(parameters.SortBy, allPositions);
                }

                allPositions = allPositions.Where(p =>
                    (parameters.ContractType == 0 || p.ContractType?.Id == parameters.ContractType) &&
                    (parameters.JobCategory == 0 || p.PositionCategory?.Id == parameters.JobCategory) &&
                    (parameters.CountryRegion == 0 || p.PositionLocation?.Id == parameters.CountryRegion)
                ).Take(parameters.PageSize * parameters.Page).ToList();

                if (allPositions.Count < (parameters.PageSize * parameters.Page))
                {
                    morePositionsToLoad = false;
                }
            }

            return PartialView(@"~/Views/Partials/Recruiter/Positions.cshtml", new RecruiterPositionResponse { MorePositionsToLoad = morePositionsToLoad, Positions = allPositions });
        }

        [HttpGet]
        public string Countries()
        {
            var allCountries = RecruiterDataCache.Instance.Locations.ToList();
            allCountries.Add(new Location { Id = 0, Name = "All" });
            return JsonConvert.SerializeObject(allCountries.ToDictionary(c => c.Id, c => c.Name).OrderBy(x => x.Value));
        }

        [HttpGet]
        public string ContractTypes()
        {
            var contractTypes = RecruiterDataCache.Instance.ContractTypes.ToList();

            //Adding one more filter option called All - this is only used for setting default filters on positions table
            contractTypes.Add(new ContractType { Id = 0, Name = "All" });
            return JsonConvert.SerializeObject(contractTypes.ToDictionary(c => c.Id, c => c.Name).OrderBy(x => x.Value));
        }

        [HttpGet]
        public string Categories()
        {
            var jobCategories = RecruiterDataCache.Instance.JobCategories.ToList();
            jobCategories.Add(new JobCategory { Id = 0, Name = "All" });
            return JsonConvert.SerializeObject(jobCategories.ToDictionary(c => c.Id, c => c.Name).OrderBy(x => x.Value));
        }

        private List<Position> SortPositions(RecruiterPositionParameters.PositionSortBy sortBy, List<Position> filteredPositions)
        {
            switch (sortBy)
            {
                case RecruiterPositionParameters.PositionSortBy.DueDateSooner:
                    return filteredPositions.OrderBy(p => p.ApplicationDue).ToList();
                case RecruiterPositionParameters.PositionSortBy.DueDateLater:
                    return filteredPositions.OrderByDescending(p => p.ApplicationDue).ToList();
                case RecruiterPositionParameters.PositionSortBy.CountryAZ:
                    return filteredPositions.OrderBy(p => p.Department.Country).ToList();
                case RecruiterPositionParameters.PositionSortBy.CountryZA:
                    return filteredPositions.OrderByDescending(p => p.Department.Country).ToList();
                case RecruiterPositionParameters.PositionSortBy.ReleaseDateNew:
                    return filteredPositions.OrderBy(p => p.ReleaseDate).ToList();
                case RecruiterPositionParameters.PositionSortBy.ReleaseDateOld:
                    return filteredPositions.OrderByDescending(p => p.ReleaseDate).ToList();
                default:
                    return filteredPositions;
            }
        }

        public class RecruiterPositionParameters
        {
            public enum PositionSortBy { None = 0, DueDateSooner = 1, DueDateLater = 2, CountryAZ = 3, CountryZA = 4, ReleaseDateNew = 5, ReleaseDateOld = 6 }

            public int Page { get; set; }
            public int PageSize { get; set; }
            public int CountryRegion { get; set; }
            public int JobCategory { get; set; }
            public int ContractType { get; set; }
            public PositionSortBy SortBy { get; set; }
        }
    }
}
