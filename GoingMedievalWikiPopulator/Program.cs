// See https://aka.ms/new-console-template for more information
using GoingMedievalWikiPopulator;
using GoingMedievalWikiPopulator.Generators.Effectors;
using GoingMedievalWikiPopulator.Generators.Resources;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddScoped<LocalizationProvider>();
builder.Services.AddScoped<GameModelProvider>();
builder.Services.AddTransient<DecayGenerator>();
builder.Services.AddTransient<MoodTableGenerator>();
builder.Services.AddTransient<ResourcesGenerator>();

var host = builder.Build();

using var serviceScope = host.Services.CreateScope();
var provider = serviceScope.ServiceProvider;

var generators = new[]
{
    typeof(MoodTableGenerator),
    typeof(ResourcesGenerator)
};

Console.WriteLine("Please choose which of the following generators you wish to use:");
for (int i = 1; i <= generators.Length; i++)
{
    Console.WriteLine($"[{i}] {generators[i - 1].Name}");
}
Console.WriteLine();

Console.Write("> ");
var response = (int)char.GetNumericValue(Console.ReadKey().KeyChar);

Console.WriteLine();

if (response < 1 || response > generators.Length)
{
    return 1;
}

var generatorType = generators[response - 1];

var generator = (IGenerator)provider.GetRequiredService(generatorType);

ClearOutputDirectory(generator.Directory);

var results = generator.Generate();

foreach (var result in results)
{
    var directoryPath = Path.Combine("Output", generator.Directory);
    var resultDirectory = Path.GetDirectoryName(result.FileName);

    string resultPath;
    if (!string.IsNullOrEmpty(resultDirectory))
    {
        resultPath = Path.Combine(directoryPath, resultDirectory);
        Directory.CreateDirectory(resultPath);
    }
    else
    {
        resultPath = directoryPath;
    }

    var fileName = Path.GetFileName(result.FileName);
    var path = Path.Combine(resultPath, $"{fileName}.txt");
    File.WriteAllLines(path, result.Lines);

    Console.WriteLine($"Saved {directoryPath}\\{result.FileName}.txt");
}

Console.WriteLine("Finished.");

Console.ReadLine();

return 0;

static void ClearOutputDirectory(string directory)
{
    var path = Path.Combine("Output", directory);
    if (Directory.Exists(path))
    {
        DirectoryInfo di = new DirectoryInfo(path);

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
        Directory.CreateDirectory(path);
    }
}