using Newtonsoft.Json.Linq;
using OODProject_2026.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace OODProject_2026.Services
{
    public class ComicVineService
    {
        private const string API_KEY = "3e339d6f97e32b1dac960189a9b753b1df2022bb";
        private readonly HttpClient _client;

        public ComicVineService()
        {
            ServicePointManager.SecurityProtocol =
                SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://comicvine.gamespot.com/api/");
            _client.DefaultRequestHeaders.UserAgent.ParseAdd("ComicCharacterBrowserNet472");
        }

        public async Task<List<ComicVineVolume>> SearchRunsAsync(string searchName)
        {
            if (string.IsNullOrWhiteSpace(searchName))
                return new List<ComicVineVolume>();

            string url =
                "search/?api_key=" + API_KEY +
                "&format=json" +
                "&resources=volume" +
                "&query=" + Uri.EscapeDataString(searchName.Trim()) +
                "&field_list=id,name,start_year,count_of_issues,image,deck,description,publisher,person_credits";

            var body = await GetJsonBodyOrNullAsync(url);

            if (string.IsNullOrWhiteSpace(body))
                return new List<ComicVineVolume>();

            var root = JObject.Parse(body);
            int statusCode = root.Value<int?>("status_code") ?? -1;

            if (statusCode != 1)
                return new List<ComicVineVolume>();

            var resultsToken = root["results"];
            if (resultsToken == null || resultsToken.Type == JTokenType.Null)
                return new List<ComicVineVolume>();

            var results = resultsToken.ToObject<List<ComicVineVolume>>() ?? new List<ComicVineVolume>();

            return results
                .Where(v => v != null && !string.IsNullOrWhiteSpace(v.Name))
                .OrderBy(v => GetRunMatchScore(v, searchName))
                .ThenBy(v => v.Name)
                .Take(12)
                .ToList();
        }


        private async Task<string> GetJsonBodyOrNullAsync(string url)
        {
            try
            {
                var response = await _client.GetAsync(url);

                if ((int)response.StatusCode == 420)
                    return null;

                if (!response.IsSuccessStatusCode)
                    return null;

                return await response.Content.ReadAsStringAsync();
            }
            catch
            {
                return null;
            }
        }

        public async Task<ComicVineRunDetails> GetRunDetailsAsync(int volumeId)
        {
            if (volumeId <= 0)
                return null;

            try
            {
                string url =
                    "volume/4050-" + volumeId +
                    "/?api_key=" + API_KEY +
                    "&format=json" +
                    "&field_list=id,name,start_year,count_of_issues,image,deck,description,publisher,person_credits";

                var body = await GetJsonBodyOrNullAsync(url);

                if (string.IsNullOrWhiteSpace(body))
                    return null;

                var root = JObject.Parse(body);

                int statusCode = root.Value<int?>("status_code") ?? -1;

                if (statusCode != 1)
                    return null;

                var resultToken = root["results"];

                if (resultToken == null || resultToken.Type == JTokenType.Null)
                    return null;

                var details = resultToken.ToObject<ComicVineRunDetails>();

                if (details != null)
                {
                    if (string.IsNullOrWhiteSpace(details.Deck) &&
                        string.IsNullOrWhiteSpace(details.Description))
                    {
                        details.Description = "No summary was available for this run.";
                    }
                }

                return details;
            }
            catch
            {
                return null;
            }
        }

        private int GetRunMatchScore(ComicVineVolume volume, string searchName)
        {
            if (volume == null || string.IsNullOrWhiteSpace(volume.Name))
                return 9999;

            var volumeName = volume.Name.Trim().ToLowerInvariant();
            var search = (searchName ?? string.Empty).Trim().ToLowerInvariant();

            if (volumeName == search)
                return 0;

            if (volumeName.StartsWith(search))
                return 1;

            if (volumeName.Contains(search))
                return 2;

            return 3;
        }
    }
}