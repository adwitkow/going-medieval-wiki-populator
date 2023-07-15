using Newtonsoft.Json;

namespace GoingMedievalWikiPopulator.JsonModels.ProductionBuildings
{
    public class Stat
    {
        [JsonConstructor]
        public Stat(
            [JsonProperty("debugName")] string debugName,
            [JsonProperty("type")] int? type,
            [JsonProperty("initialValue")] int? initialValue
        )
        {
            this.DebugName = debugName;
            this.Type = type;
            this.InitialValue = initialValue;
        }

        [JsonProperty("debugName")]
        public string DebugName { get; }

        [JsonProperty("type")]
        public int? Type { get; }

        [JsonProperty("initialValue")]
        public int? InitialValue { get; }
    }
}
