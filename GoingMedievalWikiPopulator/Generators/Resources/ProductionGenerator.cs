using System.Xml.Linq;
using GoingMedievalWikiPopulator.JsonModels.Productions;
using GoingMedievalWikiPopulator.JsonModels.Resources;

namespace GoingMedievalWikiPopulator.Generators.Resources
{
    internal class ProductionGenerator : ISubGenerator
    {
        private readonly LocalizationProvider _localizationProvider;
        private readonly Dictionary<string, Resource> _resources;
        private readonly Dictionary<string, Production> _productions;

        private readonly ProductionMapping _mapping;
        private readonly List<string> _lines;

        public ProductionGenerator(LocalizationProvider localizationProvider, GameModelProvider gameModelProvider)
        {
            _resources = gameModelProvider.GetModels<ResourceModel, Resource>();
            _productions = gameModelProvider.GetModels<ProductionModel, Production>();
            _localizationProvider = localizationProvider;

            _mapping = LoadProductions();

            _lines = new List<string>();
        }

        public IEnumerable<GenerationResult> Generate()
        {
            var results = new List<GenerationResult>();

            foreach (var resource in _resources.Values)
            {
                _lines.Clear();

                var name = _localizationProvider.Localize(resource.LocKeys[0].Name);

                var inputs = _mapping.GetInputs(resource.Id);
                var outputs = _mapping.GetOutputs(resource.Id);

                if (!inputs.Any() && !outputs.Any())
                {
                    continue;
                }

                _lines.Add("== Crafting ==");

                if (outputs.Any())
                {
                    _lines.Add("=== Creation ===");
                    foreach (var production in outputs)
                    {
                        var recipes = production.Recipes;

                        if (recipes is not null)
                        {
                            foreach (var recipe in recipes)
                            {
                                _lines.Add($"* {recipe.Key}: {recipe.Value}");
                            }
                        }

                        var customProducts = production.CustomProducts;
                        if (customProducts is not null)
                        {
                            foreach (var customProduct in customProducts)
                            {
                                foreach (var output in customProduct.Outputs)
                                {
                                    if (resource.Id.Equals(output.BlueprintID))
                                    {
                                        _lines.Add($"* {output.BlueprintID}: {output.Amount}");
                                    }
                                }
                            }
                        }
                    }
                }

                if (inputs.Any())
                {
                    _lines.Add("=== Products ===");

                    foreach (var production in inputs)
                    {
                        var produced = production.Produced;

                        if (produced is not null)
                        {
                            foreach (var product in produced)
                            {
                                _lines.Add($"* {product.BlueprintID}: {product.Amount}");
                            }
                        }

                        var customProducts = production.CustomProducts;
                        if (customProducts is not null)
                        {
                            foreach (var customProduct in customProducts)
                            {
                                if (resource.Id.Equals(customProduct.Input))
                                {
                                    foreach (var output in customProduct.Outputs)
                                    {
                                        _lines.Add($"* {output.BlueprintID}: {output.Amount}");
                                    }
                                }
                            }
                        }
                    }
                }

                var path = Path.Combine(name, "production");
                results.Add(new GenerationResult(path, _lines.ToArray()));
            }

            return results;
        }

        private ProductionMapping LoadProductions()
        {
            var mapping = new ProductionMapping();

            foreach (var production in _productions.Values)
            {
                var produced = production.Produced;

                if (produced is not null)
                {
                    foreach (var product in produced)
                    {
                        mapping.AddOutput(product.BlueprintID, production);
                    }
                }

                var recipes = production.Recipes;
                if (recipes is not null)
                {
                    foreach (var recipe in recipes)
                    {
                        if (!int.TryParse(recipe.Key, out _))
                        {
                            // IDC about the category recipes ATM
                            mapping.AddInput(recipe.Key, production);
                        }
                    }
                }

                var customProducts = production.CustomProducts;
                if (customProducts is not null)
                {
                    foreach (var customProduct in customProducts)
                    {
                        mapping.AddInput(customProduct.Input, production);

                        foreach (var output in customProduct.Outputs)
                        {
                            mapping.AddOutput(output.BlueprintID, production);
                        }
                    }
                }
            }

            return mapping;
        }

        private sealed class ProductionMapping
        {
            private readonly Dictionary<string, ICollection<Production>> _inputs;
            private readonly Dictionary<string, ICollection<Production>> _outputs;

            public ProductionMapping()
            {
                _inputs = new Dictionary<string, ICollection<Production>>();
                _outputs = new Dictionary<string, ICollection<Production>>();
            }

            public void AddInput(string name, Production production)
            {
                Add(_inputs, name, production);
            }

            public void AddOutput(string name, Production production)
            {
                Add(_outputs, name, production);
            }

            public IEnumerable<Production> GetInputs(string name)
            {
                return Get(_inputs, name);
            }

            public IEnumerable<Production> GetOutputs(string name)
            {
                return Get(_outputs, name);
            }

            private static IEnumerable<Production> Get(
                Dictionary<string, ICollection<Production>> cache,
                string name)
            {
                var exists = cache.TryGetValue(name, out var result);
                
                return exists ? result! : Enumerable.Empty<Production>();
            }

            private static void Add(
                Dictionary<string, ICollection<Production>> cache,
                string name,
                Production production)
            {
                ICollection<Production> results;
                if (!cache.TryGetValue(name, out results))
                {
                    results = new List<Production>();
                    cache.Add(name, results);
                }

                results.Add(production);
            }
        }
    }
}
