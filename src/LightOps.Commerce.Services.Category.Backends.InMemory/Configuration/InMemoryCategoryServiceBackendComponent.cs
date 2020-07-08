using System.Collections.Generic;
using System.Linq;
using LightOps.Commerce.Services.Category.Api.Models;
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
            // Populate in-memory providers
            _providers[Providers.InMemoryCategoryProvider].ImplementationInstance = new InMemoryCategoryProvider
            {
                Categories = _categories,
            };

            return new List<ServiceRegistration>()
                .Union(_providers.Values)
                .ToList();
        }

        #region Entities
        private readonly IList<ICategory> _categories = new List<ICategory>();

        public IInMemoryCategoryServiceBackendComponent UseCategories(IList<ICategory> categories)
        {
            foreach (var category in categories)
            {
                _categories.Add(category);
            }

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
            [Providers.InMemoryCategoryProvider] = ServiceRegistration.Singleton<IInMemoryCategoryProvider>(),
        };
        #endregion Providers
    }
}