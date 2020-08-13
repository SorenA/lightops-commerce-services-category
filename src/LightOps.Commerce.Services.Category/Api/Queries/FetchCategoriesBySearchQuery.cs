﻿using LightOps.Commerce.Services.Category.Api.Enums;
using LightOps.CQRS.Api.Queries;

namespace LightOps.Commerce.Services.Category.Api.Queries
{
    public class FetchCategoriesBySearchQuery : IQuery
    {
        /// <summary>
        /// The term to search for, if any
        /// </summary>
        public string SearchTerm { get; set; }

        /// <summary>
        /// Search only in children with a specific parent id, if any specified. For no parent: 'gid://'
        /// </summary>
        public string ParentId { get; set; }

        /// <summary>
        /// The page cursor to use
        /// </summary>
        public string PageCursor { get; set; }

        /// <summary>
        /// The page size to use
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Sort the underlying list by the given key
        /// </summary>
        public CategorySortKey SortKey { get; set; }

        /// <summary>
        /// Whether to reverse the order of the underlying list
        /// </summary>
        public bool Reverse { get; set; }
    }
}