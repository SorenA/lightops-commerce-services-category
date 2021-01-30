using LightOps.CQRS.Api.Commands;

namespace LightOps.Commerce.Services.Category.Api.Commands
{
    public class PersistCategoryCommand : ICommand
    {
        /// <summary>
        /// The id of the category to persist
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The category to persist
        /// </summary>
        public Proto.Types.Category Category { get; set; }
    }
}