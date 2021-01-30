using System;
using System.Linq;
using System.Threading.Tasks;
using LightOps.Commerce.Services.Category.Api.CommandHandlers;
using LightOps.Commerce.Services.Category.Api.Commands;
using LightOps.Commerce.Services.Category.Backends.InMemory.Api.Providers;

namespace LightOps.Commerce.Services.Category.Backends.InMemory.Domain.CommandHandlers
{
    public class DeleteCategoryCommandHandler : IDeleteCategoryCommandHandler
    {
        private readonly IInMemoryCategoryProvider _inMemoryCategoryProvider;

        public DeleteCategoryCommandHandler(IInMemoryCategoryProvider inMemoryCategoryProvider)
        {
            _inMemoryCategoryProvider = inMemoryCategoryProvider;
        }

        public Task HandleAsync(DeleteCategoryCommand command)
        {
            if (string.IsNullOrWhiteSpace(command.Id))
            {
                throw new ArgumentException("ID missing.");
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

            return Task.CompletedTask;
        }
    }
}