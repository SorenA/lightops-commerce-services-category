using System.Threading.Tasks;
using LightOps.Commerce.Services.Category.Api.Queries;
using LightOps.Commerce.Services.Category.Api.QueryHandlers;
using LightOps.Commerce.Services.Category.Backends.InMemory.Api.Providers;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace LightOps.Commerce.Services.Category.Backends.InMemory.Domain.QueryHandlers
{
    public class CheckCategoryHealthQueryHandler : ICheckCategoryHealthQueryHandler
    {
        private readonly IInMemoryCategoryProvider _inMemoryCategoryProvider;

        public CheckCategoryHealthQueryHandler(IInMemoryCategoryProvider inMemoryCategoryProvider)
        {
            _inMemoryCategoryProvider = inMemoryCategoryProvider;
        }

        public Task<HealthStatus> HandleAsync(CheckCategoryHealthQuery query)
        {
            return _inMemoryCategoryProvider.Categories != null
                ? Task.FromResult(HealthStatus.Healthy)
                : Task.FromResult(HealthStatus.Unhealthy);
        }
    }
}