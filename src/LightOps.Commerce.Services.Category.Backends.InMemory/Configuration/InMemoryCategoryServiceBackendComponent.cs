using System.Collections.Generic;
using System.Linq;
using LightOps.Commerce.Services.Category.Backends.InMemory.Api.Providers;
using LightOps.Commerce.Services.Category.Backends.InMemory.Domain.Providers;
using LightOps.DependencyInjection.Api.Configuration;
using LightOps.DependencyInjection.Domain.Configuration;

namespace LightOps.Commerce.Services.Category.Backends.InMemory.Configuration
{
    public class InMemoryCategoryServiceBackendComponent : IDependencyInjectionComponent, IInMemoryCategoryServiceBackendComponent
    {
        public string Name => "lightops.commerce.services.category.backend.in-memory";

        public IReadOnlyList<ServiceRegistration> GetServiceRegistrations()
        {
            return new List<ServiceRegistration>()
                .Union(_providers.Values)
                .ToList();
        }

        #region Entities
        public IInMemoryCategoryServiceBackendComponent UseCategories(IList<Proto.Types.Category> categories)
        {
            // Populate in-memory providers
            _providers[Providers.InMemoryCategoryProvider].ImplementationType = null;
            _providers[Providers.InMemoryCategoryProvider].ImplementationInstance = new InMemoryCategoryProvider
            {
                Categories = categories,
            };

            return this;
        }
        #endregion Entities

        #region Providers
        internal enum Providers
        {
            InMemoryCategoryProvider,
        }

        private readonly Dictionary<Providers, ServiceRegistration> _providers = new Dictionary<Providers, ServiceRegistration>
        {
            [Providers.InMemoryCategoryProvider] = ServiceRegistration.Singleton<IInMemoryCategoryProvider, InMemoryCategoryProvider>(),
        };

        public IInMemoryCategoryServiceBackendComponent OverrideCategoryProvider<T>() where T : IInMemoryCategoryProvider
        {
            _providers[Providers.InMemoryCategoryProvider].ImplementationInstance = null;
            _providers[Providers.InMemoryCategoryProvider].ImplementationType = typeof(T);
            return this;
        }
        #endregion Providers
    }
}