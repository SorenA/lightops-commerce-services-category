using System;
using System.Linq;
using System.Threading.Tasks;
using LightOps.Commerce.Services.Category.Api.CommandHandlers;
using LightOps.Commerce.Services.Category.Api.Commands;
using LightOps.Commerce.Services.Category.Backends.InMemory.Api.Providers;

namespace LightOps.Commerce.Services.Category.Backends.InMemory.Domain.CommandHandlers
{
    public class PersistCategoryCommandHandler : IPersistCategoryCommandHandler
    {
        private readonly IInMemoryCategoryProvider _inMemoryCategoryProvider;

        public PersistCategoryCommandHandler(IInMemoryCategoryProvider inMemoryCategoryProvider)
        {
            _inMemoryCategoryProvider = inMemoryCategoryProvider;
        }

        public Task HandleAsync(PersistCategoryCommand command)
        {
            if (string.IsNullOrWhiteSpace(command.Id))
            {
                throw new ArgumentException("ID missing.");
            }

            if (command.Category.Id != command.Id)
            {
                throw new ArgumentException("Provided ID and entity ID do not match.");
            }

            // Check if entity already exists
            var entity = _inMemoryCategoryProvider
                .Categories?
                .FirstOrDefault(x => x.Id == command.Id);

            // Delete old if found
            if (entity != null)
            {
                _inMemoryCategoryProvider.Categories?.Remove(entity);
            }

            // Add entity to provider
            _inMemoryCategoryProvider.Categories?.Add(command.Category);

            return Task.CompletedTask;
        }
    }
}