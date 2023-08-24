using Newtonsoft.Json;

namespace GoingMedievalWikiPopulator.JsonModels.Perks
{
    [AssetFile(@"Worker\Perk.json")]
    public class PerkModel : IJsonModel<Perk>
    {
        [JsonConstructor]
        public PerkModel(
            [JsonProperty("repository")] List<Perk> perks
        )
        {
            this.Items = perks;
        }

        [JsonProperty("repository")]
        public IReadOnlyList<Perk> Items { get; }
    }
}
