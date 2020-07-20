using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LightOps.Commerce.Services.Category.Api.Models;
using LightOps.Commerce.Services.Category.Api.Queries;
using LightOps.Commerce.Services.Category.Api.QueryHandlers;
using LightOps.Commerce.Services.Category.Backends.InMemory.Api.Providers;

namespace LightOps.Commerce.Services.Category.Backends.InMemory.Domain.QueryHandlers
{
    public class FetchCategoriesByParentIdsQueryHandler : IFetchCategoriesByParentIdsQueryHandler
    {
        private readonly IInMemoryCategoryProvider _inMemoryCategoryProvider;

        public FetchCategoriesByParentIdsQueryHandler(IInMemoryCategoryProvider inMemoryCategoryProvider)
        {
            _inMemoryCategoryProvider = inMemoryCategoryProvider;
        }
        
        public Task<IList<ICategory>> HandleAsync(FetchCategoriesByParentIdsQuery query)
        {
            var categories = _inMemoryCategoryProvider
                .Categories
                .Where(c => query.ParentIds.Contains(c.ParentCategoryId))
                .ToList();

            return Task.FromResult<IList<ICategory>>(categories);
        }
    }
}