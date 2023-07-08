namespace GoingMedievalWikiPopulator.JsonModels
{
    internal interface IJsonModel<out T>
    {
        public IReadOnlyList<T> Items { get; }
    }
}
