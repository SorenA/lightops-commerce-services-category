using System.Collections.Generic;

namespace LightOps.Commerce.Services.Category.Backends.InMemory.Api.Providers
{
    public interface IInMemoryCategoryProvider
    {
        IList<Proto.Types.Category> Categories { get; }
    }
}