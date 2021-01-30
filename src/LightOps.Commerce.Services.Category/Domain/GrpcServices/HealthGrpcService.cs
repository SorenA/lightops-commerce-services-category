using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using LightOps.Commerce.Proto.Grpc.Health;
using LightOps.Commerce.Services.Category.Api.Queries;
using LightOps.CQRS.Api.Services;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;

namespace LightOps.Commerce.Services.Category.Domain.GrpcServices
{
    public class HealthGrpcService : Health.HealthBase
    {
        private readonly ILogger<HealthGrpcService> _logger;
        private readonly IQueryDispatcher _queryDispatcher;

        public HealthGrpcService(
            ILogger<HealthGrpcService> logger,
            IQueryDispatcher queryDispatcher)
        {
            _logger = logger;
            _queryDispatcher = queryDispatcher;
        }

        public override async Task<HealthCheckResponse> Check(HealthCheckRequest request, ServerCallContext context)
        {
            if (string.IsNullOrEmpty(request.Service))
            {
                // Perform overall health-check
                var statusMap = new Dictionary<string, HealthCheckResponse.Types.ServingStatus>
                {
                    // Check all services
                    { "lightops.service.CategoryService", await GetCategoryServiceStatusAsync() },
                };

                return new HealthCheckResponse
                {
                    Status = statusMap.All(x => x.Value == HealthCheckResponse.Types.ServingStatus.Serving)
                        ? HealthCheckResponse.Types.ServingStatus.Serving
                        : HealthCheckResponse.Types.ServingStatus.NotServing,
                };
            }

            var servingStatus = HealthCheckResponse.Types.ServingStatus.Unknown;
            switch (request.Service)
            {
                case "lightops.service.CategoryService":
                    servingStatus = await GetCategoryServiceStatusAsync();
                    break;
                default:
                    throw new RpcException(new Status(StatusCode.NotFound, $"Service {request.Service} not found."));
            }

            return new HealthCheckResponse
            {
                Status = servingStatus,
            };
        }

        private async Task<HealthCheckResponse.Types.ServingStatus> GetCategoryServiceStatusAsync()
        {
            var healthStatus = await _queryDispatcher.DispatchAsync<CheckCategoryServiceHealthQuery, HealthStatus>(new CheckCategoryServiceHealthQuery());

            return healthStatus == HealthStatus.Healthy
                ? HealthCheckResponse.Types.ServingStatus.Serving
                : HealthCheckResponse.Types.ServingStatus.NotServing;
        }
    }
}
