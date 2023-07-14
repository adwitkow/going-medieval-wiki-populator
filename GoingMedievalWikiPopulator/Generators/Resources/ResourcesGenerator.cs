namespace GoingMedievalWikiPopulator.Generators.Resources
{
    internal class ResourcesGenerator : Generator
    {
        private readonly IEnumerable<ISubGenerator> _subGenerators;

        public ResourcesGenerator(
            ProductionGenerator productionGenerator,
            DecayGenerator decayGenerator,
            DescriptionGenerator descriptionGenerator,
            ItemInfoboxGenerator itemInfoboxGenerator)
        {
            _subGenerators = new ISubGenerator[]
            {
                productionGenerator, decayGenerator, descriptionGenerator, itemInfoboxGenerator
            };
        }

        public override string Directory => "Resources";

        protected override IEnumerable<ISubGenerator> SubGenerators => _subGenerators;
    }
}
