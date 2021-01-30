using LightOps.CQRS.Api.Commands;

namespace LightOps.Commerce.Services.Category.Api.Commands
{
    public class DeleteCategoryCommand : ICommand
    {
        /// <summary>
        /// The id of the category to delete
        /// </summary>
        public string Id { get; set; }
    }
}