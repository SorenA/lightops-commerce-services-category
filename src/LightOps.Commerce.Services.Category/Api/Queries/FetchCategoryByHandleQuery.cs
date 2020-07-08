using LightOps.CQRS.Api.Queries;

namespace LightOps.Commerce.Services.Category.Api.Queries
{
    public class FetchCategoryByHandleQuery : IQuery
    {
        public string Handle { get; set; }
    }
}