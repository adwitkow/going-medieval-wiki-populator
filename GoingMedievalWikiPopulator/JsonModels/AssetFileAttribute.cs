namespace GoingMedievalWikiPopulator.JsonModels
{
    internal class AssetFileAttribute : Attribute
    {
        public AssetFileAttribute(string path)
        {
            this.Path = path;
        }

        public string Path { get; }
    }
}
