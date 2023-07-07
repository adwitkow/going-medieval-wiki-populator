namespace GoingMedievalWikiPopulator.Generators.Effectors.Moods
{
    internal struct Mood
    {
        public required string Name { get; init; }

        public required int Effect { get; init; }

        public float? Duration { get; init; }

        public string? Description { get; init; }

        public string? Category { get; init; }
    }
}
