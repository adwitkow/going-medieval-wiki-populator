using Newtonsoft.Json;

namespace GoingMedievalWikiPopulator.JsonModels.ProductionBuildings
{
    public class TemperatureMultiplier
    {
        [JsonConstructor]
        public TemperatureMultiplier(
            [JsonProperty("temperature")] int? temperature,
            [JsonProperty("multiplier")] double? multiplier,
            [JsonProperty("mode")] string mode
        )
        {
            this.Temperature = temperature;
            this.Multiplier = multiplier;
            this.Mode = mode;
        }

        [JsonProperty("temperature")]
        public int? Temperature { get; }

        [JsonProperty("multiplier")]
        public double? Multiplier { get; }

        [JsonProperty("mode")]
        public string Mode { get; }
    }
}
