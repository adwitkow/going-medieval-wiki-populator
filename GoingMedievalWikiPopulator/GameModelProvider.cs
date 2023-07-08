using System.Reflection;
using GoingMedievalWikiPopulator.JsonModels;
using Newtonsoft.Json;

namespace GoingMedievalWikiPopulator
{
    internal class GameModelProvider
    {
        private static readonly string BasePath = Path.Combine("Going Medieval_Data", "StreamingAssets");

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "This will class will be a cached singleton service in the future")]
        public T GetModel<T>()
            where T : IJsonModel
        {
            var attribute = typeof(T).GetCustomAttribute<AssetFileAttribute>()
                ?? throw new InvalidOperationException("Trying to find a path to the model that doesn't have AssetFileAttribute");

            var path = Path.Combine(BasePath, attribute.Path);

            return Deserialize<T>(path);
        }

        private static T Deserialize<T>(string path)
        {
            var json = File.ReadAllText(path);
            
            var result = JsonConvert.DeserializeObject<T>(json);

            return result is null ? throw new InvalidOperationException($"Deserialization of '{path}' returned null.") : result;
        }
    }
}
