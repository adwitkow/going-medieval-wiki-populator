using Newtonsoft.Json;

namespace GoingMedievalWikiPopulator.JsonModels
{
    public class LocKey
    {
        [JsonProperty("language")]
        public int? Language { get; }

        [JsonProperty("name")]
        public string Name { get; }

        [JsonProperty("info")]
        public string Info { get; }

        [JsonProperty("tooltipLines")]
        public IReadOnlyList<string> TooltipLines { get; }
    }
}
