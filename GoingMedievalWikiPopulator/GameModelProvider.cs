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
            if (_processedModelCache.TryGetValue(typeof(TModel), out var dictionary))
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

            foreach (var child in selector.Invoke(model))
            {
                if (results.TryGetValue(child.Id, out var duplicate))
                {
                    if (!duplicate.Equals(child))
                    {
                        throw new InvalidOperationException($"Duplicate key: '{child.Id}'");
                    }

                    results[child.Id] = child;
                    continue;
                }

                results.Add(child.Id, child);
            }

            _processedModelCache.Add(typeof(TModel), results);

            return results;
        }
    }
}
