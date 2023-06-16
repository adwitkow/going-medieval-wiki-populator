using Newtonsoft.Json;

namespace GoingMedievalWikiPopulator.JsonModels.DecayModifiers
{
    public class WeatherModifiers
    {
        [JsonConstructor]
        public WeatherModifiers(
            [JsonProperty("keys")] List<string> keys,
            [JsonProperty("values")] List<double?> values
        )
        {
            this.Keys = keys;
            this.Values = values;
        }

        [JsonProperty("keys")]
        public IReadOnlyList<string> Keys { get; }

        [JsonProperty("values")]
        public IReadOnlyList<double?> Values { get; }
    }
}
