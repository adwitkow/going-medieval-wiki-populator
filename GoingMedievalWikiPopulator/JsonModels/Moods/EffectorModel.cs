using Newtonsoft.Json;

namespace GoingMedievalWikiPopulator.JsonModels.Moods
{
    [AssetFile(@"StatsSystem\Effectors.json")]
    public class EffectorModel : IJsonModel
    {
        [JsonConstructor]
        public EffectorModel(
            [JsonProperty("repository")] List<Effector> effectors
        )
        {
            Effectors = effectors;
        }

        [JsonProperty("repository")]
        public IReadOnlyList<Effector> Effectors { get; }
    }
}
