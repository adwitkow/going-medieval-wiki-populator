using GoingMedievalWikiPopulator.JsonModels;

namespace GoingMedievalWikiPopulator
{
    internal static class Extensions
    {
        public static string GetLocalizedName(this ILocalizable localizable)
        {
            return localizable.LocKeys[0].Name;
        }

        public static string GetLocalizedDescription(this ILocalizable localizable)
        {
            return localizable.LocKeys[0].Info;
        }
    }
}
