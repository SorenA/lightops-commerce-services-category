using System.Collections.Generic;
using LightOps.Commerce.Services.Category.Api.Models;

namespace LightOps.Commerce.Services.Category.Backends.InMemory.Api.Providers
{
    public interface IInMemoryCategoryProvider
    {
        IList<ICategory> Categories { get; }
    }
}