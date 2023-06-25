using Newtonsoft.Json;

namespace GoingMedievalWikiPopulator.JsonModels.DecayModifiers
{
    [AssetFile(@"Resources\DecayModifiers.json")]
    public class DecayModifierModel : IJsonModel
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
