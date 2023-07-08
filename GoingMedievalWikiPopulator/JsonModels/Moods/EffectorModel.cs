using Newtonsoft.Json;

namespace GoingMedievalWikiPopulator.JsonModels.Moods
{
    [AssetFile(@"StatsSystem\Effectors.json")]
    public class EffectorModel : IJsonModel<Effector>
    {
        [JsonConstructor]
        public EffectorModel(
            [JsonProperty("repository")] List<Effector> effectors
        )
        {
            Items = effectors;
        }

        [JsonProperty("repository")]
        public IReadOnlyList<Effector> Items { get; }
    }
}
