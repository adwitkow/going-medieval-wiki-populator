using GoingMedievalWikiPopulator.Generators.Effectors;
using Newtonsoft.Json;

namespace GoingMedievalWikiPopulator.JsonModels.Moods
{
    public class MoodEffect
    {
        [JsonConstructor]
        public MoodEffect(
            [JsonProperty("devName")] string devName,
            [JsonProperty("type")] EffectorType type,
            [JsonProperty("parameters")] List<MoodParameter> parameters
        )
        {
            DevName = devName;
            Type = type;
            Parameters = parameters;
        }

        [JsonProperty("devName")]
        public string DevName { get; }

        [JsonProperty("type")]
        public EffectorType Type { get; }

        [JsonProperty("parameters")]
        public IReadOnlyList<MoodParameter> Parameters { get; }
    }
}
