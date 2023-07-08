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

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType() || obj is not MoodParameter other)
            {
                return false;
            }

            return Key == other.Key
                && Value == other.Value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Key, Value);
        }
    }
}
