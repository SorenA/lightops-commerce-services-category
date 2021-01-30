using System;
using LightOps.Commerce.Services.Category.Backends.InMemory.Domain.CommandHandlers;
using LightOps.Commerce.Services.Category.Backends.InMemory.Domain.QueryHandlers;
using LightOps.Commerce.Services.Category.Configuration;
using LightOps.DependencyInjection.Configuration;

namespace LightOps.Commerce.Services.Category.Backends.InMemory.Configuration
{
    public static class CategoryServiceComponentExtensions
    {
        public static ICategoryServiceComponent UseInMemoryBackend(
            this ICategoryServiceComponent serviceComponent,
            IDependencyInjectionRootComponent rootComponent,
            Action<IInMemoryCategoryServiceBackendComponent> componentConfig = null)
        {
            var component = new InMemoryCategoryServiceBackendComponent();

            // Invoke config delegate
            componentConfig?.Invoke(component);

            // Attach to root component
            rootComponent.AttachComponent(component);

            // Override command handlers
            serviceComponent
                .OverridePersistCategoryCommandHandler<PersistCategoryCommandHandler>()
                .OverrideDeleteCategoryCommandHandler<DeleteCategoryCommandHandler>();

            // Override query handlers
            serviceComponent
                .OverrideCheckCategoryServiceHealthQueryHandler<CheckCategoryServiceHealthQueryHandler>()
                .OverrideFetchCategoriesByHandlesQueryHandler<FetchCategoriesByHandlesQueryHandler>()
                .OverrideFetchCategoriesByIdsQueryHandler<FetchCategoriesByIdsQueryHandler>()
                .OverrideFetchCategoriesBySearchQueryHandler<FetchCategoriesBySearchQueryHandler>();

            return serviceComponent;
        }
    }
}
