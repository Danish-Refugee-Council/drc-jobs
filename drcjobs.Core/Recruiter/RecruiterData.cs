using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using drcjobs.Core.Recruiter.Models;
using Newtonsoft.Json;

namespace drcjobs.Core.Recruiter
{
	public class RecruiterData
	{
		public static async Task<List<Position>> GetAllPositionsAsync()
		{
			var retry = true;
			List<Position> result = new List<Position>();
			var skip = 0;

			//According to Jesper there could be more than 100 of positions at some point
			while (retry)
			{
				var res = await RecruiterClient.Request<RecruiterResponsePositions>($"positionlist/json/?skip={skip}&take=100&incads=1&uiculture=en");

				if (res.Positions.Length > 0)
				{
					result.AddRange(res.Positions);
					skip = skip + 100;
				}
				else
				{
					retry = false;
				}
			}
			return result;
		}

		public static async Task<List<Location>> GetAllLocationsAsync()
		{
			var res = await RecruiterClient.Request<RecruiterResponseLocations>("locationlist/json/?take=100&uiculture=en");
			return new List<Location>(res.Locations);
		}

		public static async Task<List<JobCategory>> GetAllJobCategoriesAsync()
		{
			var res = await RecruiterClient.Request<RecruiterResponseJobCategories>("categorylist/json/?take=100&uiculture=en");
			return new List<JobCategory>(res.JobCategories);
		}

		public static async Task<List<ContractType>> GetAllContractTypesAsync()
		{
			var res = await RecruiterClient.Request<RecruiterResponseContractTypes>("customlist1/json/?take=100&uiculture=en");
			return new List<ContractType>(res.ContractTypes);
		}
	}

	public class RecruiterResponseWithItems
	{
		public int Count { get; set; }
	}

	public class RecruiterResponsePositions : RecruiterResponseWithItems
	{
		[JsonProperty("Items")]
		public Position[] Positions { get; set; }
	}
	public class RecruiterResponseLocations : RecruiterResponseWithItems
	{
		[JsonProperty("Items")]
		public Location[] Locations { get; set; }
	}
	public class RecruiterResponseJobCategories : RecruiterResponseWithItems
	{
		[JsonProperty("Items")]
		public JobCategory[] JobCategories { get; set; }
	}
	public class RecruiterResponseContractTypes : RecruiterResponseWithItems
	{
		[JsonProperty("Items")]
		public ContractType[] ContractTypes { get; set; }
	}
}
