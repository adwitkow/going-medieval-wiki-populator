using Newtonsoft.Json;

namespace GoingMedievalWikiPopulator.JsonModels.ProductionBuildings
{
    public class SeasonMultipliers
    {
        [JsonConstructor]
        public SeasonMultipliers(
            [JsonProperty("season")] string season,
            [JsonProperty("multipliers")] List<TemperatureMultiplier> multipliers
        )
        {
            this.Season = season;
            this.Multipliers = multipliers;
        }

        [JsonProperty("season")]
        public string Season { get; }

        [JsonProperty("multipliers")]
        public IReadOnlyList<TemperatureMultiplier> Multipliers { get; }
    }
}
