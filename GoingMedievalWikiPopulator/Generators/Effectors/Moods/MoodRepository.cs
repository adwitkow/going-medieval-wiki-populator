using GoingMedievalWikiPopulator.JsonModels.Moods;

namespace GoingMedievalWikiPopulator.Generators.Effectors.Moods
{
    internal class MoodRepository
    {
        private readonly Dictionary<string, ICollection<Mood>> _moods;
        private readonly LocalizationProvider _localizationProvider;

        public MoodRepository(LocalizationProvider locProvider)
        {
            _moods = new Dictionary<string, ICollection<Mood>>();
            _localizationProvider = locProvider;
        }

        public void Load(IEnumerable<Effector> effectors)
        {
            foreach (var effector in effectors)
            {
                var mood = ExtractMood(effector);
                if (!default(Mood).Equals(mood))
                {
                    CacheMood(mood);
                }
            }
        }

        public IEnumerable<Mood> GetByCategory(string category)
        {
            return _moods[category];
        }

        public IEnumerable<string> GetCategories()
        {
            return _moods.Keys;
        }

        private void CacheMood(Mood mood)
        {
            string moodCategory;
            if (mood.Category is null)
            {
                moodCategory = "No category";
            }
            else
            {
                moodCategory = mood.Category;
            }

            var categoryExists = _moods.TryGetValue(moodCategory, out var category);
            if (categoryExists)
            {
                category!.Add(mood);
            }
            else
            {
                category = new List<Mood>()
                {
                    mood
                };

                _moods.Add(moodCategory, category);
            }
        }

        private Mood ExtractMood(Effector effector)
        {
            if (effector.LocKeys is null || !effector.LocKeys.Any() || effector.Effects is null)
            {
                return default;
            }

            var locKey = effector.LocKeys[0];
            var name = locKey.Name;

            if (string.IsNullOrEmpty(name))
            {
                return default;
            }

            var effectValue = GetEffectValue(effector);
            if (effectValue is null)
            {
                return default;
            }

            var canLocalizeName = _localizationProvider.TryLocalize(name, out var localizedName);
            if (!canLocalizeName)
            {
                return default;
            }

            string? localizedInfo = null;
            if (!string.IsNullOrEmpty(locKey.Info))
            {
                var canLocalizeInfo = _localizationProvider.TryLocalize(locKey.Info, out localizedInfo);

                if (canLocalizeInfo)
                {
                    localizedInfo = localizedInfo!.Trim();
                    localizedInfo = localizedInfo.Replace("<style=AltColor>", "").Replace("</style>", "");
                }
            }

            return new Mood()
            {
                Name = localizedName!.Trim(),
                Effect = effectValue.Value,
                Duration = effector.Duration,
                Description = localizedInfo,
                Category = effector.Category,
            };
        }

        private static int? GetEffectValue(Effector effector)
        {
            var rawEffectValue = effector.Effects.Where(effect => effect.Type == EffectorType.MoodModify)
                .Select(effect => effect.Parameters
                    .FirstOrDefault(param => param.Key == "BaseValue")?.Value)
                .FirstOrDefault();

            if (string.IsNullOrEmpty(rawEffectValue))
            {
                return null;
            }

            var isNumber = int.TryParse(rawEffectValue, out var value);
            return isNumber ? value : null;
        }
    }
}
