using Newtonsoft.Json;

namespace GoingMedievalWikiPopulator.JsonModels.ProductionBuildings
{
    [AssetFile(@"Constructables\ProductionBuildings.json")]
    public class ProductionBuildingsModel : IJsonModel<ProductionBuilding>
    {
        [JsonConstructor]
        public ProductionBuildingsModel(
            [JsonProperty("repository")] List<ProductionBuilding> repository
        )
        {
            this.Items = repository;
        }

        [JsonProperty("repository")]
        public IReadOnlyList<ProductionBuilding> Items { get; }
    }
}
