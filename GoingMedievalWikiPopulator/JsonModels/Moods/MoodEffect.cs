using GoingMedievalWikiPopulator.Generators.Effectors;
using Newtonsoft.Json;

namespace GoingMedievalWikiPopulator.JsonModels.Moods
{
    public class MoodEffect
    {
        [JsonConstructor]
        public MoodEffect(
            [JsonProperty("devName")] string devName,
            [JsonProperty("type")] EffectorType type,
            [JsonProperty("parameters")] List<MoodParameter> parameters
        )
        {
            DevName = devName;
            Type = type;
            Parameters = parameters;
        }

        [JsonProperty("devName")]
        public string DevName { get; }

        [JsonProperty("type")]
        public EffectorType Type { get; }

        [JsonProperty("parameters")]
        public IReadOnlyList<MoodParameter> Parameters { get; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType() || obj is not MoodEffect effect)
            {
                return false;
            }

            return Equals(effect);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            var hashCode = 0;
            foreach (var parameter in Parameters)
            {
                hashCode = HashCode.Combine(hashCode, parameter.GetHashCode());
            }

            return HashCode.Combine(hashCode, DevName, Type);
        }

        private bool Equals(MoodEffect other)
        {
            if (Parameters is not null && other.Parameters is not null)
            {
                if (Parameters.Count != other.Parameters.Count)
                {
                    return false;
                }

                for (int i = 0; i < Parameters.Count; i++)
                {
                    if (!Parameters[i].Equals(other.Parameters[i]))
                    {
                        return false;
                    }
                }
            }

            return DevName == other.DevName
                && Type == other.Type;
        }
    }
}
