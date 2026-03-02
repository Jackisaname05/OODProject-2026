using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProject_2026.ApiModels
{
    public class ComicVineResponse<T>
    {
        [JsonProperty("status_code")]
        public int Status_Code { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("results")]
        public T Results { get; set; }
    }
}
