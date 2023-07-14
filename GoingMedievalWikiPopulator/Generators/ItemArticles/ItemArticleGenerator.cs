using GoingMedievalWikiPopulator.Generators.Resources;
using GoingMedievalWikiPopulator.JsonModels.Resources;
using WikiClientLibrary.Client;
using WikiClientLibrary.Generators;
using WikiClientLibrary.Sites;

namespace GoingMedievalWikiPopulator.Generators.ItemArticles
{
    internal class ItemArticleGenerator : IGenerator
    {
        private readonly LocalizationProvider _localizationProvider;

        private readonly List<Article> _articles;
        private readonly Dictionary<string, Resource> _resources;

        public ItemArticleGenerator(
            LocalizationProvider localizationProvider,
            GameModelProvider gameModelProvider)
        {
            _articles = new List<Article>();

            _localizationProvider = localizationProvider;
            _resources = gameModelProvider.GetModels<ResourceModel, Resource>();
        }

        public string Directory => "Missing Item articles";

        public async Task<GenerationResult[]> Generate()
        {
            var results = new List<GenerationResult>();

            var client = new WikiClient();
            var site = new WikiSite(client, "https://goingmedieval.fandom.com/api.php");

            await site.Initialization;

            var itemCategories = await FetchSubCategories(site, "Category:Item");
            var resourceCategories = await FetchSubCategories(site, "Category:Resources");

            var allCategories = resourceCategories.Concat(itemCategories).ToList();
            allCategories.Add("Category:Resources");
            allCategories.Add("Category:Item");

            foreach (var category in allCategories)
            {
                var generator = new CategoryMembersGenerator(site)
                {
                    CategoryTitle = category,
                    MemberTypes = CategoryMemberTypes.Page,
                    PaginationSize = 20,
                };

                var pages = await generator.EnumPagesAsync().ToListAsync();

                foreach (var page in pages)
                {
                    _articles.Add(new Article(page.Title, page.Content));
                }
            }

            foreach (var resource in _resources.Values)
            {
                var name = _localizationProvider.Localize(resource.LocKeys[0].Name);

                if (!_articles.Any(article => article.Title.Equals(name)))
                {
                    results.Add(new GenerationResult(name, Array.Empty<string>()));
                }
            }

            return results.ToArray();
        }

        private async Task<IEnumerable<string>> FetchSubCategories(WikiSite site, string category)
        {
            var results = new List<string>();

            var generator = new CategoryMembersGenerator(site)
            {
                CategoryTitle = category,
                MemberTypes = CategoryMemberTypes.Subcategory,
                PaginationSize = 20,
            };

            var subcategories = await generator.EnumPagesAsync().Select(page => page.Title).ToListAsync();
            results.AddRange(subcategories);

            foreach (var subcategory in subcategories)
            {
                results.AddRange(await FetchSubCategories(site, subcategory));
            }

            return results.Distinct();
        }

        private readonly struct Article
        {
            public Article(string title, string content)
            {
                Title = title;
                Content = content;
            }

            public string Title { get; }

            public string Content { get; }

            public override string ToString()
            {
                return Title;
            }
        }
    }
}
