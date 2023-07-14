using Newtonsoft.Json;

namespace GoingMedievalWikiPopulator.JsonModels.Productions
{
    public class CustomProduct
    {
        [JsonConstructor]
        public CustomProduct(
            [JsonProperty("input")] string input,
            [JsonProperty("output")] List<Output> output,
            [JsonProperty("onStartEffector")] string onStartEffector
        )
        {
            this.Input = input;
            this.Outputs = output;
            this.OnStartEffector = onStartEffector;
        }

        [JsonProperty("input")]
        public string Input { get; }

        [JsonProperty("output")]
        public IReadOnlyList<Output> Outputs { get; }

        [JsonProperty("onStartEffector")]
        public string OnStartEffector { get; }
    }
}
