using Newtonsoft.Json;

namespace GoingMedievalWikiPopulator
{
    internal class LocalizationProvider
    {
        private const string LocalizationFileName = "Localization.json";

        private Dictionary<string, string> _repository = default!;

        public void Load()
        {
            var json = File.ReadAllText(LocalizationFileName);
            _repository = JsonConvert.DeserializeObject<Dictionary<string, string>>(json)!;
        }

        public bool TryLocalize(string? stringId, out string? localized)
        {
            if (string.IsNullOrEmpty(stringId))
            {
                localized = null;
                return false;
            }

            return _repository.TryGetValue(stringId.ToLower(), out localized);
        }
    }
}
