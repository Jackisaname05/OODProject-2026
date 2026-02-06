using Newtonsoft.Json;
using OODProject_2026.ApiModels;
using OODProject_2026.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
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
        // Runs by character name
        public async Task<List<ComicVineVolume>> SearchRunsAsync(string characterName)
        {
            string url =
                "search/?api_key=" + API_KEY +
                "&format=json" +
                "&resources=volume" +
                "&query=" + Uri.EscapeDataString(characterName) +
                "&field_list=id,name,start_year,count_of_issues,image";

            var resp = await _client.GetAsync(url);
            var body = await resp.Content.ReadAsStringAsync();
            resp.EnsureSuccessStatusCode();

            var data = JsonConvert.DeserializeObject<ComicVineListResponse<ComicVineVolume>>(body);
            return (data != null && data.Results != null) ? data.Results : new List<ComicVineVolume>();
        }

        // Appearances via issue credits
        public async Task<List<ComicVineIssue>> GetAppearancesAsync(int comicVineCharacterId)
        {
            string url =
                "character/4005-" + comicVineCharacterId +
                "/?api_key=" + API_KEY +
                "&format=json" +
                "&field_list=issue_credits";

            var resp = await _client.GetAsync(url);
            var body = await resp.Content.ReadAsStringAsync();
            resp.EnsureSuccessStatusCode();

            var data = JsonConvert.DeserializeObject<ComicVineResponse<ComicVineCharacterDetail>>(body);
            if (data != null && data.Results != null && data.Results.Issue_Credits != null)
                return data.Results.Issue_Credits;

            return new List<ComicVineIssue>();
        }

    }
}
