using Newtonsoft.Json;

namespace GoingMedievalWikiPopulator.JsonModels.ProductionBuildings
{
    public class ProductionBuilding : IIdentifiable, ILocalizable
    {
        [JsonConstructor]
        public ProductionBuilding(
            [JsonProperty("id")] string id,
            [JsonProperty("iconPath")] string iconPath,
            [JsonProperty("locKeys")] List<LocKey> locKeys,
            [JsonProperty("prefabID")] string prefabID,
            [JsonProperty("previewPrefabID")] string previewPrefabID,
            [JsonProperty("buildTime")] int? buildTime,
            [JsonProperty("size")] Size size,
            [JsonProperty("buildingCategoryUI")] int? buildingCategoryUI,
            [JsonProperty("buildingSubCategoryUI")] int? buildingSubCategoryUI,
            [JsonProperty("soundMaterialCategory")] int? soundMaterialCategory,
            [JsonProperty("buildingType")] int? buildingType,
            [JsonProperty("constructableBaseCategory")] int? constructableBaseCategory,
            [JsonProperty("placementType")] int? placementType,
            [JsonProperty("materials")] KeysAndValues materials,
            [JsonProperty("storageBase")] StorageBase storageBase,
            [JsonProperty("pathfindingPenalty")] int? pathfindingPenalty,
            [JsonProperty("maxPoolCount")] int? maxPoolCount,
            [JsonProperty("refillThreshold")] int? refillThreshold,
            [JsonProperty("placeableBellowOthers")] bool? placeableBellowOthers,
            [JsonProperty("transfersStability")] bool? transfersStability,
            [JsonProperty("layerShadowOffset")] int? layerShadowOffset,
            [JsonProperty("layerHideOffset")] int? layerHideOffset,
            [JsonProperty("idleTargetForbidden")] bool? idleTargetForbidden,
            [JsonProperty("attackTraversePenalty")] double? attackTraversePenalty,
            [JsonProperty("cover")] int? cover,
            [JsonProperty("stats")] List<Stat> stats,
            [JsonProperty("productionSpeedMultiplier")] ProductionSpeedMultiplier productionSpeedMultiplier,
            [JsonProperty("wealthPoints")] int? wealthPoints,
            [JsonProperty("beautyInput")] int? beautyInput,
            [JsonProperty("interactAnimation")] string interactAnimation,
            [JsonProperty("interactTool")] string interactTool,
            [JsonProperty("destroyParticles")] string destroyParticles,
            [JsonProperty("productions")] List<string> productions,
            [JsonProperty("canBeMoved")] bool? canBeMoved,
            [JsonProperty("pilePrefabID")] string pilePrefabID,
            [JsonProperty("weight")] int? weight,
            [JsonProperty("sortingGroup")] string sortingGroup,
            [JsonProperty("decomposeModifiersId")] string decomposeModifiersId,
            [JsonProperty("thermalModels")] ThermalModels thermalModels,
            [JsonProperty("minBuildSkillRequired")] int? minBuildSkillRequired,
            [JsonProperty("productionSpeedMultiplierTemperature")] List<TemperatureMultiplier> productionSpeedMultiplierTemperature,
            [JsonProperty("productionSpeedMultipliersBySeason")] List<SeasonMultipliers> productionSpeedMultipliersBySeason
        )
        {
            this.Id = id;
            this.IconPath = iconPath;
            this.LocKeys = locKeys;
            this.PrefabID = prefabID;
            this.PreviewPrefabID = previewPrefabID;
            this.BuildTime = buildTime;
            this.Size = size;
            this.BuildingCategoryUI = buildingCategoryUI;
            this.BuildingSubCategoryUI = buildingSubCategoryUI;
            this.SoundMaterialCategory = soundMaterialCategory;
            this.BuildingType = buildingType;
            this.ConstructableBaseCategory = constructableBaseCategory;
            this.PlacementType = placementType;
            this.Materials = materials;
            this.StorageBase = storageBase;
            this.PathfindingPenalty = pathfindingPenalty;
            this.MaxPoolCount = maxPoolCount;
            this.RefillThreshold = refillThreshold;
            this.PlaceableBellowOthers = placeableBellowOthers;
            this.TransfersStability = transfersStability;
            this.LayerShadowOffset = layerShadowOffset;
            this.LayerHideOffset = layerHideOffset;
            this.IdleTargetForbidden = idleTargetForbidden;
            this.AttackTraversePenalty = attackTraversePenalty;
            this.Cover = cover;
            this.Stats = stats;
            this.ProductionSpeedMultiplier = productionSpeedMultiplier;
            this.WealthPoints = wealthPoints;
            this.BeautyInput = beautyInput;
            this.InteractAnimation = interactAnimation;
            this.InteractTool = interactTool;
            this.DestroyParticles = destroyParticles;
            this.Productions = productions;
            this.CanBeMoved = canBeMoved;
            this.PilePrefabID = pilePrefabID;
            this.Weight = weight;
            this.SortingGroup = sortingGroup;
            this.DecomposeModifiersId = decomposeModifiersId;
            this.ThermalModels = thermalModels;
            this.MinBuildSkillRequired = minBuildSkillRequired;
            this.ProductionSpeedMultiplierTemperature = productionSpeedMultiplierTemperature;
            this.ProductionSpeedMultipliersBySeason = productionSpeedMultipliersBySeason;
        }

