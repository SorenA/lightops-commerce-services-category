using LightOps.Commerce.Services.Category.Api.Models;
using LightOps.Commerce.Services.Category.Api.QueryHandlers;
using LightOps.Commerce.Services.Category.Api.Services;
using LightOps.Mapping.Api.Mappers;

namespace LightOps.Commerce.Services.Category.Configuration
{
    public interface ICategoryServiceComponent
    {
        #region Services
        ICategoryServiceComponent OverrideHealthService<T>() where T : IHealthService;
        ICategoryServiceComponent OverrideCategoryService<T>() where T : ICategoryService;
        #endregion Services

        #region Mappers
        ICategoryServiceComponent OverrideProtoCategoryMapperV1<T>() where T : IMapper<ICategory, Proto.Services.Category.V1.ProtoCategory>;
        #endregion Mappers

        #region Query Handlers
        ICategoryServiceComponent OverrideCheckCategoryHealthQueryHandler<T>() where T : ICheckCategoryHealthQueryHandler;

        ICategoryServiceComponent OverrideFetchCategoryByIdQueryHandler<T>() where T : IFetchCategoryByIdQueryHandler;
        ICategoryServiceComponent OverrideFetchCategoriesByIdsQueryHandler<T>() where T : IFetchCategoriesByIdsQueryHandler;

        ICategoryServiceComponent OverrideFetchCategoryByHandleQueryHandler<T>() where T : IFetchCategoryByHandleQueryHandler;
        ICategoryServiceComponent OverrideFetchCategoriesByHandlesQueryHandler<T>() where T : IFetchCategoriesByHandlesQueryHandler;

        ICategoryServiceComponent OverrideFetchCategoriesByParentIdQueryHandler<T>() where T : IFetchCategoriesByParentIdQueryHandler;
        ICategoryServiceComponent OverrideFetchCategoriesByParentIdsQueryHandler<T>() where T : IFetchCategoriesByParentIdsQueryHandler;

        ICategoryServiceComponent OverrideFetchCategoriesByRootQueryHandler<T>() where T : IFetchCategoriesByRootQueryHandler;
        ICategoryServiceComponent OverrideFetchCategoriesBySearchQueryHandler<T>() where T : IFetchCategoriesBySearchQueryHandler;
        #endregion Query Handlers
    }
}