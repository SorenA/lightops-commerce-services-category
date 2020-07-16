﻿using System.Collections.Generic;
using LightOps.CQRS.Api.Queries;

namespace LightOps.Commerce.Services.Category.Api.Queries
{
    public class FetchCategoriesByHandleQuery : IQuery
    {
        public IList<string> Handles { get; set; }
    }
}