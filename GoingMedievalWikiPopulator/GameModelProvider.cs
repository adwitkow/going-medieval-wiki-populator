using System.Reflection;
using GoingMedievalWikiPopulator.JsonModels;
using Newtonsoft.Json;

namespace GoingMedievalWikiPopulator
{
    internal class GameModelProvider
    {
        private static readonly string BasePath = Path.Combine("Going Medieval_Data", "StreamingAssets");

        private readonly Dictionary<Type, object> _processedModelCache;

        public GameModelProvider()
        {
            _processedModelCache = new Dictionary<Type, object>();
        }

        public Dictionary<string, T> GetModels<TModel, T>()
            where TModel : IJsonModel<T>
            where T : IIdentifiable
        {
            if (_processedModelCache.TryGetValue(typeof(T), out var dictionary))
            {
                return (Dictionary<string, T>)dictionary;
            }

            var model = GetModel<TModel>();
            return ProcessAndCacheModel(model, model => model.Items);
        }

        private static T GetModel<T>()
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

        private Dictionary<string, T> ProcessAndCacheModel<TModel, T>(TModel model, Func<TModel, IReadOnlyList<T>> selector)
            where T : IIdentifiable
        {
            var results = new Dictionary<string, T>();

            foreach (var resource in selector.Invoke(model))
            {
                results.Add(resource.Id, resource);
            }

            _processedModelCache.Add(typeof(TModel), results);

            return results;
        }
    }
}
