using System.Threading.Tasks;
using LightOps.Commerce.Services.Category.Api.Queries;
using LightOps.Commerce.Services.Category.Api.Services;
using LightOps.CQRS.Api.Services;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace LightOps.Commerce.Services.Category.Domain.Services
{
    public class HealthService : IHealthService
    {
        private readonly IQueryDispatcher _queryDispatcher;

        public HealthService(IQueryDispatcher queryDispatcher)
        {
            _queryDispatcher = queryDispatcher;
        }

        public Task<HealthStatus> CheckCategory()
        {
            return _queryDispatcher.DispatchAsync<CheckCategoryHealthQuery, HealthStatus>(new CheckCategoryHealthQuery());
        }
    }
}