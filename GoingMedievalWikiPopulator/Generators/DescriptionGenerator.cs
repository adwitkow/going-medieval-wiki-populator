using GoingMedievalWikiPopulator.JsonModels.Resources;

namespace GoingMedievalWikiPopulator.Generators
{
    internal class DescriptionGenerator : ISubGenerator
    {
        private readonly LocalizationProvider _localizationProvider;

        private readonly Dictionary<string, Resource> _resources;
        private readonly List<string> _lines;

        public DescriptionGenerator(LocalizationProvider locProvider, GameModelProvider modelProvider)
        {
            _localizationProvider = locProvider;

            var resourceModel = modelProvider.GetModel<ResourceModel>();
            _resources = ProcessResources(resourceModel);

            _lines = new List<string>();
        }

        public IEnumerable<GenerationResult> Generate()
        {
            var results = new List<GenerationResult>();
            var resourceKeys = _resources.Values.Select(res => res.LocKeys[0]);
            foreach (var key in resourceKeys)
            {
                _lines.Clear();
                var descriptionKey = key.Info;
                var description = _localizationProvider.Localize(descriptionKey);

                _lines.Add($"{{{{Quote2|{description}}}}}");

                var name = _localizationProvider.Localize(key.Name).Trim();
                var path = Path.Combine(name, "description");
                results.Add(new GenerationResult(path, _lines.ToArray()));
            }
            return results;
        }

        private static Dictionary<string, Resource> ProcessResources(ResourceModel resourceModel)
        {
            var results = new Dictionary<string, Resource>();

            foreach (var resource in resourceModel.Resources)
            {
                results.Add(resource.Id, resource);
            }

            return results;
        }
    }
}
