namespace GoingMedievalWikiPopulator
{
    internal interface IGenerator
    {
        public string Directory { get; }

        public Task<GenerationResult[]> Generate();
    }
}
