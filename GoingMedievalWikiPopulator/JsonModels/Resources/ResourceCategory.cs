namespace GoingMedievalWikiPopulator.JsonModels.Resources
{
    [Flags]
    public enum ResourceCategory
    {
        None = 0,
        CtgVegetable = 1,
        CtgFruit = 2,
        CtgMeal = 4,
        CtgEdible = 8,
        CtgMeat = 16,
        CtgAlcoholMat = 32,
        CtgRawMeat = 64,
        CtgCookingMat = 128,
        CtgClothMat = 256,
        CtgWaste = 512,
        CtgBuildMat = 1024,
        CtgMetal = 2048,
        CtgRawMat = 4096,
        CtgHumanCarcass = 8192,
        CtgLeatherMat = 16384,
        CtgTextileMat = 32768,
        CtgItem = 65536,
        CtgFuel = 131072,
        CtgDestilMat = 262144,
        CtgPresMat = 524288,
        CtgDesinf = 1048576,
        CtgResearch = 2097152,
        CtgCarcass = 4194304,
        CtgHealPack = 8388608,
        CtgAlcohol = 16777216,
        CtgStructure = 33554432,
        CtgSeeds = 67108864,
        CtgCandleFuel = 134217728,
        CtgFodder = 268435456,
        CtgAll = -1
    }
}
