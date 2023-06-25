using Newtonsoft.Json;

namespace GoingMedievalWikiPopulator.JsonModels.Resources
{
    [AssetFile(@"Resources\Resources.json")]
    public class ResourceModel : IJsonModel
    {
        [JsonConstructor]
        public ResourceModel(
            [JsonProperty("repository")] List<Resource> resources
        )
        {
            this.Resources = resources;
        }

        [JsonProperty("repository")]
        public IReadOnlyList<Resource> Resources { get; }
    }
}
