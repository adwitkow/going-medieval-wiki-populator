using Newtonsoft.Json;

namespace GoingMedievalWikiPopulator.JsonModels.Resources
{
    [AssetFile(@"Resources\Resources.json")]
    public class ResourceModel : IJsonModel<Resource>
    {
        [JsonConstructor]
        public ResourceModel(
            [JsonProperty("repository")] List<Resource> resources
        )
        {
            Items = resources;
        }

        [JsonProperty("repository")]
        public IReadOnlyList<Resource> Items { get; }
    }
}
