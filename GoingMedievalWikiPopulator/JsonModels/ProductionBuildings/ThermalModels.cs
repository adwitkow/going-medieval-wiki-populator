using Newtonsoft.Json;

namespace GoingMedievalWikiPopulator.JsonModels.ProductionBuildings
{
    public class ThermalModels
    {
        [JsonConstructor]
        public ThermalModels(
            [JsonProperty("keys")] List<int?> keys,
            [JsonProperty("values")] List<string> values
        )
        {
            this.Keys = keys;
            this.Values = values;
        }

        [JsonProperty("keys")]
        public IReadOnlyList<int?> Keys { get; }

        [JsonProperty("values")]
        public IReadOnlyList<string> Values { get; }
    }
}
