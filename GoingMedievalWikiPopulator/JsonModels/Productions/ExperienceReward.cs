using Newtonsoft.Json;

namespace GoingMedievalWikiPopulator.JsonModels.Productions
{
    public class ExperienceReward
    {
        [JsonConstructor]
        public ExperienceReward(
            [JsonProperty("key")] SkillType key,
            [JsonProperty("value")] int value
        )
        {
            this.Key = key;
            this.Value = value;
        }

        [JsonProperty("key")]
        public SkillType Key { get; }

        [JsonProperty("value")]
        public int Value { get; }
    }
}
