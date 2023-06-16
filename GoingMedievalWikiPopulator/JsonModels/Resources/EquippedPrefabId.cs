using Newtonsoft.Json;

namespace GoingMedievalWikiPopulator.JsonModels.Resources
{
    public class EquippedPrefabId
    {
        [JsonConstructor]
        public EquippedPrefabId(
            [JsonProperty("quality")] int? quality,
            [JsonProperty("prefabID")] string prefabID
        )
        {
            this.Quality = quality;
            this.PrefabID = prefabID;
        }

        [JsonProperty("quality")]
        public int? Quality { get; }

        [JsonProperty("prefabID")]
        public string PrefabID { get; }
    }
}
