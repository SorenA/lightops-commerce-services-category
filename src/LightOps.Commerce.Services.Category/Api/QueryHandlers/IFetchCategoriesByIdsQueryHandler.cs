using System.Collections.Generic;
using LightOps.Commerce.Services.Category.Api.Models;
using LightOps.Commerce.Services.Category.Api.Queries;
using LightOps.CQRS.Api.Queries;

namespace LightOps.Commerce.Services.Category.Api.QueryHandlers
{
    public interface IFetchCategoriesByIdsQueryHandler : IQueryHandler<FetchCategoriesByIdsQuery, IList<ICategory>>
    {

    }
}