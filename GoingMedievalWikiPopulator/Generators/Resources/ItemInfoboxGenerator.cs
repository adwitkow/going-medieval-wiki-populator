using GoingMedievalWikiPopulator.JsonModels.Resources;

namespace GoingMedievalWikiPopulator.Generators.Resources
{
    internal class ItemInfoboxGenerator : ISubGenerator
    {
        private readonly LocalizationProvider _localizationProvider;

        private readonly Dictionary<string, Resource> _resources;
        private readonly List<string> _lines;

        public ItemInfoboxGenerator(LocalizationProvider localizationProvider, GameModelProvider gameModelProvider)
        {
            _lines = new List<string>();
            _localizationProvider = localizationProvider;
            _resources = gameModelProvider.GetModels<ResourceModel, Resource>();
        }

        public IEnumerable<GenerationResult> Generate()
        {
            var results = new List<GenerationResult>();

            foreach (var resource in _resources.Values)
            {
                _lines.Clear();

                var name = _localizationProvider.Localize(resource.LocKeys[0].Name).Trim();
                _lines.Add("{{InfoBoxItems");
                _lines.Add($"| name                 ={name}");
                _lines.Add($"| image                ={name}.png");
                _lines.Add($"| Hitpoints            ={resource.Hitpoints}");
                _lines.Add($"| MaxStack             ={resource.StackingLimit}");
                _lines.Add($"| Nutrition            ={resource.Nutrition}");
                _lines.Add($"| Wound                ={resource.Healing}");
                _lines.Add($"| Degradable           =");
                _lines.Add($"| Rots                 =");
                _lines.Add($"| Decomposes           =");
                _lines.Add($"| Wild                 =");
                _lines.Add($"| Grow Crop            =");
                _lines.Add($"| Category             ={GetCategories(resource)}");
                _lines.Add($"| Weight               ={resource.Weight}");
                _lines.Add($"| Thermal Insulation   ={resource.ThermalModelID}");
                _lines.Add($"| Value                ={resource.WealthPoints}");
                _lines.Add($"| Structure Dimensions =");
                _lines.Add($"| Cover                =");
                _lines.Add($"| Room                 =");
                _lines.Add($"| Skill Type           =");
                _lines.Add($"| Skill                =");
                _lines.Add($"| Description          =");
                _lines.Add($"| Technology           =");
                _lines.Add($"| Recipe               =");
                _lines.Add($"| Herbs                =");
                _lines.Add($"| Textiles             =");
                _lines.Add($"| Disinfectants        =");
                _lines.Add($"| Cooking Material     =");
                _lines.Add($"| Leather              =");
                _lines.Add($"| Metal-Qty            =");
                _lines.Add($"| Wood-Qty             =");
                _lines.Add($"| Clay-Qty             =");
                _lines.Add($"| Limestone-Qty        =");
                _lines.Add($"| fuel                 =");
                _lines.Add("}}");

                var path = Path.Combine(name, "infobox");
                results.Add(new GenerationResult(path, _lines.ToArray()));
            }

            return results;
        }

        private string GetCategories(Resource resource)
        {
            var results = new List<string>();
            var allCategories = (ResourceCategory[])Enum.GetValues(typeof(ResourceCategory));
            foreach (var category in allCategories)
            {
                if (resource.Category.HasFlag(category) && !category.Equals(ResourceCategory.None))
                {
                    var key = $"resource_category_name_{category}";
                    var localized = _localizationProvider.Localize(key);
                    results.Add(localized);
                }
            }

            if (results.Any())
            {
                return string.Join(", ", results);
            }
            else
            {
                return "Misc";
            }
        }
    }
}
