using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LightOps.Commerce.Services.Category.Api.Enums;
using LightOps.Commerce.Services.Category.Api.Models;
using LightOps.Commerce.Services.Category.Api.Queries;
using LightOps.Commerce.Services.Category.Api.QueryHandlers;
using LightOps.Commerce.Services.Category.Api.QueryResults;
using LightOps.Commerce.Services.Category.Backends.InMemory.Api.Providers;

namespace LightOps.Commerce.Services.Category.Backends.InMemory.Domain.QueryHandlers
{
    public class FetchCategoriesBySearchQueryHandler : IFetchCategoriesBySearchQueryHandler
    {
        private readonly IInMemoryCategoryProvider _inMemoryCategoryProvider;

        public FetchCategoriesBySearchQueryHandler(IInMemoryCategoryProvider inMemoryCategoryProvider)
        {
            _inMemoryCategoryProvider = inMemoryCategoryProvider;
        }
        
        public Task<SearchResult<ICategory>> HandleAsync(FetchCategoriesBySearchQuery query)
        {
            var searchTerm = query.SearchTerm.ToLowerInvariant();

            var inMemoryQuery = _inMemoryCategoryProvider.Categories
                .AsQueryable();

            // Sort underlying list
            switch (query.SortKey)
            {
                case CategorySortKey.Title:
                    inMemoryQuery = inMemoryQuery.OrderBy(x => x.Title);
                    break;
                case CategorySortKey.CreatedAt:
                    inMemoryQuery = inMemoryQuery.OrderBy(x => x.CreatedAt);
                    break;
                case CategorySortKey.UpdatedAt:
                    inMemoryQuery = inMemoryQuery.OrderBy(x => x.UpdatedAt);
                    break;
            }

            // Reverse underlying list if requested
            if (query.Reverse)
            {
                inMemoryQuery = inMemoryQuery.Reverse();
            }

            // Match parent id if requested
            if (!string.IsNullOrEmpty(query.ParentId))
            {
                inMemoryQuery = inMemoryQuery.Where(x => x.ParentId == query.ParentId);
            }

            // Search in list
            if (query.SearchTerm != "*")
            {
                inMemoryQuery = inMemoryQuery
                    .Where(x =>
                        (string.IsNullOrWhiteSpace(x.Title) || x.Title.ToLowerInvariant().Contains(searchTerm))
                        || (string.IsNullOrWhiteSpace(x.Description) || x.Description.ToLowerInvariant().Contains(searchTerm)));
            }

            // Get total results
            var totalResults = inMemoryQuery.Count();

            // Paginate - Skip
            var nodeId = DecodeCursor(query.PageCursor);
            if (!string.IsNullOrEmpty(nodeId))
            {
                // Skip until we reach cursor, then one more for next page
                inMemoryQuery = inMemoryQuery
                    .SkipWhile(x => x.Id != nodeId)
                    .Skip(1);
            }

            // Get remaining results to know if next page is available
            var remainingResults = inMemoryQuery.Count();

            // Paginate - Take
            var results = inMemoryQuery
                .Take(query.PageSize)
                .ToList();

            // Generate next page cursor
            var nextPageCursor = EncodeCursor(results.LastOrDefault()?.Id);

            var searchResult = new SearchResult<ICategory>
            {
                Results = results,
                NextPageCursor = nextPageCursor,
                HasNextPage = remainingResults > query.PageSize,
                TotalResults = totalResults,
            };

            return Task.FromResult(searchResult);
        }

        private string EncodeCursor(string rawCursor)
        {
            try
            {
                var bytes = System.Text.Encoding.UTF8.GetBytes(rawCursor);
                return Convert.ToBase64String(bytes);
            }
            catch
            {
                // Invalid cursor
                return string.Empty;
            }
        }

        private string DecodeCursor(string encodedCursor)
        {
            try
            {
                var bytes = Convert.FromBase64String(encodedCursor);
                return System.Text.Encoding.UTF8.GetString(bytes);
            }
            catch
            {
                // Invalid cursor
                return string.Empty;
            }
        }
    }
}