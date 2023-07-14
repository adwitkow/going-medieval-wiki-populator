using Newtonsoft.Json;

namespace GoingMedievalWikiPopulator.JsonModels.Productions
{
    public class Output
    {
        [JsonConstructor]
        public Output(
            [JsonProperty("blueprintID")] string blueprintID,
            [JsonProperty("amount")] int? amount,
            [JsonProperty("modifyingAttribute")] int? modifyingAttribute
        )
        {
            this.BlueprintID = blueprintID;
            this.Amount = amount;
            this.ModifyingAttribute = modifyingAttribute;
        }

        [JsonProperty("blueprintID")]
        public string BlueprintID { get; }

        [JsonProperty("amount")]
        public int? Amount { get; }

        [JsonProperty("modifyingAttribute")]
        public int? ModifyingAttribute { get; }
    }
}
