namespace GoingMedievalWikiPopulator
{
    internal interface ISubGenerator
    {
        public Task<IEnumerable<GenerationResult>> Generate();
    }
}
