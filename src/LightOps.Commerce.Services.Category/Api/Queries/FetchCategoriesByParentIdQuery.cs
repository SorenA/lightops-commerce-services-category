using LightOps.CQRS.Api.Queries;

namespace LightOps.Commerce.Services.Category.Api.Queries
{
    public class FetchCategoriesByParentIdQuery : IQuery
    {
        public string ParentId { get; set; }
    }
}