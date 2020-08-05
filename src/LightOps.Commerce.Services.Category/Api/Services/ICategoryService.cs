﻿using System.Collections.Generic;
using System.Threading.Tasks;
using LightOps.Commerce.Services.Category.Api.Enums;
using LightOps.Commerce.Services.Category.Api.Models;
using LightOps.Commerce.Services.Category.Api.QueryResults;

namespace LightOps.Commerce.Services.Category.Api.Services
{
    public interface ICategoryService
    {
        /// <summary>
        /// Gets a list of categories by handle
        /// </summary>
        /// <param name="handles">The handles of the categories</param>
        /// <returns>List of categories, if any</returns>
        Task<IList<ICategory>> GetByHandleAsync(IList<string> handles);

        /// <summary>
        /// Gets a list of categories by ids
        /// </summary>
        /// <param name="ids">The ids of the categories</param>
        /// <returns>List of categories, if any</returns>
        Task<IList<ICategory>> GetByIdAsync(IList<string> ids);


        /// <summary>
        /// Gets a list of paginated categories by search
        /// </summary>
        /// <param name="searchTerm">The term to search for</param>
        /// <param name="parentId">Search only in children with a specific parent id, if any specified. For no parent: 'gid://'</param>
        /// <param name="pageCursor">The page cursor to use</param>
        /// <param name="pageSize">The page size to use</param>
        /// <param name="sortKey">Sort the underlying list by the given key</param>
        /// <param name="reverse">Whether to reverse the order of the underlying list</param>
        /// <returns>Search result with categories matching search</returns>
        Task<SearchResult<ICategory>> GetBySearchAsync(string searchTerm,
                                                string parentId,
                                                string pageCursor,
                                                int pageSize,
                                                CategorySortKey sortKey,
                                                bool reverse);
    }
}