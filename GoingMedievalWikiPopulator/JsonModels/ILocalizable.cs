namespace GoingMedievalWikiPopulator.JsonModels
{
    internal interface ILocalizable
    {
        public IReadOnlyList<LocKey> LocKeys { get; }
    }
}
