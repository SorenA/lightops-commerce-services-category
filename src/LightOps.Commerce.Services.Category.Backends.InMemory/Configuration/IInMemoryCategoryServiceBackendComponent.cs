using System.Collections.Generic;
using LightOps.Commerce.Services.Category.Api.Models;
using LightOps.Commerce.Services.Category.Backends.InMemory.Api.Providers;

namespace LightOps.Commerce.Services.Category.Backends.InMemory.Configuration
{
    public interface IInMemoryCategoryServiceBackendComponent
    {
        #region Entities
        IInMemoryCategoryServiceBackendComponent UseCategories(IList<ICategory> categories);
        #endregion Entities

        #region Providers
        IInMemoryCategoryServiceBackendComponent OverrideCategoryProvider<T>() where T : IInMemoryCategoryProvider;
        #endregion Providers
    }
}