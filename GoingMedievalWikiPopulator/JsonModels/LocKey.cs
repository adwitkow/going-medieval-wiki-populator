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

        [JsonProperty("language")]
        public int? Language { get; }

        [JsonProperty("name")]
        public string Name { get; }

        [JsonProperty("info")]
        public string Info { get; }

        [JsonProperty("tooltipLines")]
        public IReadOnlyList<string> TooltipLines { get; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType() || obj is not LocKey locKey)
            {
                return false;
            }

            return Equals(locKey);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(TooltipLines, Language, Name, Info);
        }

        private bool Equals(LocKey other)
        {
            if (TooltipLines != null && other.TooltipLines != null)
            {
                if (TooltipLines.Count != other.TooltipLines.Count)
                {
                    return false;
                }

                for (int i = 0; i < TooltipLines.Count; i++)
                {
                    if (!TooltipLines[i].Equals(other.TooltipLines[i]))
                    {
                        return false;
                    }
                }
            }

            return Language == other.Language
                && Name == other.Name
                && Info == other.Info;
        }
    }
}
