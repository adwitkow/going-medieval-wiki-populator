using GoingMedievalWikiPopulator.JsonModels.DecayModifiers;
using GoingMedievalWikiPopulator.JsonModels.Resources;

namespace GoingMedievalWikiPopulator.Generators.Resources
{
    internal class DecayGenerator : ISubGenerator
    {
        private const string FermentationSection = "Fermentation";
        private const string DecompositionSection = "Decomposition";
        private const string RotSection = "Rot";

        private static readonly Dictionary<string, string> _weathers = new Dictionary<string, string>()
        {
            { "rain", "Rain" },
            { "snow", "Snow" },
            { "game_event_thunderstorm", "Thunderstorm" },
            { "game_event_hailstorm", "Hailstorm" },
        };

        private readonly LocalizationProvider _localizationProvider;

        private readonly Dictionary<string, DecayModifier> _decayModifiers;
        private readonly Dictionary<string, Resource> _resources;

        public DecayGenerator(LocalizationProvider locProvider, GameModelProvider modelProvider)
        {
            _localizationProvider = locProvider;

            var resourceModel = modelProvider.GetModel<ResourceModel>();
            var decayModel = modelProvider.GetModel<DecayModifierModel>();
            _resources = ProcessResources(resourceModel);
            _decayModifiers = ProcessDecayModel(decayModel);
        }

        public IEnumerable<GenerationResult> Generate()
        {
            var results = new List<GenerationResult>();

            foreach (var resource in _resources.Values)
            {
                var lines = new List<string>
                {
                    "== Decay =="
                };

                var fermentModifierId = resource.FermentModifiersId;
                var decomposeModifierId = resource.DecomposeModifiersId;
                var rotModifierId = resource.RotModifiersId;

                var cantFerment = string.IsNullOrEmpty(fermentModifierId);
                var cantDecompose = string.IsNullOrEmpty(decomposeModifierId);
                var cantRot = string.IsNullOrEmpty(rotModifierId);

                if (cantFerment && cantDecompose && cantRot)
                {
                    lines.Add("This item does not decay.");
                }
                else
                {
                    AddFermentationSubsection(resource, lines, fermentModifierId);
                    AddDecompositionSubsection(lines, decomposeModifierId);
                    AddRotSubsection(resource, lines, rotModifierId);
                }

                var path = Path.Combine(resource.Id, "decay");
                results.Add(new GenerationResult(path, lines.ToArray()));
            }

            return results.ToArray();
        }

        private void AddRotSubsection(Resource resource, List<string> lines, string rotModifierId)
        {
            if (string.IsNullOrEmpty(rotModifierId))
            {
                lines.Add($"=== {RotSection} ===");
                lines.Add("This item does not rot.");
                lines.Add(string.Empty);
            }
            else
            {
                string? rotProduct = null;
                if (!string.IsNullOrEmpty(resource.RottenId))
                {
                    var rotProductResource = _resources[resource.RottenId];
                    rotProduct = Localize(rotProductResource.LocKeys[0].Name);
                }
                var rotModifier = _decayModifiers[rotModifierId];
                AddDecaySubsection(lines, rotModifier, RotSection, "Temperature Decay Table", rotProduct);
            }
        }

        private void AddDecompositionSubsection(List<string> lines, string decomposeModifierId)
        {
            if (string.IsNullOrEmpty(decomposeModifierId))
            {
                lines.Add($"=== {DecompositionSection} ===");
                lines.Add("This item does not decompose.");
                lines.Add(string.Empty);
            }
            else
            {
                var decomposeModifier = _decayModifiers[decomposeModifierId];
                AddDecaySubsection(lines, decomposeModifier, DecompositionSection, "Temperature Decay Table", null);
            }
        }

        private void AddFermentationSubsection(Resource resource, List<string> lines, string fermentModifierId)
        {
            if (string.IsNullOrEmpty(fermentModifierId))
            {
                lines.Add($"=== {FermentationSection} ===");
                lines.Add("This item does not ferment.");
                lines.Add(string.Empty);
            }
            else
            {
                string? fermentProduct = null;
                if (!string.IsNullOrEmpty(resource.FermentedId))
                {
                    var fermentProductResource = _resources[resource.FermentedId];
                    fermentProduct = Localize(fermentProductResource.LocKeys[0].Name);
                }
                var fermentModifier = _decayModifiers[fermentModifierId];
                AddDecaySubsection(lines, fermentModifier, FermentationSection, "Fermentation Table", fermentProduct);
            }
        }

        private void AddDecaySubsection(List<string> lines, DecayModifier modifier, string sectionName, string temperatureTemplate, string? product)
        {
            lines.Add($"=== {sectionName} ===");
            if (!string.IsNullOrEmpty(product))
            {
                lines.Add($"Produces [[{product}]].");
                lines.Add(string.Empty);
            }

            if (modifier.TemperatureCoefficients.Any(temp => temp != 0))
            {
                lines.Add($"{{{{{temperatureTemplate}");
                foreach (var temp in modifier.TemperatureCoefficients)
                {
                    lines.Add($"|{temp:F2}");
                }
                lines.Add("}}");
            }
            else
            {
                lines.Add($"{{{{{temperatureTemplate}}}}}");
            }

            var groundDecay = modifier.GroundCoefficient;
            if (groundDecay.HasValue && groundDecay != 0)
            {
                var ground = groundDecay.Value.ToString("F2");
                lines.Add($"{{{{Ground Decay Table | Ground = {ground}}}}}");
            }
            else
            {
                lines.Add("{{Ground Decay Table}}");
            }

            var weatherDecay = modifier.WeatherModifiers;
            if (weatherDecay.Values.Any(value => value != 0))
            {
                lines.Add("{{Weather Decay Table");
                for (int i = 0; i < weatherDecay.Keys.Count; i++)
                {
                    var key = _weathers[weatherDecay.Keys[i]];
                    var value = weatherDecay.Values[i];

                    lines.Add($"| {key} = {value:F2}");
                }
                lines.Add("}}");
            }
            else
            {
                lines.Add("{{Weather Decay Table}}");
            }

            lines.Add(string.Empty);
            lines.Add("{{Clear|left}}");
            lines.Add(string.Empty);
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

        private Dictionary<string, DecayModifier> ProcessDecayModel(DecayModifierModel model)
        {
            var results = new Dictionary<string, DecayModifier>();

            foreach (var modifier in model.DecayModifiers)
            {
                results.Add(modifier.Id, modifier);
            }

            return results;
        }

        private string Localize(string toLocalize)
        {
            if (_localizationProvider.TryLocalize(toLocalize, out var result))
            {
                return result!;
            }
            else
            {
                return toLocalize;
            }
        }
    }
}
