﻿using System.Collections.Generic;
using System.Threading.Tasks;
using LightOps.Commerce.Services.Category.Api.Models;
using LightOps.Commerce.Services.Category.Api.Queries;
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

        public Task<ICategory> GetByIdAsync(string id)
        {
            return _queryDispatcher.DispatchAsync<FetchCategoryByIdQuery, ICategory>(new FetchCategoryByIdQuery
            {
                Id = id,
            });
        }

        public Task<IList<ICategory>> GetByIdAsync(IList<string> ids)
        {
            return _queryDispatcher.DispatchAsync<FetchCategoriesByIdsQuery, IList<ICategory>>(new FetchCategoriesByIdsQuery
            {
                Ids = ids,
            });
        }

        public Task<ICategory> GetByHandleAsync(string handle)
        {
            return _queryDispatcher.DispatchAsync<FetchCategoryByHandleQuery, ICategory>(new FetchCategoryByHandleQuery
            {
                Handle = handle,
            });
        }

        public Task<IList<ICategory>> GetByHandleAsync(IList<string> handles)
        {
            return _queryDispatcher.DispatchAsync<FetchCategoriesByHandlesQuery, IList<ICategory>>(new FetchCategoriesByHandlesQuery
            {
                Handles = handles,
            });
        }

        public Task<IList<ICategory>> GetByParentIdAsync(string parentId)
        {
            return _queryDispatcher.DispatchAsync<FetchCategoriesByParentIdQuery, IList<ICategory>>(new FetchCategoriesByParentIdQuery
            {
                ParentId = parentId,
            });
        }

        public Task<IList<ICategory>> GetByParentIdAsync(IList<string> parentIds)
        {
            return _queryDispatcher.DispatchAsync<FetchCategoriesByParentIdsQuery, IList<ICategory>>(new FetchCategoriesByParentIdsQuery
            {
                ParentIds = parentIds,
            });
        }

        public Task<IList<ICategory>> GetByRootAsync()
        {
            return _queryDispatcher.DispatchAsync<FetchCategoriesByRootQuery, IList<ICategory>>(new FetchCategoriesByRootQuery());
        }

        public Task<IList<ICategory>> GetBySearchAsync(string searchTerm)
        {
            return _queryDispatcher.DispatchAsync<FetchCategoriesBySearchQuery, IList<ICategory>>(new FetchCategoriesBySearchQuery
            {
                SearchTerm = searchTerm,
            });
        }
    }
}