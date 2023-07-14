using Newtonsoft.Json;

namespace GoingMedievalWikiPopulator.JsonModels.Productions
{
    public class Recipe
    {
        [JsonConstructor]
        public Recipe(
            [JsonProperty("key")] string key,
            [JsonProperty("value")] int? value
        )
        {
            this.Key = key;
            this.Value = value;
        }

        [JsonProperty("key")]
        public string Key { get; }

        [JsonProperty("value")]
        public int? Value { get; }
    }
}
