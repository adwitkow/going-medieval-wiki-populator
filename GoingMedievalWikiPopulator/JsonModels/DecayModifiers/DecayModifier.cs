using Newtonsoft.Json;

namespace GoingMedievalWikiPopulator.JsonModels.DecayModifiers
{
    public class DecayModifier : IIdentifiable
    {
        [JsonConstructor]
        public DecayModifier(
            [JsonProperty("id")] string id,
            [JsonProperty("temperatureCoefficients")] List<double?> temperatureCoefficients,
            [JsonProperty("groundCoefficient")] double? groundCoefficient,
            [JsonProperty("weatherModifiers")] KeysAndValues weatherModifiers
        )
        {
            this.Id = id;
            this.TemperatureCoefficients = temperatureCoefficients;
            this.GroundCoefficient = groundCoefficient;
            this.WeatherModifiers = weatherModifiers;
        }

        [JsonProperty("id")]
        public string Id { get; }

        [JsonProperty("temperatureCoefficients")]
        public IReadOnlyList<double?> TemperatureCoefficients { get; }

        [JsonProperty("groundCoefficient")]
        public double? GroundCoefficient { get; }

        [JsonProperty("weatherModifiers")]
        public KeysAndValues WeatherModifiers { get; }
    }
}
