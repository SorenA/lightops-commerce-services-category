using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LightOps.Commerce.Services.Category.Api.Models;
using LightOps.Commerce.Services.Category.Api.Queries;
using LightOps.Commerce.Services.Category.Api.QueryHandlers;
using LightOps.Commerce.Services.Category.Backends.InMemory.Api.Providers;

namespace LightOps.Commerce.Services.Category.Backends.InMemory.Domain.QueryHandlers
{
    public class FetchCategoriesByIdsQueryHandler : IFetchCategoriesByIdsQueryHandler
    {
        private readonly IInMemoryCategoryProvider _inMemoryCategoryProvider;

        public FetchCategoriesByIdsQueryHandler(IInMemoryCategoryProvider inMemoryCategoryProvider)
        {
            _inMemoryCategoryProvider = inMemoryCategoryProvider;
        }

        public Task<IList<ICategory>> HandleAsync(FetchCategoriesByIdsQuery query)
        {
            var categories = _inMemoryCategoryProvider
                .Categories
                .Where(c => query.Ids.Contains(c.Id))
                .ToList();

            return Task.FromResult<IList<ICategory>>(categories);
        }
    }
}