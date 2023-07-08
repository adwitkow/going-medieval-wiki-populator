using Newtonsoft.Json;

namespace GoingMedievalWikiPopulator.JsonModels.Moods
{
    public class Effector : IIdentifiable
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

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType() || obj is not Effector effector)
            {
                return false;
            }

            return Equals(effector);
        }

        public override int GetHashCode()
        {
            var hashCode = 0;
            foreach (var locKey in LocKeys)
            {
                HashCode.Combine(hashCode, locKey.GetHashCode());
            }

            foreach (var mood in Effects)
            {
                HashCode.Combine(hashCode, mood.GetHashCode());
            }

            return HashCode.Combine(Id, Category, BubbleIcon, UiGroup, IsInstant, Duration, MaxStack, StackMultiplier);
        }

        private bool Equals(Effector other)
        {
            if (LocKeys != null && other.LocKeys != null)
            {
                if (LocKeys.Count != other.LocKeys.Count)
                {
                    return false;
                }

                for (int i = 0; i < LocKeys.Count; i++)
                {
                    if (!LocKeys[i].Equals(other.LocKeys[i]))
                    {
                        return false;
                    }
                }
            }

            if (Effects != null && other.Effects != null)
            {
                if (Effects.Count != other.Effects.Count)
                {
                    return false;
                }

                for (int i = 0; i < Effects.Count; i++)
                {
                    if (!Effects[i].Equals(other.Effects[i]))
                    {
                        return false;
                    }
                }
            }

            return Id == other.Id
                && Category == other.Category
                && BubbleIcon == other.BubbleIcon
                && UiGroup == other.UiGroup
                && IsInstant == other.IsInstant
                && Duration == other.Duration
                && MaxStack == other.MaxStack
                && StackMultiplier == other.StackMultiplier;
        }
    }
}
