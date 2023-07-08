using GoingMedievalWikiPopulator.JsonModels.Resources;

namespace GoingMedievalWikiPopulator.Generators.Resources
{
    internal class ResourcesGenerator : IGenerator
    {
        private readonly Dictionary<string, Resource> _resources;
        private readonly LocalizationProvider _localizationProvider;
        private readonly DecayGenerator _decayGenerator;

        public string Directory => "Resources";

        public ResourcesGenerator(LocalizationProvider locProvider, GameModelProvider modelProvider, DecayGenerator decayGenerator)
        {
            _localizationProvider = locProvider;
            _decayGenerator = decayGenerator;

            var resourceModel = modelProvider.GetModel<ResourceModel>();
            _resources = ProcessResources(resourceModel);
        }

        public GenerationResult[] Generate()
        {
            var results = new List<GenerationResult>();

            foreach (var resource in _resources.Values)
            {
                var name = _localizationProvider.Localize(resource.LocKeys[0].Name).Trim();
                var path = Path.Combine(name, "test");
                var result = new GenerationResult(path, Array.Empty<string>());
                results.Add(result);
            }

            results.AddRange(_decayGenerator.Generate());

            return results.ToArray();
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
