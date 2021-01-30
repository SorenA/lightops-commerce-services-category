using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Grpc.Core;
using LightOps.Commerce.Proto.Services;
using LightOps.Commerce.Services.Category.Api.Commands;
using LightOps.Commerce.Services.Category.Api.Queries;
using LightOps.Commerce.Services.Category.Api.QueryResults;
using LightOps.CQRS.Api.Services;
using Microsoft.Extensions.Logging;

namespace LightOps.Commerce.Services.Category.Domain.GrpcServices
{
    public class CategoryGrpcService : CategoryService.CategoryServiceBase
    {
        private readonly ILogger<CategoryGrpcService> _logger;
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public CategoryGrpcService(
            ILogger<CategoryGrpcService> logger,
            ICommandDispatcher commandDispatcher,
            IQueryDispatcher queryDispatcher)
        {
            _logger = logger;
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        public override async Task<PersistResponse> Persist(PersistRequest request, ServerCallContext context)
        {
            try
            {
                await _commandDispatcher.DispatchAsync(new PersistCategoryCommand
                {
                    Id = request.Id,
                    Category = request.Category,
                });

                return new PersistResponse
                {
                    StatusCode = PersistResponse.Types.StatusCode.Ok,
                };
            }
            catch (ArgumentException e)
            {
                _logger.LogError($"Failed persisting entity {request.Id}", e);
                return new PersistResponse
                {
                    StatusCode = PersistResponse.Types.StatusCode.Invalid,
                    Errors = { e.Message },
                };
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed persisting entity {request.Id}", e);
            }

            return new PersistResponse
            {
                StatusCode = PersistResponse.Types.StatusCode.Unavailable,
            };
        }

        public override async Task<DeleteResponse> Delete(DeleteRequest request, ServerCallContext context)
        {
            try
            {
                await _commandDispatcher.DispatchAsync(new DeleteCategoryCommand
                {
                    Id = request.Id,
                });

                return new DeleteResponse
                {
                    StatusCode = DeleteResponse.Types.StatusCode.Ok,
                };
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed deleting entity {request.Id}", e);
            }

            return new DeleteResponse
            {
                StatusCode = DeleteResponse.Types.StatusCode.Unavailable,
            };
        }

        public override async Task<GetByHandlesResponse> GetByHandles(GetByHandlesRequest request, ServerCallContext context)
        {
            try
            {
                var entities = await _queryDispatcher.DispatchAsync<FetchCategoriesByHandlesQuery, IList<Proto.Types.Category>>(new FetchCategoriesByHandlesQuery
                {
                    Handles = request.Handles,
                });

                return new GetByHandlesResponse
                {
                    Categories = { entities },
                };
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed fetching by handles '{string.Join(",", request.Handles)}'", e);
            }

            return new GetByHandlesResponse();
        }

        public override async Task<GetByIdsResponse> GetByIds(GetByIdsRequest request, ServerCallContext context)
        {
            try
            {
                var entities = await _queryDispatcher.DispatchAsync<FetchCategoriesByIdsQuery, IList<Proto.Types.Category>>(new FetchCategoriesByIdsQuery
                {
                    Ids = request.Ids,
                });

                return new GetByIdsResponse
                {
                    Categories = { entities },
                };
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed fetching by ids '{string.Join(",", request.Ids)}'", e);
            }

            return new GetByIdsResponse();
        }

        public override async Task<GetBySearchResponse> GetBySearch(GetBySearchRequest request, ServerCallContext context)
        {
            try
            {
                var searchResult = await _queryDispatcher.DispatchAsync<FetchCategoriesBySearchQuery, SearchResult<Proto.Types.Category>>(new FetchCategoriesBySearchQuery
                {
                    SearchTerm = request.SearchTerm,
                    LanguageCode = request.LanguageCode,
                    ParentId = request.ParentId,
                    PageCursor = request.PageCursor,
                    PageSize = request.PageSize ?? 24,
                    SortKey = request.SortKey,
                    Reverse = request.Reverse ?? false,
                });

                return new GetBySearchResponse
                {
                    Results =
                    {
                        searchResult.Results.Select(x => new GetBySearchResponse.Types.Result()
                        {
                            Cursor = x.Cursor,
                            Node = x.Node
                        })
                    },
                    HasNextPage = searchResult.HasNextPage,
                    HasPreviousPage = searchResult.HasPreviousPage,
                    StartCursor = searchResult.StartCursor ?? string.Empty,
                    EndCursor = searchResult.EndCursor ?? string.Empty,
                    TotalResults = searchResult.TotalResults,
                };
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed fetching by search '{JsonSerializer.Serialize(request)}'", e);
            }

            return new GetBySearchResponse();
        }
    }
}
