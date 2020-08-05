using LightOps.Commerce.Proto.Types;
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
        ICategoryServiceComponent OverrideCategoryProtoMapper<T>() where T : IMapper<ICategory, CategoryProto>;
        ICategoryServiceComponent OverrideImageProtoMapper<T>() where T : IMapper<IImage, ImageProto>;
        #endregion Mappers

        #region Query Handlers
        ICategoryServiceComponent OverrideCheckCategoryHealthQueryHandler<T>() where T : ICheckCategoryHealthQueryHandler;

        ICategoryServiceComponent OverrideFetchCategoriesByHandlesQueryHandler<T>() where T : IFetchCategoriesByHandlesQueryHandler;
        ICategoryServiceComponent OverrideFetchCategoriesByIdsQueryHandler<T>() where T : IFetchCategoriesByIdsQueryHandler;
        ICategoryServiceComponent OverrideFetchCategoriesBySearchQueryHandler<T>() where T : IFetchCategoriesBySearchQueryHandler;
        #endregion Query Handlers
    }
}