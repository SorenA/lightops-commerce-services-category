using System.Collections.Generic;
using LightOps.CQRS.Api.Queries;

namespace LightOps.Commerce.Services.Category.Api.Queries
{
    public class FetchCategoriesByIdQuery : IQuery
    {
        public IList<string> Ids { get; set; }
    }
}