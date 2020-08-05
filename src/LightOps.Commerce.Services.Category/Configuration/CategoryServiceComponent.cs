using System.Collections.Generic;
using System.Linq;
using LightOps.Commerce.Proto.Types;
using LightOps.Commerce.Services.Category.Api.Models;
using LightOps.Commerce.Services.Category.Api.Queries;
using LightOps.Commerce.Services.Category.Api.QueryHandlers;
using LightOps.Commerce.Services.Category.Api.QueryResults;
using LightOps.Commerce.Services.Category.Api.Services;
using LightOps.Commerce.Services.Category.Domain.Mappers;
using LightOps.Commerce.Services.Category.Domain.Services;
using LightOps.CQRS.Api.Queries;
using LightOps.DependencyInjection.Api.Configuration;
using LightOps.DependencyInjection.Domain.Configuration;
using LightOps.Mapping.Api.Mappers;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace LightOps.Commerce.Services.Category.Configuration
{
    public class CategoryServiceComponent : IDependencyInjectionComponent, ICategoryServiceComponent
    {
        public string Name => "lightops.commerce.services.category";

        public IReadOnlyList<ServiceRegistration> GetServiceRegistrations()
        {
            return new List<ServiceRegistration>()
                .Union(_services.Values)
                .Union(_mappers.Values)
                .Union(_queryHandlers.Values)
                .ToList();
        }

        #region Services
        internal enum Services
        {
            HealthService,
            CategoryService,
        }

        private readonly Dictionary<Services, ServiceRegistration> _services = new Dictionary<Services, ServiceRegistration>
        {
            [Services.HealthService] = ServiceRegistration.Transient<IHealthService, HealthService>(),
            [Services.CategoryService] = ServiceRegistration.Scoped<ICategoryService, CategoryService>(),
        };

        public ICategoryServiceComponent OverrideHealthService<T>()
            where T : IHealthService
        {
            _services[Services.HealthService].ImplementationType = typeof(T);
            return this;
        }

        public ICategoryServiceComponent OverrideCategoryService<T>()
            where T : ICategoryService
        {
            _services[Services.CategoryService].ImplementationType = typeof(T);
            return this;
        }
        #endregion Services

        #region Mappers
        internal enum Mappers
        {
            CategoryProtoMapper,
            ImageProtoMapper,
        }

        private readonly Dictionary<Mappers, ServiceRegistration> _mappers = new Dictionary<Mappers, ServiceRegistration>
        {
            [Mappers.CategoryProtoMapper] = ServiceRegistration.Transient<IMapper<ICategory, CategoryProto>, CategoryProtoMapper>(),
            [Mappers.ImageProtoMapper] = ServiceRegistration.Transient<IMapper<IImage, ImageProto>, ImageProtoMapper>(),
        };

        public ICategoryServiceComponent OverrideCategoryProtoMapper<T>() where T : IMapper<ICategory, CategoryProto>
        {
            _mappers[Mappers.CategoryProtoMapper].ImplementationType = typeof(T);
            return this;
        }

        public ICategoryServiceComponent OverrideImageProtoMapper<T>() where T : IMapper<IImage, ImageProto>
        {
            _mappers[Mappers.ImageProtoMapper].ImplementationType = typeof(T);
            return this;
        }
        #endregion Mappers

        #region Query Handlers
        internal enum QueryHandlers
        {
            CheckCategoryHealthQueryHandler,

            FetchCategoriesByHandlesQueryHandler,
            FetchCategoriesByIdsQueryHandler,
            FetchCategoriesBySearchQueryHandler,
        }

        private readonly Dictionary<QueryHandlers, ServiceRegistration> _queryHandlers = new Dictionary<QueryHandlers, ServiceRegistration>
        {
            [QueryHandlers.CheckCategoryHealthQueryHandler] = ServiceRegistration.Transient<IQueryHandler<CheckCategoryHealthQuery, HealthStatus>>(),

            [QueryHandlers.FetchCategoriesByHandlesQueryHandler] = ServiceRegistration.Transient<IQueryHandler<FetchCategoriesByHandlesQuery, IList<ICategory>>>(),
            [QueryHandlers.FetchCategoriesByIdsQueryHandler] = ServiceRegistration.Transient<IQueryHandler<FetchCategoriesByIdsQuery, IList<ICategory>>>(),
            [QueryHandlers.FetchCategoriesBySearchQueryHandler] = ServiceRegistration.Transient<IQueryHandler<FetchCategoriesBySearchQuery, SearchResult<ICategory>>>(),
        };

        public ICategoryServiceComponent OverrideCheckCategoryHealthQueryHandler<T>() where T : ICheckCategoryHealthQueryHandler
        {
            _queryHandlers[QueryHandlers.CheckCategoryHealthQueryHandler].ImplementationType = typeof(T);
            return this;
        }

        public ICategoryServiceComponent OverrideFetchCategoriesByHandlesQueryHandler<T>() where T : IFetchCategoriesByHandlesQueryHandler
        {
            _queryHandlers[QueryHandlers.FetchCategoriesByHandlesQueryHandler].ImplementationType = typeof(T);
            return this;
        }

        public ICategoryServiceComponent OverrideFetchCategoriesByIdsQueryHandler<T>() where T : IFetchCategoriesByIdsQueryHandler
        {
            _queryHandlers[QueryHandlers.FetchCategoriesByIdsQueryHandler].ImplementationType = typeof(T);
            return this;
        }

        public ICategoryServiceComponent OverrideFetchCategoriesBySearchQueryHandler<T>() where T : IFetchCategoriesBySearchQueryHandler
        {
            _queryHandlers[QueryHandlers.FetchCategoriesBySearchQueryHandler].ImplementationType = typeof(T);
            return this;
        }
        #endregion Query Handlers
    }
}