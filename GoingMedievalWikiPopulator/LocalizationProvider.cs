using Newtonsoft.Json;

namespace GoingMedievalWikiPopulator
{
    internal class LocalizationProvider
    {
        private const string LocalizationFileName = "Localization.json";

        private readonly Dictionary<string, string> _repository;

        public LocalizationProvider()
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

        public string Localize(string stringId)
        {
            return TryLocalize(stringId, out var result) ? result! : stringId;
        }
    }
}
