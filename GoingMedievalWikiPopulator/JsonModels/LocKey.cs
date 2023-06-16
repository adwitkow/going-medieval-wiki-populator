using Newtonsoft.Json;

namespace GoingMedievalWikiPopulator.JsonModels
{
    public class LocKey
    {
        [JsonConstructor]
        public LocKey(
            [JsonProperty("language")] int? language,
            [JsonProperty("name")] string name,
            [JsonProperty("info")] string info,
            [JsonProperty("tooltipLines")] List<string> tooltipLines
        )
        {
            this.Language = language;
            this.Name = name;
            this.Info = info;
            this.TooltipLines = tooltipLines;
        }

        [JsonConstructor]
        public LocKey(
            [JsonProperty("language")] int? language,
            [JsonProperty("name")] string name,
            [JsonProperty("info")] string info
        )
        {
            this.Language = language;
            this.Name = name;
            this.Info = info;
            this.TooltipLines = new List<string>();
        }

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
