using LightOps.Commerce.Services.Category.Api.CommandHandlers;
using LightOps.Commerce.Services.Category.Api.QueryHandlers;

namespace LightOps.Commerce.Services.Category.Configuration
{
    public interface ICategoryServiceComponent
    {
        #region Query Handlers
        ICategoryServiceComponent OverrideCheckCategoryServiceHealthQueryHandler<T>() where T : ICheckCategoryServiceHealthQueryHandler;

        ICategoryServiceComponent OverrideFetchCategoriesByHandlesQueryHandler<T>() where T : IFetchCategoriesByHandlesQueryHandler;
        ICategoryServiceComponent OverrideFetchCategoriesByIdsQueryHandler<T>() where T : IFetchCategoriesByIdsQueryHandler;
        ICategoryServiceComponent OverrideFetchCategoriesBySearchQueryHandler<T>() where T : IFetchCategoriesBySearchQueryHandler;
        #endregion Query Handlers

        #region Command Handlers
        ICategoryServiceComponent OverridePersistCategoryCommandHandler<T>() where T : IPersistCategoryCommandHandler;
        ICategoryServiceComponent OverrideDeleteCategoryCommandHandler<T>() where T : IDeleteCategoryCommandHandler;
        #endregion Command Handlers
    }
}