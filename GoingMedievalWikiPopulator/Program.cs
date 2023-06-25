﻿// See https://aka.ms/new-console-template for more information
using GoingMedievalWikiPopulator;
using GoingMedievalWikiPopulator.Decay;
using GoingMedievalWikiPopulator.Effectors;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

ClearOutputDirectory();

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddScoped<LocalizationProvider>();
builder.Services.AddScoped<GameModelProvider>();
builder.Services.AddTransient<DecayGenerator>();
builder.Services.AddTransient<MoodTableGenerator>();

var host = builder.Build();

using var serviceScope = host.Services.CreateScope();
var provider = serviceScope.ServiceProvider;

var generators = new[]
{
    typeof(MoodTableGenerator),
    typeof(DecayGenerator)
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
var results = generator.Generate();

foreach (var result in results)
{
    var path = Path.Combine("Output", $"{result.FileName}.txt");
    File.WriteAllLines(path, result.Lines);

    Console.WriteLine($"Saved {result.FileName}.txt");
}

Console.WriteLine("Finished.");

Console.ReadLine();

return 0;

void ClearOutputDirectory()
{
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
}