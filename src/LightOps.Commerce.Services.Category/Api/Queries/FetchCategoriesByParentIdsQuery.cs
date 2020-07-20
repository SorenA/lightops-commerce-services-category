using System.Collections.Generic;
using LightOps.CQRS.Api.Queries;

namespace LightOps.Commerce.Services.Category.Api.Queries
{
    public class FetchCategoriesByParentIdsQuery : IQuery
    {
        public IList<string> ParentIds { get; set; }
    }
}