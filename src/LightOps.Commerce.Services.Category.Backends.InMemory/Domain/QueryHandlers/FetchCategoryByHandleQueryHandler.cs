using System.Linq;
using System.Threading.Tasks;
using LightOps.Commerce.Services.Category.Api.Models;
using LightOps.Commerce.Services.Category.Api.Queries;
using LightOps.Commerce.Services.Category.Api.QueryHandlers;
using LightOps.Commerce.Services.Category.Backends.InMemory.Api.Providers;

namespace LightOps.Commerce.Services.Category.Backends.InMemory.Domain.QueryHandlers
{
    public class FetchCategoryByHandleQueryHandler : IFetchCategoryByHandleQueryHandler
    {
        private readonly IInMemoryCategoryProvider _inMemoryCategoryProvider;

        public FetchCategoryByHandleQueryHandler(IInMemoryCategoryProvider inMemoryCategoryProvider)
        {
            _inMemoryCategoryProvider = inMemoryCategoryProvider;
        }

        public Task<ICategory> HandleAsync(FetchCategoryByHandleQuery query)
        {
            var category = _inMemoryCategoryProvider
                .Categories
                .FirstOrDefault(c => c.Handle == query.Handle);

            return Task.FromResult(category);
        }
    }
}