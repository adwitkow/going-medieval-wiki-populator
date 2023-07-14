using GoingMedievalWikiPopulator.JsonModels.DecayModifiers;
using GoingMedievalWikiPopulator.JsonModels.Resources;

namespace GoingMedievalWikiPopulator.Generators.Resources
{
    internal class DecayGenerator : ISubGenerator
    {
        private const string FermentationSection = "Fermentation";
        private const string DecompositionSection = "Decomposition";
        private const string RotSection = "Rot";

        private static readonly Dictionary<string, string> Weathers = new()
        {
            { "rain", "Rain" },
            { "snow", "Snow" },
            { "game_event_thunderstorm", "Thunderstorm" },
            { "game_event_hailstorm", "Hailstorm" },
        };

        private readonly LocalizationProvider _localizationProvider;

        private readonly Dictionary<string, DecayModifier> _decayModifiers;
        private readonly Dictionary<string, Resource> _resources;

        private readonly List<string> _lines;

        public DecayGenerator(LocalizationProvider locProvider, GameModelProvider modelProvider)
        {
            _localizationProvider = locProvider;

            _resources = modelProvider.GetModels<ResourceModel, Resource>();
            _decayModifiers = modelProvider.GetModels<DecayModifierModel, DecayModifier>();

            _lines = new List<string>();
        }

        public Task<IEnumerable<GenerationResult>> Generate()
        {
            var results = new List<GenerationResult>();

            foreach (var resource in _resources.Values)
            {
                _lines.Clear();
                _lines.Add("== Decay ==");

                var fermentModifierId = resource.FermentModifiersId;
                var decomposeModifierId = resource.DecomposeModifiersId;
                var rotModifierId = resource.RotModifiersId;

                var cantFerment = string.IsNullOrEmpty(fermentModifierId);
                var cantDecompose = string.IsNullOrEmpty(decomposeModifierId);
                var cantRot = string.IsNullOrEmpty(rotModifierId);

                if (cantFerment && cantDecompose && cantRot)
                {
                    _lines.Add("This item does not decay.");
                }
                else
                {
                    AddFermentationSubsection(resource, fermentModifierId);
                    AddDecompositionSubsection(decomposeModifierId);
                    AddRotSubsection(resource, rotModifierId);
                }

                string line = _lines.Last();
                while (string.IsNullOrWhiteSpace(line))
                {
                    _lines.RemoveAt(_lines.Count - 1);
                    line = _lines.Last();
                }

                var name = _localizationProvider.Localize(resource.LocKeys[0].Name).Trim();
                var path = Path.Combine(name, "decay");
                results.Add(new GenerationResult(path, _lines.ToArray()));
            }

            return Task.FromResult(results.AsEnumerable());
        }

        private void AddRotSubsection(Resource resource, string rotModifierId)
        {
            if (string.IsNullOrEmpty(rotModifierId))
            {
                _lines.Add($"=== {RotSection} ===");
                _lines.Add("This item does not rot.");
                _lines.Add(string.Empty);
            }
            else
            {
                string? rotProduct = null;
                if (!string.IsNullOrEmpty(resource.RottenId))
                {
                    var rotProductResource = _resources[resource.RottenId];
                    rotProduct = _localizationProvider.Localize(rotProductResource.LocKeys[0].Name);
                }
                var rotModifier = _decayModifiers[rotModifierId];
                AddDecaySubsection(rotModifier, RotSection, "Temperature Decay Table", rotProduct);
            }
        }

        private void AddDecompositionSubsection(string decomposeModifierId)
        {
            if (string.IsNullOrEmpty(decomposeModifierId))
            {
                _lines.Add($"=== {DecompositionSection} ===");
                _lines.Add("This item does not decompose.");
                _lines.Add(string.Empty);
            }
            else
            {
                var decomposeModifier = _decayModifiers[decomposeModifierId];
                AddDecaySubsection(decomposeModifier, DecompositionSection, "Temperature Decay Table", null);
            }
        }

        private void AddFermentationSubsection(Resource resource, string fermentModifierId)
        {
            if (string.IsNullOrEmpty(fermentModifierId))
            {
                _lines.Add($"=== {FermentationSection} ===");
                _lines.Add("This item does not ferment.");
                _lines.Add(string.Empty);
            }
            else
            {
                string? fermentProduct = null;
                if (!string.IsNullOrEmpty(resource.FermentedId))
                {
                    var fermentProductResource = _resources[resource.FermentedId];
                    fermentProduct = _localizationProvider.Localize(fermentProductResource.LocKeys[0].Name);
                }
                var fermentModifier = _decayModifiers[fermentModifierId];
                AddDecaySubsection(fermentModifier, FermentationSection, "Fermentation Table", fermentProduct);
            }
        }

        private void AddDecaySubsection(DecayModifier modifier, string sectionName, string temperatureTemplate, string? product)
        {
            _lines.Add($"=== {sectionName} ===");
            if (!string.IsNullOrEmpty(product))
            {
                _lines.Add($"Produces [[{product}]].");
                _lines.Add(string.Empty);
            }

            if (modifier.TemperatureCoefficients.Any(temp => temp != 0))
            {
                _lines.Add($"{{{{{temperatureTemplate}");
                foreach (var temp in modifier.TemperatureCoefficients)
                {
                    _lines.Add($"|{temp:F2}");
                }
                _lines.Add("}}");
            }
            else
            {
                _lines.Add($"{{{{{temperatureTemplate}}}}}");
            }

            var groundDecay = modifier.GroundCoefficient;
            if (groundDecay.HasValue && groundDecay != 0)
            {
                var ground = groundDecay.Value.ToString("F2");
                _lines.Add($"{{{{Ground Decay Table | Ground = {ground}}}}}");
            }
            else
            {
                _lines.Add("{{Ground Decay Table}}");
            }

            var weatherDecay = modifier.WeatherModifiers;
            if (weatherDecay.Values.Any(value => value != 0))
            {
                _lines.Add("{{Weather Decay Table");
                for (int i = 0; i < weatherDecay.Keys.Count; i++)
                {
                    var key = Weathers[weatherDecay.Keys[i]];
                    var value = weatherDecay.Values[i];

                    _lines.Add($"| {key} = {value:F2}");
                }
                _lines.Add("}}");
            }
            else
            {
                _lines.Add("{{Weather Decay Table}}");
            }

            _lines.Add(string.Empty);
            _lines.Add("{{Clear|left}}");
            _lines.Add(string.Empty);
        }
    }
}
