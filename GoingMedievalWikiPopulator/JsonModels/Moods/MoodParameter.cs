using Newtonsoft.Json;

namespace GoingMedievalWikiPopulator.JsonModels.Moods
{
    public class MoodParameter
    {
        [JsonConstructor]
        public MoodParameter(
            [JsonProperty("key")] string key,
            [JsonProperty("value")] string value
        )
        {
            Key = key;
            Value = value;
        }

        [JsonProperty("key")]
        public string Key { get; }

        [JsonProperty("value")]
        public string Value { get; }
    }
}
