using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using drcjobs.Core.Recruiter.Models;
using drcjobs.Core.Utilities;

namespace drcjobs.Core.Recruiter
{
    [Serializable]
    public class RecruiterDataCache
    {
        private static readonly SerializableSingletonHelper<RecruiterDataCache> instanceHolder = new SerializableSingletonHelper<RecruiterDataCache>(() => new RecruiterDataCache(), intervalBeforeExpiry: TimeSpan.FromMinutes(20), maximumInstanceAge: TimeSpan.FromMinutes(40));
        private RecruiterDataCache()
        {
            Task.Run(() => this.GetData()).Wait();
        }

        private async Task GetData()
        {
            Positions = await RecruiterData.GetAllPositionsAsync();
            Locations = await RecruiterData.GetAllLocationsAsync();
            JobCategories = await RecruiterData.GetAllJobCategoriesAsync();
            ContractTypes = await RecruiterData.GetAllContractTypesAsync();
        }
        public List<Position> Positions { get; private set; }
        public List<Location> Locations { get; private set; }
        public List<JobCategory> JobCategories { get; private set; }
        public List<ContractType> ContractTypes { get; private set; }

        public static RecruiterDataCache Instance => instanceHolder.Instance;
        public static string DeserializationErrorMessage => instanceHolder.DeserializationError;
    }
}
