using System.Collections.Generic;
using LightOps.CQRS.Api.Queries;

namespace LightOps.Commerce.Services.Category.Api.Queries
{
    public class FetchCategoriesByIdsQuery : IQuery
    {
        /// <summary>
        /// The ids of the categories requested
        /// </summary>
        public IList<string> Ids { get; set; }
    }
}