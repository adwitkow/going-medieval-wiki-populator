using Newtonsoft.Json;

namespace GoingMedievalWikiPopulator.JsonModels.Resources
{
    public class ResourceModel
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
