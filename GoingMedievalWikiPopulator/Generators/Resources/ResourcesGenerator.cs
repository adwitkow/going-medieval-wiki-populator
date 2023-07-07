using GoingMedievalWikiPopulator.JsonModels.Resources;

namespace GoingMedievalWikiPopulator.Generators.Resources
{
    internal class ResourcesGenerator : IGenerator
    {
        private readonly Dictionary<string, Resource> _resources;
        private readonly DecayGenerator _decayGenerator;

        public string Directory => "Resources";

        public ResourcesGenerator(LocalizationProvider locProvider, GameModelProvider modelProvider, DecayGenerator decayGenerator)
        {
            var resourceModel = modelProvider.GetModel<ResourceModel>();
            _resources = ProcessResources(resourceModel);
            _decayGenerator = decayGenerator;
        }

        public GenerationResult[] Generate()
        {
            var results = new List<GenerationResult>();

            foreach (var resource in _resources.Values)
            {
                var path = Path.Combine(resource.Id, "test");
                var result = new GenerationResult(path, new string[] {});
                results.Add(result);
            }

            results.AddRange(_decayGenerator.Generate());

            return results.ToArray();
        }

        private Dictionary<string, Resource> ProcessResources(ResourceModel resourceModel)
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
