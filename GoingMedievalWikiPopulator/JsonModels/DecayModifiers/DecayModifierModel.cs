using Newtonsoft.Json;

namespace GoingMedievalWikiPopulator.JsonModels.DecayModifiers
{
    public class DecayModifierModel
    {
        [JsonConstructor]
        public DecayModifierModel(
            [JsonProperty("repository")] List<DecayModifier> modifiers
        )
        {
            this.DecayModifiers = modifiers;
        }

        [JsonProperty("repository")]
        public IReadOnlyList<DecayModifier> DecayModifiers { get; }
    }
}
