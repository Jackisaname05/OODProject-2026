using Newtonsoft.Json;
using System.Collections.Generic;

namespace OODProject_2026.ApiModels
{
    public class ComicVineRunDetails
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [JsonProperty("start_year")]
        public string StartYear { get; set; }

        [JsonProperty("count_of_issues")]
        public int CountOfIssues { get; set; }

        public string Deck { get; set; }

        public string Description { get; set; }

        public ComicVineImage Image { get; set; }

        public ComicVinePublisher Publisher { get; set; }

        [JsonProperty("person_credits")]
        public List<ComicVinePersonCredit> PersonCredits { get; set; }

        // Clean display helpers
        public string PublisherDisplay
        {
            get
            {
                return Publisher?.Name ?? "Not listed";
            }
        }

        public string PeopleDisplay
        {
            get
            {
                if (PersonCredits == null || PersonCredits.Count == 0)
                    return "Not listed";

                // Limit to first 6 so UI doesn’t explode
                var names = PersonCredits
                    .FindAll(p => !string.IsNullOrWhiteSpace(p.Name));

                if (names.Count == 0)
                    return "Not listed";

                var display = names.GetRange(0, names.Count > 6 ? 6 : names.Count)
                                   .ConvertAll(p => p.Name);

                if (names.Count > 6)
                    display.Add("...");

                return string.Join(", ", display);
            }
        }

        public string SummaryText
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(Deck))
                    return Deck;

                if (!string.IsNullOrWhiteSpace(Description))
                    return Description;

                return "No summary available for this run.";
            }
        }
    }

    public class ComicVinePublisher
    {
        public string Name { get; set; }
    }

    public class ComicVinePersonCredit
    {
        public string Name { get; set; }
    }
}
