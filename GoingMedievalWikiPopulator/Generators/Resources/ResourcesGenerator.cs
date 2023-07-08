namespace GoingMedievalWikiPopulator.Generators.Resources
{
    internal class ResourcesGenerator : Generator
    {
        private readonly IEnumerable<ISubGenerator> _subGenerators;

        public ResourcesGenerator(DecayGenerator decayGenerator)
        {
            _subGenerators = new[] { decayGenerator };
        }

        public override string Directory => "Resources";

        protected override IEnumerable<ISubGenerator> SubGenerators => _subGenerators;
    }
}
