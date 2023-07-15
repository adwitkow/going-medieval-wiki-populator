using Newtonsoft.Json;

namespace GoingMedievalWikiPopulator.JsonModels.ProductionBuildings
{
    public class StorageBase
    {
        [JsonConstructor]
        public StorageBase(
            [JsonProperty("capacity")] int? capacity
        )
        {
            this.Capacity = capacity;
        }

        [JsonProperty("capacity")]
        public int? Capacity { get; }
    }
}
