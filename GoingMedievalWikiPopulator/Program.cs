// See https://aka.ms/new-console-template for more information
using GoingMedievalWikiPopulator;
using GoingMedievalWikiPopulator.JsonModels.DecayModifiers;
using GoingMedievalWikiPopulator.JsonModels.Moods;
using GoingMedievalWikiPopulator.JsonModels.Resources;
using Newtonsoft.Json;

var localizationProvider = new LocalizationProvider();
localizationProvider.Load();

var effectorModel = Deserialize<EffectorModel>(@"Going Medieval_Data\StreamingAssets\StatsSystem\Effectors.json");
var resourcesModel = Deserialize<ResourceModel>(@"Going Medieval_Data\StreamingAssets\Resources\Resources.json");
var decayModifiersModel = Deserialize<DecayModifierModel>(@"Going Medieval\Going Medieval_Data\StreamingAssets\Resources\DecayModifiers.json");



T Deserialize<T>(string path)
{
    var json = File.ReadAllText(path);

    var result = JsonConvert.DeserializeObject<T>(json);

    if (result is null)
    {
        throw new InvalidOperationException($"Deserialization of '{path}' returned null.");
    }

    return result;
}