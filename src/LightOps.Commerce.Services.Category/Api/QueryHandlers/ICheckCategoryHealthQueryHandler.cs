using LightOps.Commerce.Services.Category.Api.Queries;
using LightOps.CQRS.Api.Queries;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace LightOps.Commerce.Services.Category.Api.QueryHandlers
{
    public interface ICheckCategoryHealthQueryHandler : IQueryHandler<CheckCategoryHealthQuery, HealthStatus>
    {

    }
}