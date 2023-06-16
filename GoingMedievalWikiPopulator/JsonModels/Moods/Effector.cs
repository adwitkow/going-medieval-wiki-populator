using Newtonsoft.Json;

namespace GoingMedievalWikiPopulator.JsonModels.Moods
{
    public class Effector
    {
        [JsonConstructor]
        public Effector(
            [JsonProperty("id")] string id,
            [JsonProperty("locKeys")] List<LocKey> locKeys,
            [JsonProperty("category")] string category,
            [JsonProperty("bubbleIcon")] string bubbleIcon,
            [JsonProperty("uiGroup")] int uiGroup,
            [JsonProperty("effects")] List<MoodEffect> effects,
            [JsonProperty("isInstant")] bool? isInstant,
            [JsonProperty("duration")] float? duration,
            [JsonProperty("maxStack")] int? maxStack,
            [JsonProperty("stackMultiplier")] double? stackMultiplier
        )
        {
            Id = id;
            LocKeys = locKeys;
            Category = category;
            BubbleIcon = bubbleIcon;
            UiGroup = uiGroup;
            Effects = effects;
            IsInstant = isInstant;
            Duration = duration;
            MaxStack = maxStack;
            StackMultiplier = stackMultiplier;
        }

        [JsonProperty("id")]
        public string Id { get; }

        [JsonProperty("locKeys")]
        public IReadOnlyList<LocKey> LocKeys { get; }

        [JsonProperty("category")]
        public string Category { get; }

        [JsonProperty("bubbleIcon")]
        public string BubbleIcon { get; }

        [JsonProperty("uiGroup")]
        public int UiGroup { get; }

        [JsonProperty("effects")]
        public IReadOnlyList<MoodEffect> Effects { get; }

        [JsonProperty("isInstant")]
        public bool? IsInstant { get; }

        [JsonProperty("duration")]
        public float? Duration { get; }

        [JsonProperty("maxStack")]
        public int? MaxStack { get; }

        [JsonProperty("stackMultiplier")]
        public double? StackMultiplier { get; }
    }
}
