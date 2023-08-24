using Newtonsoft.Json;

namespace GoingMedievalWikiPopulator.JsonModels.Perks
{
    public class AttributeModifier
    {
        [JsonConstructor]
        public AttributeModifier(
            [JsonProperty("key")] int? key,
            [JsonProperty("value")] double? value
        )
        {
            this.Key = key;
            this.Value = value;
        }

        [JsonProperty("key")]
        public int? Key { get; }

        [JsonProperty("value")]
        public double? Value { get; }
    }
}
