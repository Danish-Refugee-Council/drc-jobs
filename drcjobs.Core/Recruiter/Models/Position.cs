using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace drcjobs.Core.Recruiter.Models
{
    [Serializable]
    public class Position
    {
        public int ID => Id;
        public int Id { get; set; }
        public string Name { get; set; }
        public string WorkPlace { get; set; }
        public string ApplicationFormUrlSecure { get; set; }
        public DateTime ApplicationDue { get; set; }
        [JsonProperty("Created")]
        public DateTime ReleaseDate { get; set; }
        public Advertisment[] Advertisements { get; set; }
        public Department Department { get; set; }
        public JobCategory PositionCategory { get; set; }
        [JsonProperty("CustomList1")]
        public ContractType ContractType { get; set; }
        public PositionLocation PositionLocation { get; set; }
    }

    [Serializable]
    public class Advertisment
    {
        public string Content { get; set; }
        public string ImageUrlSecure { get; set; }
        public string Description { get; set; }
        public string Introduction { get; set; }
        public string StrippedContent()
        {
            //remove style
            var res = Regex.Replace(Content, "style=(\"|')[^(\"|')]*(\"|')", "");
            //also remove class
            res = Regex.Replace(res, "class=(\"|')[^(\"|')]*(\"|')", "");
            //also remove empty p
            res = Regex.Replace(res, "(<p>\\s*</p>|<p>\\s*​\\?</p>)", "");
            //replace 3brs with 1
            res = Regex.Replace(res, "(?:\\s*<br[/\\s]*>\\s*){3,}", "");
            //remove font tags
            res = Regex.Replace(res, "</?(font)[^>]*>", "");
            return res;
        }
    }

    [Serializable]
    public class Department
    {
        [JsonProperty("Name")]
        public string Country { get; set; }
        public int Id { get; set; }
    }

    [Serializable]
    public class PositionLocation
    {
        [JsonProperty("Name")]
        public string Region { get; set; }
        public int Id { get; set; }
    }
}
