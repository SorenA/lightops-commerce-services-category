using System.Collections.Generic;
using LightOps.Commerce.Services.Category.Api.Models;

namespace LightOps.Commerce.Services.Category.Backends.InMemory.Configuration
{
    public interface IInMemoryCategoryServiceBackendComponent
    {
        #region Entities
        IInMemoryCategoryServiceBackendComponent UseCategories(IList<ICategory> categories);
        #endregion Entities
    }
}