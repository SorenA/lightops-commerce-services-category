using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LightOps.Commerce.Services.Category.Api.Models;
using LightOps.Commerce.Services.Category.Api.Queries;
using LightOps.Commerce.Services.Category.Api.QueryHandlers;
using LightOps.Commerce.Services.Category.Backends.InMemory.Api.Providers;

namespace LightOps.Commerce.Services.Category.Backends.InMemory.Domain.QueryHandlers
{
    public class FetchCategoriesBySearchQueryHandler : IFetchCategoriesBySearchQueryHandler
    {
        private readonly IInMemoryCategoryProvider _inMemoryCategoryProvider;

        public FetchCategoriesBySearchQueryHandler(IInMemoryCategoryProvider inMemoryCategoryProvider)
        {
            _inMemoryCategoryProvider = inMemoryCategoryProvider;
        }

        public Task<IList<ICategory>> HandleAsync(FetchCategoriesBySearchQuery query)
        {
            var searchTerm = query.SearchTerm.ToLowerInvariant();

            var categoryQuery = _inMemoryCategoryProvider.Categories
                .AsQueryable();

            if (query.SearchTerm != "*")
            {
                categoryQuery = categoryQuery
                    .Where(c =>
                        (string.IsNullOrWhiteSpace(c.Id) || c.Id.ToLowerInvariant().Contains(searchTerm))
                        || (string.IsNullOrWhiteSpace(c.Title) || c.Title.ToLowerInvariant().Contains(searchTerm))
                        || (string.IsNullOrWhiteSpace(c.Description) || c.Description.ToLowerInvariant().Contains(searchTerm)));
            }

            return Task.FromResult<IList<ICategory>>(categoryQuery.ToList());
        }
    }
}