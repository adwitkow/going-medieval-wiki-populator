// See https://aka.ms/new-console-template for more information
using GoingMedievalWikiPopulator;
using GoingMedievalWikiPopulator.Decay;
using GoingMedievalWikiPopulator.JsonModels.DecayModifiers;
using GoingMedievalWikiPopulator.JsonModels.Moods;
using GoingMedievalWikiPopulator.JsonModels.Resources;
using Newtonsoft.Json;

if (Directory.Exists("Output"))
{
    DirectoryInfo di = new DirectoryInfo("Output");

    foreach (FileInfo file in di.GetFiles())
    {
        file.Delete();
    }
    foreach (DirectoryInfo dir in di.GetDirectories())
    {
        dir.Delete(true);
    }
}
else
{
    Directory.CreateDirectory("Output");
}

var localizationProvider = new LocalizationProvider();
localizationProvider.Load();

var effectorModel = Deserialize<EffectorModel>(@"Going Medieval_Data\StreamingAssets\StatsSystem\Effectors.json");
var resourcesModel = Deserialize<ResourceModel>(@"Going Medieval_Data\StreamingAssets\Resources\Resources.json");
var decayModifiersModel = Deserialize<DecayModifierModel>(@"Going Medieval_Data\StreamingAssets\Resources\DecayModifiers.json");

var decayGenerator = new DecayGenerator(localizationProvider, resourcesModel, decayModifiersModel);
var results = decayGenerator.Generate();

foreach (var result in results)
{
    var path = Path.Combine("Output", $"{result.FileName}.txt");
    File.WriteAllLines(path, result.Lines);

    Console.WriteLine($"Saved {result.FileName}.txt");
}

Console.WriteLine("Finished.");

Console.ReadLine();

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