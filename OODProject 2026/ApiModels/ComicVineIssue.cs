using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OODProject_2026.ApiModels
{
    public class ComicVineIssue
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonProperty("issue_number")]
        public string Issue_Number { get; set; }
        [JsonProperty("cover_date")]
        public string Cover_Date { get; set; }
        [JsonProperty("image")]
        public ComicVineImage Image { get; set; }
        
    }
}
