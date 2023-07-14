using Newtonsoft.Json;

namespace GoingMedievalWikiPopulator.JsonModels.Productions
{
    [AssetFile(@"Resources\Production.json")]
    public class ProductionModel : IJsonModel<Production>
    {
        [JsonConstructor]
        public ProductionModel(
            [JsonProperty("repository")] List<Production> repository
        )
        {
            this.Items = repository;
        }

        [JsonProperty("repository")]
        public IReadOnlyList<Production> Items { get; }
    }
}
