using System;
using LightOps.DependencyInjection.Configuration;

namespace LightOps.Commerce.Services.Category.Configuration
{
    public static class DependencyInjectionRootComponentExtensions
    {

        public static IDependencyInjectionRootComponent AddCategoryService(this IDependencyInjectionRootComponent rootComponent, Action<ICategoryServiceComponent> componentConfig = null)
        {
            var component = new CategoryServiceComponent();

            // Invoke config delegate
            componentConfig?.Invoke(component);

            // Attach to root component
            rootComponent.AttachComponent(component);

            return rootComponent;
        }
    }
}
