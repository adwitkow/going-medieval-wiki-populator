using Newtonsoft.Json;

namespace GoingMedievalWikiPopulator.JsonModels.Perks
{
    public class Perk : IIdentifiable, ILocalizable
    {
        [JsonConstructor]
        public Perk(
            [JsonProperty("id")] string id,
            [JsonProperty("hideInGame")] bool? hideInGame,
            [JsonProperty("devCommentIconPath")] string devCommentIconPath,
            [JsonProperty("iconPath")] string iconPath,
            [JsonProperty("locKeys")] List<LocKey> locKeys,
            [JsonProperty("conflictsWith")] List<string> conflictsWith,
            [JsonProperty("skillModifiers")] List<SkillModifier> skillModifiers,
            [JsonProperty("attributeModifiers")] List<AttributeModifier> attributeModifiers,
            [JsonProperty("devCommentEffector")] string devCommentEffector,
            [JsonProperty("effector")] string effector,
            [JsonProperty("devCommentBannedEffector")] string devCommentBannedEffector,
            [JsonProperty("bannedEffector")] List<string> bannedEffector,
            [JsonProperty("devCommentAllowedEffectors")] string devCommentAllowedEffectors,
            [JsonProperty("allowedEffectors")] List<string> allowedEffectors,
            [JsonProperty("creationPointCost")] int? creationPointCost,
            [JsonProperty("forbidOnBirthday")] bool? forbidOnBirthday,
            [JsonProperty("ignoreCharacteristicType")] List<int?> ignoreCharacteristicType
        )
        {
            this.Id = id;
            this.HideInGame = hideInGame;
            this.DevCommentIconPath = devCommentIconPath;
            this.IconPath = iconPath;
            this.LocKeys = locKeys;
            this.ConflictsWith = conflictsWith;
            this.SkillModifiers = skillModifiers;
            this.AttributeModifiers = attributeModifiers;
            this.DevCommentEffector = devCommentEffector;
            this.Effector = effector;
            this.DevCommentBannedEffector = devCommentBannedEffector;
            this.BannedEffector = bannedEffector;
            this.DevCommentAllowedEffectors = devCommentAllowedEffectors;
            this.AllowedEffectors = allowedEffectors;
            this.CreationPointCost = creationPointCost;
            this.ForbidOnBirthday = forbidOnBirthday;
            this.IgnoreCharacteristicType = ignoreCharacteristicType;
        }

        [JsonProperty("id")]
        public string Id { get; }

        [JsonProperty("hideInGame")]
        public bool? HideInGame { get; }

        [JsonProperty("devCommentIconPath")]
        public string DevCommentIconPath { get; }

        [JsonProperty("iconPath")]
        public string IconPath { get; }

        [JsonProperty("locKeys")]
        public IReadOnlyList<LocKey> LocKeys { get; }

        [JsonProperty("conflictsWith")]
        public IReadOnlyList<string> ConflictsWith { get; }

        [JsonProperty("skillModifiers")]
        public IReadOnlyList<SkillModifier> SkillModifiers { get; }

        [JsonProperty("attributeModifiers")]
        public IReadOnlyList<AttributeModifier> AttributeModifiers { get; }

        [JsonProperty("devCommentEffector")]
        public string DevCommentEffector { get; }

        [JsonProperty("effector")]
        public string Effector { get; }

        [JsonProperty("devCommentBannedEffector")]
        public string DevCommentBannedEffector { get; }

        [JsonProperty("bannedEffector")]
        public IReadOnlyList<string> BannedEffector { get; }

        [JsonProperty("devCommentAllowedEffectors")]
        public string DevCommentAllowedEffectors { get; }

        [JsonProperty("allowedEffectors")]
        public IReadOnlyList<string> AllowedEffectors { get; }

        [JsonProperty("creationPointCost")]
        public int? CreationPointCost { get; }

        [JsonProperty("forbidOnBirthday")]
        public bool? ForbidOnBirthday { get; }

        [JsonProperty("ignoreCharacteristicType")]
        public IReadOnlyList<int?> IgnoreCharacteristicType { get; }
    }
}
