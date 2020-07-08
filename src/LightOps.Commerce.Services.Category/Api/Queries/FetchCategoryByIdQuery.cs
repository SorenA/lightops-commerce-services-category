using LightOps.CQRS.Api.Queries;

namespace LightOps.Commerce.Services.Category.Api.Queries
{
    public class FetchCategoryByIdQuery : IQuery
    {
        public string Id { get; set; }
    }
}