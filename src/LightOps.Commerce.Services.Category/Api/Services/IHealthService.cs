using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace LightOps.Commerce.Services.Category.Api.Services
{
    public interface IHealthService
    {
        Task<HealthStatus> CheckCategory();
    }
}