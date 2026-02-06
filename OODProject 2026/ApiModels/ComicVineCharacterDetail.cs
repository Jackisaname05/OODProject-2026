using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OODProject_2026.ApiModels
{
    public class ComicVineCharacterDetail
    {
        [JsonProperty("issue_credits")]
        public List<ComicVineIssue> Issue_Credits { get; set; }
    }
}
