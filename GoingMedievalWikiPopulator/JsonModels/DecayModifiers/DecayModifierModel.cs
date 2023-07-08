using Newtonsoft.Json;

namespace GoingMedievalWikiPopulator.JsonModels.DecayModifiers
{
    [AssetFile(@"Resources\DecayModifiers.json")]
    public class DecayModifierModel : IJsonModel<DecayModifier>
    {
        [JsonConstructor]
        public DecayModifierModel(
            [JsonProperty("repository")] List<DecayModifier> modifiers
        )
        {
            Items = modifiers;
        }

        [JsonProperty("repository")]
        public IReadOnlyList<DecayModifier> Items { get; }
    }
}
