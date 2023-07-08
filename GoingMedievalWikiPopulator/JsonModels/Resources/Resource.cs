using Newtonsoft.Json;

namespace GoingMedievalWikiPopulator.JsonModels.Resources
{
    public class Resource : IIdentifiable
    {
        [JsonConstructor]
        public Resource(
            [JsonProperty("id")] string id,
            [JsonProperty("hideInGame")] bool? hideInGame,
            [JsonProperty("devCommentIconPath")] string devCommentIconPath,
            [JsonProperty("iconPath")] string iconPath,
            [JsonProperty("locKeys")] List<LocKey> locKeys,
            [JsonProperty("devCommentPrefabs")] string devCommentPrefabs,
            [JsonProperty("prefabPileIDs")] List<PrefabPileId> prefabPileIDs,
            [JsonProperty("equippedPrefabIDs")] List<EquippedPrefabId> equippedPrefabIDs,
            [JsonProperty("devCommentGroupIDProtoID")] string devCommentGroupIDProtoID,
            [JsonProperty("groupIdentifier")] string groupIdentifier,
            [JsonProperty("protoId")] string protoId,
            [JsonProperty("weight")] double? weight,
            [JsonProperty("stackingLimit")] int? stackingLimit,
            [JsonProperty("haulPriority")] int? haulPriority,
            [JsonProperty("hitpoints")] int? hitpoints,
            [JsonProperty("beautyInput")] int? beautyInput,
            [JsonProperty("devCommentDecomposeRot")] string devCommentDecomposeRot,
            [JsonProperty("decomposeModifiersId")] string decomposeModifiersId,
            [JsonProperty("rotModifiersId")] string rotModifiersId,
            [JsonProperty("rottenId")] string rottenId,
            [JsonProperty("wealthPoints")] int? wealthPoints,
            [JsonProperty("devCommentcategory")] string devCommentcategory,
            [JsonProperty("category")] int? category,
            [JsonProperty("sortingGroup")] string sortingGroup,
            [JsonProperty("almanacTags")] List<string> almanacTags,
            [JsonProperty("devCommentEffectors")] string devCommentEffectors,
            [JsonProperty("proximityEffector")] string proximityEffector,
            [JsonProperty("proximityEnterEffector")] string proximityEnterEffector,
            [JsonProperty("onUseEffects")] List<string> onUseEffects,
            [JsonProperty("devCommentHealing")] string devCommentHealing,
            [JsonProperty("healing")] double? healing,
            [JsonProperty("nutrition")] int? nutrition,
            [JsonProperty("devCommentThermal")] string devCommentThermal,
            [JsonProperty("thermalModelID")] string thermalModelID,
            [JsonProperty("devCommentCal")] string devCommentCal,
            [JsonProperty("caloriesCount")] float? caloriesCount,
            [JsonProperty("beautyInputOnShelf")] int? beautyInputOnShelf,
            [JsonProperty("fermentModifiersId")] string fermentModifiersId,
            [JsonProperty("fermentedId")] string fermentedId,
            [JsonProperty("isHumanSource")] bool? isHumanSource,
            [JsonProperty("beautyInputInside")] int? beautyInputInside
        )
        {
            this.Id = id;
            this.HideInGame = hideInGame;
            this.DevCommentIconPath = devCommentIconPath;
            this.IconPath = iconPath;
            this.LocKeys = locKeys;
            this.DevCommentPrefabs = devCommentPrefabs;
            this.PrefabPileIds = prefabPileIDs;
            this.EquippedPrefabIds = equippedPrefabIDs;
            this.DevCommentGroupIdProtoId = devCommentGroupIDProtoID;
            this.GroupIdentifier = groupIdentifier;
            this.ProtoId = protoId;
            this.Weight = weight;
            this.StackingLimit = stackingLimit;
            this.HaulPriority = haulPriority;
            this.Hitpoints = hitpoints;
            this.BeautyInput = beautyInput;
            this.DevCommentDecomposeRot = devCommentDecomposeRot;
            this.DecomposeModifiersId = decomposeModifiersId;
            this.RotModifiersId = rotModifiersId;
            this.RottenId = rottenId;
            this.WealthPoints = wealthPoints;
            this.DevCommentcategory = devCommentcategory;
            this.Category = category;
            this.SortingGroup = sortingGroup;
            this.AlmanacTags = almanacTags;
            this.DevCommentEffectors = devCommentEffectors;
            this.ProximityEffector = proximityEffector;
            this.ProximityEnterEffector = proximityEnterEffector;
            this.OnUseEffects = onUseEffects;
            this.DevCommentHealing = devCommentHealing;
            this.Healing = healing;
            this.Nutrition = nutrition;
            this.DevCommentThermal = devCommentThermal;
            this.ThermalModelID = thermalModelID;
            this.DevCommentCal = devCommentCal;
            this.CaloriesCount = caloriesCount;
            this.BeautyInputOnShelf = beautyInputOnShelf;
            this.FermentModifiersId = fermentModifiersId;
            this.FermentedId = fermentedId;
            this.IsHumanSource = isHumanSource;
            this.BeautyInputInside = beautyInputInside;
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

        [JsonProperty("devCommentPrefabs")]
        public string DevCommentPrefabs { get; }

        [JsonProperty("prefabPileIDs")]
        public IReadOnlyList<PrefabPileId> PrefabPileIds { get; }

        [JsonProperty("equippedPrefabIDs")]
        public IReadOnlyList<EquippedPrefabId> EquippedPrefabIds { get; }

        [JsonProperty("devCommentGroupIDProtoID")]
        public string DevCommentGroupIdProtoId { get; }

        [JsonProperty("groupIdentifier")]
        public string GroupIdentifier { get; }

        [JsonProperty("protoId")]
        public string ProtoId { get; }

        [JsonProperty("weight")]
        public double? Weight { get; }

        [JsonProperty("stackingLimit")]
        public int? StackingLimit { get; }

        [JsonProperty("haulPriority")]
        public int? HaulPriority { get; }

        [JsonProperty("hitpoints")]
        public int? Hitpoints { get; }

        [JsonProperty("beautyInput")]
        public int? BeautyInput { get; }

        [JsonProperty("devCommentDecomposeRot")]
        public string DevCommentDecomposeRot { get; }

        [JsonProperty("decomposeModifiersId")]
        public string DecomposeModifiersId { get; }

        [JsonProperty("rotModifiersId")]
        public string RotModifiersId { get; }

        [JsonProperty("rottenId")]
        public string RottenId { get; }

        [JsonProperty("wealthPoints")]
        public int? WealthPoints { get; }

        [JsonProperty("devCommentcategory")]
        public string DevCommentcategory { get; }

        [JsonProperty("category")]
        public int? Category { get; }

        [JsonProperty("sortingGroup")]
        public string SortingGroup { get; }

        [JsonProperty("almanacTags")]
        public IReadOnlyList<string> AlmanacTags { get; }

        [JsonProperty("devCommentEffectors")]
        public string DevCommentEffectors { get; }

        [JsonProperty("proximityEffector")]
        public string ProximityEffector { get; }

        [JsonProperty("proximityEnterEffector")]
        public string ProximityEnterEffector { get; }

        [JsonProperty("onUseEffects")]
        public IReadOnlyList<string> OnUseEffects { get; }

        [JsonProperty("devCommentHealing")]
        public string DevCommentHealing { get; }

        [JsonProperty("healing")]
        public double? Healing { get; }

        [JsonProperty("nutrition")]
        public int? Nutrition { get; }

        [JsonProperty("devCommentThermal")]
        public string DevCommentThermal { get; }

        [JsonProperty("thermalModelID")]
        public string ThermalModelID { get; }

        [JsonProperty("devCommentCal")]
        public string DevCommentCal { get; }

        [JsonProperty("caloriesCount")]
        public float? CaloriesCount { get; }

        [JsonProperty("beautyInputOnShelf")]
        public int? BeautyInputOnShelf { get; }

        [JsonProperty("fermentModifiersId")]
        public string FermentModifiersId { get; }

        [JsonProperty("fermentedId")]
        public string FermentedId { get; }

        [JsonProperty("isHumanSource")]
        public bool? IsHumanSource { get; }

        [JsonProperty("beautyInputInside")]
        public int? BeautyInputInside { get; }
    }
}
