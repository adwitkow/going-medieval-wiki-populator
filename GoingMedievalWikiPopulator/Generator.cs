namespace GoingMedievalWikiPopulator
{
    internal abstract class Generator : IGenerator
    {
        public abstract string Directory { get; }

        protected abstract IEnumerable<ISubGenerator> SubGenerators { get; }

        public async Task<GenerationResult[]> Generate()
        {
            var results = new List<GenerationResult>();

            if (SubGenerators is not null)
            {
                foreach (var subGenerator in SubGenerators)
                {
                    results.AddRange(await subGenerator.Generate());
                }
            }

            return results.ToArray();
        }
    }
}
