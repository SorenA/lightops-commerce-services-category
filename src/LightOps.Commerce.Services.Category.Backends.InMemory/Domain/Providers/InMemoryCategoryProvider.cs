using System.Collections.Generic;
using LightOps.Commerce.Services.Category.Backends.InMemory.Api.Providers;

namespace LightOps.Commerce.Services.Category.Backends.InMemory.Domain.Providers
{
    public class InMemoryCategoryProvider : IInMemoryCategoryProvider
    {
        public IList<Proto.Types.Category> Categories { get; internal set; } = new List<Proto.Types.Category>();
    }
}