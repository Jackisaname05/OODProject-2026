using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OODProject_2026.ApiModels
{
    public class ComicVineImage
    {
        [JsonProperty("small_url")]
        public string SmallUrl { get; set; }

        [JsonProperty("medium_url")]
        public string MediumUrl { get; set; }
    }
}
