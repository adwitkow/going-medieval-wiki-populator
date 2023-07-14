using Newtonsoft.Json;

namespace GoingMedievalWikiPopulator.JsonModels.Productions
{
    public class ProductionStep
    {
        [JsonConstructor]
        public ProductionStep(
            [JsonProperty("devName")] string devName,
            [JsonProperty("type")] string type,
            [JsonProperty("locKeys")] List<LocKey> locKeys,
            [JsonProperty("interruptible")] bool? interruptible,
            [JsonProperty("productionTime")] int? productionTime,
            [JsonProperty("modifyingAttribute")] string? modifyingAttribute,
            [JsonProperty("experienceReward")] List<ExperienceReward> experienceReward
        )
        {
            this.DevName = devName;
            this.Type = type;
            this.LocKeys = locKeys;
            this.Interruptible = interruptible;
            this.ProductionTime = productionTime;
            this.ModifyingAttribute = modifyingAttribute;
            this.ExperienceRewards = experienceReward;
        }

        [JsonProperty("devName")]
        public string DevName { get; }

        [JsonProperty("type")]
        public string Type { get; }

        [JsonProperty("locKeys")]
        public IReadOnlyList<LocKey> LocKeys { get; }

        [JsonProperty("interruptible")]
        public bool? Interruptible { get; }

        [JsonProperty("productionTime")]
        public int? ProductionTime { get; }

        [JsonProperty("modifyingAttribute")]
        public string? ModifyingAttribute { get; }

        [JsonProperty("experienceReward")]
        public IReadOnlyList<ExperienceReward> ExperienceRewards { get; }
    }
}
