using LightOps.Commerce.Services.Category.Api.Commands;
using LightOps.CQRS.Api.Commands;

namespace LightOps.Commerce.Services.Category.Api.CommandHandlers
{
    public interface IPersistCategoryCommandHandler : ICommandHandler<PersistCategoryCommand>
    {
        
    }
}