using Newtonsoft.Json;

namespace GoingMedievalWikiPopulator.JsonModels.Productions
{
    public class Produced
    {
        [JsonConstructor]
        public Produced(
            [JsonProperty("blueprintID")] string blueprintID,
            [JsonProperty("amount")] int? amount
        )
        {
            this.BlueprintID = blueprintID;
            this.Amount = amount;
        }

        [JsonProperty("blueprintID")]
        public string BlueprintID { get; }

        [JsonProperty("amount")]
        public int? Amount { get; }
    }
}
