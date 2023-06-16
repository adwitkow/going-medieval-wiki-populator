using Newtonsoft.Json;

namespace GoingMedievalWikiPopulator.JsonModels.Moods
{
    public class EffectorModel
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