        [JsonProperty("id")]
        public string Id { get; }

        [JsonProperty("iconPath")]
        public string IconPath { get; }

        [JsonProperty("locKeys")]
        public IReadOnlyList<LocKey> LocKeys { get; }

        [JsonProperty("prefabID")]
        public string PrefabID { get; }

        [JsonProperty("previewPrefabID")]
        public string PreviewPrefabID { get; }

        [JsonProperty("buildTime")]
        public int? BuildTime { get; }

        [JsonProperty("size")]
        public Size Size { get; }

        [JsonProperty("buildingCategoryUI")]
        public int? BuildingCategoryUI { get; }

        [JsonProperty("buildingSubCategoryUI")]
        public int? BuildingSubCategoryUI { get; }

        [JsonProperty("soundMaterialCategory")]
        public int? SoundMaterialCategory { get; }

        [JsonProperty("buildingType")]
        public int? BuildingType { get; }

        [JsonProperty("constructableBaseCategory")]
        public int? ConstructableBaseCategory { get; }

        [JsonProperty("placementType")]
        public int? PlacementType { get; }

        [JsonProperty("materials")]
        public KeysAndValues Materials { get; }

        [JsonProperty("storageBase")]
        public StorageBase StorageBase { get; }

        [JsonProperty("pathfindingPenalty")]
        public int? PathfindingPenalty { get; }

        [JsonProperty("maxPoolCount")]
        public int? MaxPoolCount { get; }

        [JsonProperty("refillThreshold")]
        public int? RefillThreshold { get; }

        [JsonProperty("placeableBellowOthers")]
        public bool? PlaceableBellowOthers { get; }

        [JsonProperty("transfersStability")]
        public bool? TransfersStability { get; }

        [JsonProperty("layerShadowOffset")]
        public int? LayerShadowOffset { get; }

        [JsonProperty("layerHideOffset")]
        public int? LayerHideOffset { get; }

        [JsonProperty("idleTargetForbidden")]
        public bool? IdleTargetForbidden { get; }

        [JsonProperty("attackTraversePenalty")]
        public double? AttackTraversePenalty { get; }

        [JsonProperty("cover")]
        public int? Cover { get; }

        [JsonProperty("stats")]
        public IReadOnlyList<Stat> Stats { get; }

        [JsonProperty("productionSpeedMultiplier")]
        public ProductionSpeedMultiplier ProductionSpeedMultiplier { get; }

        [JsonProperty("wealthPoints")]
        public int? WealthPoints { get; }

        [JsonProperty("beautyInput")]
        public int? BeautyInput { get; }

        [JsonProperty("interactAnimation")]
        public string InteractAnimation { get; }

        [JsonProperty("interactTool")]
        public string InteractTool { get; }

        [JsonProperty("destroyParticles")]
        public string DestroyParticles { get; }

        [JsonProperty("productions")]
        public IReadOnlyList<string> Productions { get; }

        [JsonProperty("canBeMoved")]
        public bool? CanBeMoved { get; }

        [JsonProperty("pilePrefabID")]
        public string PilePrefabID { get; }

        [JsonProperty("weight")]
        public int? Weight { get; }

        [JsonProperty("sortingGroup")]
        public string SortingGroup { get; }

        [JsonProperty("decomposeModifiersId")]
        public string DecomposeModifiersId { get; }

        [JsonProperty("thermalModels")]
        public ThermalModels ThermalModels { get; }

        [JsonProperty("minBuildSkillRequired")]
        public int? MinBuildSkillRequired { get; }

        [JsonProperty("productionSpeedMultiplierTemperature")]
        public IReadOnlyList<TemperatureMultiplier> ProductionSpeedMultiplierTemperature { get; }

        [JsonProperty("productionSpeedMultipliersBySeason")]
        public IReadOnlyList<SeasonMultipliers> ProductionSpeedMultipliersBySeason { get; }
    }
}
