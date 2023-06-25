using System.Reflection;
using GoingMedievalWikiPopulator.JsonModels;
using Newtonsoft.Json;

namespace GoingMedievalWikiPopulator
{
    internal class GameModelProvider
    {
        private static readonly string BasePath = Path.Combine("Going Medieval_Data", "StreamingAssets");

        public T GetModel<T>()
            where T : IJsonModel
        {
            var attribute = typeof(T).GetCustomAttribute<AssetFileAttribute>();

            if (attribute is null)
            {
                throw new InvalidOperationException("Trying to find a path to the model that doesn't have AssetFileAttribute");
            }

            var path = Path.Combine(BasePath, attribute.Path);

            return Deserialize<T>(path);
        }

        private T Deserialize<T>(string path)
        {
            var json = File.ReadAllText(path);
            
            var result = JsonConvert.DeserializeObject<T>(json);

            if (result is null)
            {
                throw new InvalidOperationException($"Deserialization of '{path}' returned null.");
            }

            return result;
        }
    }
}
