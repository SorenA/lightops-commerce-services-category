using System.Collections.Generic;
using LightOps.CQRS.Api.Queries;

namespace LightOps.Commerce.Services.Category.Api.Queries
{
    public class FetchCategoriesByHandlesQuery : IQuery
    {
        /// <summary>
        /// The handles of the categories requested
        /// </summary>
        public IList<string> Handles { get; set; }
    }
}