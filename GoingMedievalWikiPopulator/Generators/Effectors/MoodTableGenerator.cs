using Humanizer;
using GoingMedievalWikiPopulator.JsonModels.Moods;
using GoingMedievalWikiPopulator.Generators.Effectors.Moods;

namespace GoingMedievalWikiPopulator.Generators.Effectors
{
    internal class MoodTableGenerator : IGenerator
    {
        private readonly LocalizationProvider _localizationProvider;

        private readonly ICollection<string> _lines;
        private readonly EffectorModel _effectorModel;

        public MoodTableGenerator(LocalizationProvider localizationProvider, GameModelProvider modelProvider)
        {
            _lines = new List<string>();
            _localizationProvider = localizationProvider;

            _effectorModel = modelProvider.GetModel<EffectorModel>();
        }

        public string Directory => "Mood";

        public GenerationResult[] Generate()
        {
            GenerateTable();
            return new[] { new GenerationResult("Table", _lines.ToArray()) };
        }

        public void GenerateTable()
        {
            _lines.Clear();

            var moodRepository = new MoodRepository(_localizationProvider);
            moodRepository.Load(_effectorModel);

            _lines.Add("== Moods ==");
            _lines.Add("The following are all mood effects available in the game. Since they were ripped straight from a data file (categories included), there may be some inconsistencies or mistakes in spelling that may be marked with a Sic! or corrected/reorganized.");
            _lines.Add(string.Empty);

            var categories = moodRepository.GetCategories().ToList();
            categories.Remove("No category");

            var noCategoryMoods = moodRepository.GetByCategory("No category")
                    .OrderByDescending(mood => mood.Effect);

            CreateCategorySection("No category", noCategoryMoods);
            foreach (var category in categories)
            {
                var sortedMoods = moodRepository.GetByCategory(category)
                    .OrderByDescending(mood => mood.Effect);

                CreateCategorySection(category, sortedMoods);
            }
        }

        private void CreateCategorySection(string category, IEnumerable<Mood> moods)
        {
            var includesDuration = moods.Any(mood => mood.Duration.HasValue);
            var includesDescription = moods.Any(mood => !string.IsNullOrEmpty(mood.Description));

            var humanizedCategory = category.Humanize(LetterCasing.Sentence);
            _lines.Add($"=== {humanizedCategory} ===");
            _lines.Add("{| class=\"wikitable\"");
            _lines.Add("! Name");
            _lines.Add("! Effect");

            if (includesDuration)
            {
                _lines.Add("! Duration");
            }

            if (includesDescription)
            {
                _lines.Add("! Description");
            }

            foreach (var mood in moods)
            {
                var formattedEffect = mood.Effect > 0 ? $"+{mood.Effect}" : mood.Effect.ToString();

                _lines.Add("|-");
                _lines.Add($"| {mood.Name}");
                _lines.Add($"| {formattedEffect}");

                if (includesDuration)
                {
                    if (mood.Duration.HasValue)
                    {
                        _lines.Add($"| {mood.Duration} hours");
                    }
                    else
                    {
                        _lines.Add("|");
                    }
                }

                if (includesDescription)
                {
                    _lines.Add($"| {mood.Description}");
                }
            }
            _lines.Add("|}");
            _lines.Add(string.Empty);
        }
    }
}
