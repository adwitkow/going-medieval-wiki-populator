using Newtonsoft.Json;

namespace GoingMedievalWikiPopulator.JsonModels
{
    public class KeysAndValues
    {
        [JsonConstructor]
        public KeysAndValues(
            [JsonProperty("keys")] List<string> keys,
            [JsonProperty("values")] List<double?> values
        )
        {
            Keys = keys;
            Values = values;
        }

        [JsonProperty("keys")]
        public IReadOnlyList<string> Keys { get; }

        [JsonProperty("values")]
        public IReadOnlyList<double?> Values { get; }
    }
}
