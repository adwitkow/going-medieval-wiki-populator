using Newtonsoft.Json;

namespace GoingMedievalWikiPopulator.JsonModels.Productions
{
    public class Production : IIdentifiable
    {
        [JsonConstructor]
        public Production(
            [JsonProperty("id")] string id,
            [JsonProperty("iconPath")] string iconPath,
            [JsonProperty("locKeys")] List<LocKey> locKeys,
            [JsonProperty("jobType")] int? jobType,
            [JsonProperty("requiredSkills")] List<RequiredSkill> requiredSkills,
            [JsonProperty("produced")] List<Produced> produced,
            [JsonProperty("recipe")] List<Recipe> recipe,
            [JsonProperty("productionSteps")] List<ProductionStep> productionSteps,
            [JsonProperty("forbiddenOnStart")] List<string> forbiddenOnStart,
            [JsonProperty("customProducts")] List<CustomProduct> customProducts,
            [JsonProperty("ignoreProductionModeUI")] List<int?> ignoreProductionModeUI,
            [JsonProperty("iconColorValue")] string iconColorValue,
            [JsonProperty("iconBackgroundPath")] string iconBackgroundPath
        )
        {
            this.Id = id;
            this.IconPath = iconPath;
            this.LocKeys = locKeys;
            this.JobType = jobType;
            this.RequiredSkills = requiredSkills;
            this.Produced = produced;
            this.Recipes = recipe;
            this.ProductionSteps = productionSteps;
            this.ForbiddenOnStart = forbiddenOnStart;
            this.CustomProducts = customProducts;
            this.IgnoreProductionModeUI = ignoreProductionModeUI;
            this.IconColorValue = iconColorValue;
            this.IconBackgroundPath = iconBackgroundPath;
        }

        [JsonProperty("id")]
        public string Id { get; }

        [JsonProperty("iconPath")]
        public string IconPath { get; }

        [JsonProperty("locKeys")]
        public IReadOnlyList<LocKey> LocKeys { get; }

        [JsonProperty("jobType")]
        public int? JobType { get; }

        [JsonProperty("requiredSkills")]
        public IReadOnlyList<RequiredSkill> RequiredSkills { get; }

        [JsonProperty("produced")]
        public IReadOnlyList<Produced> Produced { get; }

        [JsonProperty("recipe")]
        public IReadOnlyList<Recipe> Recipes { get; }

        [JsonProperty("productionSteps")]
        public IReadOnlyList<ProductionStep> ProductionSteps { get; }

        [JsonProperty("forbiddenOnStart")]
        public IReadOnlyList<string> ForbiddenOnStart { get; }

        [JsonProperty("customProducts")]
        public IReadOnlyList<CustomProduct> CustomProducts { get; }

        [JsonProperty("ignoreProductionModeUI")]
        public IReadOnlyList<int?> IgnoreProductionModeUI { get; }

        [JsonProperty("iconColorValue")]
        public string IconColorValue { get; }

        [JsonProperty("iconBackgroundPath")]
        public string IconBackgroundPath { get; }
    }
}
