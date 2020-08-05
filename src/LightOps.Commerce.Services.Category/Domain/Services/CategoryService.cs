using System.Collections.Generic;
using System.Threading.Tasks;
using LightOps.Commerce.Services.Category.Api.Enums;
using LightOps.Commerce.Services.Category.Api.Models;
using LightOps.Commerce.Services.Category.Api.Queries;
using LightOps.Commerce.Services.Category.Api.QueryResults;
using LightOps.Commerce.Services.Category.Api.Services;
using LightOps.CQRS.Api.Services;

namespace LightOps.Commerce.Services.Category.Domain.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IQueryDispatcher _queryDispatcher;

        public CategoryService(IQueryDispatcher queryDispatcher)
        {
            _queryDispatcher = queryDispatcher;
        }
        
        public Task<IList<ICategory>> GetByHandleAsync(IList<string> handles)
        {
            return _queryDispatcher.DispatchAsync<FetchCategoriesByHandlesQuery, IList<ICategory>>(new FetchCategoriesByHandlesQuery
            {
                Handles = handles,
            });
        }

        public Task<IList<ICategory>> GetByIdAsync(IList<string> ids)
        {
            return _queryDispatcher.DispatchAsync<FetchCategoriesByIdsQuery, IList<ICategory>>(new FetchCategoriesByIdsQuery
            {
                Ids = ids,
            });
        }

        public Task<SearchResult<ICategory>> GetBySearchAsync(string searchTerm,
                                                                 string parentId,
                                                                 string pageCursor,
                                                                 int pageSize,
                                                                 CategorySortKey sortKey,
                                                                 bool reverse)
        {
            return _queryDispatcher.DispatchAsync<FetchCategoriesBySearchQuery, SearchResult<ICategory>>(
                new FetchCategoriesBySearchQuery
                {
                    SearchTerm = searchTerm,
                    ParentId = parentId,
                    PageCursor = pageCursor,
                    PageSize = pageSize,
                    SortKey = sortKey,
                    Reverse = reverse,
                });
        }
    }
}