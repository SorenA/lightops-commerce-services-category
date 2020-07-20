using System.Collections.Generic;
using LightOps.CQRS.Api.Queries;

namespace LightOps.Commerce.Services.Category.Api.Queries
{
    public class FetchCategoriesByIdsQuery : IQuery
    {
        public IList<string> Ids { get; set; }
    }
}