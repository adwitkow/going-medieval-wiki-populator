using Newtonsoft.Json;

namespace GoingMedievalWikiPopulator.JsonModels.ProductionBuildings
{
    public class Size
    {
        [JsonConstructor]
        public Size(
            [JsonProperty("x")] int? x,
            [JsonProperty("y")] int? y,
            [JsonProperty("z")] int? z
        )
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        [JsonProperty("x")]
        public int? X { get; }

        [JsonProperty("y")]
        public int? Y { get; }

        [JsonProperty("z")]
        public int? Z { get; }
    }
}
