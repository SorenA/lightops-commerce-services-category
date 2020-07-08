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
        ICategoryServiceComponent OverrideFetchCategoriesByParentIdQueryHandler<T>() where T : IFetchCategoriesByParentIdQueryHandler;
        ICategoryServiceComponent OverrideFetchCategoriesByRootQueryHandler<T>() where T : IFetchCategoriesByRootQueryHandler;
        ICategoryServiceComponent OverrideFetchCategoriesBySearchQueryHandler<T>() where T : IFetchCategoriesBySearchQueryHandler;
        ICategoryServiceComponent OverrideFetchCategoryByHandleQueryHandler<T>() where T : IFetchCategoryByHandleQueryHandler;
        ICategoryServiceComponent OverrideFetchCategoryByIdQueryHandler<T>() where T : IFetchCategoryByIdQueryHandler;
        #endregion Query Handlers
    }
}