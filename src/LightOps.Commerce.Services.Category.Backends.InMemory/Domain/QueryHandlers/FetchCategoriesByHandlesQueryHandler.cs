using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LightOps.Commerce.Services.Category.Api.Queries;
using LightOps.Commerce.Services.Category.Api.QueryHandlers;
using LightOps.Commerce.Services.Category.Backends.InMemory.Api.Providers;

namespace LightOps.Commerce.Services.Category.Backends.InMemory.Domain.QueryHandlers
{
    public class FetchCategoriesByHandlesQueryHandler : IFetchCategoriesByHandlesQueryHandler
    {
        private readonly IInMemoryCategoryProvider _inMemoryCategoryProvider;

        public FetchCategoriesByHandlesQueryHandler(IInMemoryCategoryProvider inMemoryCategoryProvider)
        {
            _inMemoryCategoryProvider = inMemoryCategoryProvider;
        }

        public Task<IList<Proto.Types.Category>> HandleAsync(FetchCategoriesByHandlesQuery query)
        {
            // Match any localized handle
            var categories = _inMemoryCategoryProvider
                .Categories?
                .Where(c => c.Handles
                    .Select(ls => ls.Value)
                    .Intersect(query.Handles)
                    .Any())
                .ToList();

            return Task.FromResult<IList<Proto.Types.Category>>(categories ?? new List<Proto.Types.Category>());
        }
    }
}