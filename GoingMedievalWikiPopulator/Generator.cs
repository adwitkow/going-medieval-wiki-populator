namespace GoingMedievalWikiPopulator
{
    internal abstract class Generator : IGenerator
    {
        public abstract string Directory { get; }

        protected abstract IEnumerable<ISubGenerator> SubGenerators { get; }

        public GenerationResult[] Generate()
        {
            var results = new List<GenerationResult>();

            if (SubGenerators is not null)
            {
                foreach (var subGenerator in SubGenerators)
                {
                    results.AddRange(subGenerator.Generate());
                }
            }

            return results.ToArray();
        }
    }
}
