using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProject_2026.ApiModels
{
    public class ComicVineVolume
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonProperty("start_year")]
        public string Start_Year { get; set; }

        [JsonProperty("count_of_issues")]
        public int Count_Of_Issues { get; set; }

        [JsonProperty("image")]
        public ComicVineImage Image { get; set; }
    }
}
