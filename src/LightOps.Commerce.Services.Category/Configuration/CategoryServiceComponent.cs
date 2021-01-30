using System.Collections.Generic;
using System.Linq;
using LightOps.Commerce.Services.Category.Api.CommandHandlers;
using LightOps.Commerce.Services.Category.Api.Commands;
using LightOps.Commerce.Services.Category.Api.Queries;
using LightOps.Commerce.Services.Category.Api.QueryHandlers;
using LightOps.Commerce.Services.Category.Api.QueryResults;
using LightOps.CQRS.Api.Commands;
using LightOps.CQRS.Api.Queries;
using LightOps.DependencyInjection.Api.Configuration;
using LightOps.DependencyInjection.Domain.Configuration;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace LightOps.Commerce.Services.Category.Configuration
{
    public class CategoryServiceComponent : IDependencyInjectionComponent, ICategoryServiceComponent
    {
        public string Name => "lightops.commerce.services.category";

        public IReadOnlyList<ServiceRegistration> GetServiceRegistrations()
        {
            return new List<ServiceRegistration>()
                .Union(_queryHandlers.Values)
                .Union(_commandHandlers.Values)
                .ToList();
        }

        #region Query Handlers
        internal enum QueryHandlers
        {
            CheckCategoryServiceHealthQueryHandler,

            FetchCategoriesByHandlesQueryHandler,
            FetchCategoriesByIdsQueryHandler,
            FetchCategoriesBySearchQueryHandler,
        }

        private readonly Dictionary<QueryHandlers, ServiceRegistration> _queryHandlers = new Dictionary<QueryHandlers, ServiceRegistration>
        {
            [QueryHandlers.CheckCategoryServiceHealthQueryHandler] = ServiceRegistration.Transient<IQueryHandler<CheckCategoryServiceHealthQuery, HealthStatus>>(),

            [QueryHandlers.FetchCategoriesByHandlesQueryHandler] = ServiceRegistration.Transient<IQueryHandler<FetchCategoriesByHandlesQuery, IList<Proto.Types.Category>>>(),
            [QueryHandlers.FetchCategoriesByIdsQueryHandler] = ServiceRegistration.Transient<IQueryHandler<FetchCategoriesByIdsQuery, IList<Proto.Types.Category>>>(),
            [QueryHandlers.FetchCategoriesBySearchQueryHandler] = ServiceRegistration.Transient<IQueryHandler<FetchCategoriesBySearchQuery, SearchResult<Proto.Types.Category>>>(),
        };

        public ICategoryServiceComponent OverrideCheckCategoryServiceHealthQueryHandler<T>() where T : ICheckCategoryServiceHealthQueryHandler
        {
            _queryHandlers[QueryHandlers.CheckCategoryServiceHealthQueryHandler].ImplementationType = typeof(T);
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

        #region Command Handlers
        internal enum CommandHandlers
        {
            PersistCategoryCommandHandler,
            DeleteCategoryCommandHandler,
        }

        private readonly Dictionary<CommandHandlers, ServiceRegistration> _commandHandlers = new Dictionary<CommandHandlers, ServiceRegistration>
        {
            [CommandHandlers.PersistCategoryCommandHandler] = ServiceRegistration.Transient<ICommandHandler<PersistCategoryCommand>>(),
            [CommandHandlers.DeleteCategoryCommandHandler] = ServiceRegistration.Transient<ICommandHandler<DeleteCategoryCommand>>(),
        };

        public ICategoryServiceComponent OverridePersistCategoryCommandHandler<T>() where T : IPersistCategoryCommandHandler
        {
            _commandHandlers[CommandHandlers.PersistCategoryCommandHandler].ImplementationType = typeof(T);
            return this;
        }

        public ICategoryServiceComponent OverrideDeleteCategoryCommandHandler<T>() where T : IDeleteCategoryCommandHandler
        {
            _commandHandlers[CommandHandlers.DeleteCategoryCommandHandler].ImplementationType = typeof(T);
            return this;
        }
        #endregion Command Handlers
    }
}