﻿using System.Collections.Generic;
using LightOps.Commerce.Services.Category.Api.Queries;
using LightOps.CQRS.Api.Queries;

namespace LightOps.Commerce.Services.Category.Api.QueryHandlers
{
    public interface IFetchCategoriesByHandlesQueryHandler : IQueryHandler<FetchCategoriesByHandlesQuery, IList<Proto.Types.Category>>
    {

    }
}