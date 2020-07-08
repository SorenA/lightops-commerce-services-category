using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LightOps.Commerce.Services.Category.Api.Models;
using LightOps.Commerce.Services.Category.Api.Queries;
using LightOps.Commerce.Services.Category.Api.QueryHandlers;
using LightOps.Commerce.Services.Category.Backends.InMemory.Api.Providers;

namespace LightOps.Commerce.Services.Category.Backends.InMemory.Domain.QueryHandlers
{
    public class FetchCategoriesByRootQueryHandler : IFetchCategoriesByRootQueryHandler
    {
        private readonly IInMemoryCategoryProvider _inMemoryCategoryProvider;

        public FetchCategoriesByRootQueryHandler(IInMemoryCategoryProvider inMemoryCategoryProvider)
        {
            _inMemoryCategoryProvider = inMemoryCategoryProvider;
        }

        public Task<IList<ICategory>> HandleAsync(FetchCategoriesByRootQuery query)
        {
            var categories = _inMemoryCategoryProvider
                .Categories
                .Where(c => c.ParentCategoryId == null)
                .ToList();

            return Task.FromResult<IList<ICategory>>(categories);
        }
    }
}