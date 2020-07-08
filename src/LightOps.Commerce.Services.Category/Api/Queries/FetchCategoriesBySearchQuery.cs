using LightOps.CQRS.Api.Queries;

namespace LightOps.Commerce.Services.Category.Api.Queries
{
    public class FetchCategoriesBySearchQuery : IQuery
    {
        public string SearchTerm { get; set; }
    }
}