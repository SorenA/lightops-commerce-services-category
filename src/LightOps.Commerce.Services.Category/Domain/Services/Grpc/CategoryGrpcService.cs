using System;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using LightOps.Commerce.Proto.Services;
using LightOps.Commerce.Proto.Types;
using LightOps.Commerce.Services.Category.Api.Enums;
using LightOps.Commerce.Services.Category.Api.Models;
using LightOps.Commerce.Services.Category.Api.Services;
using LightOps.Mapping.Api.Services;
using Microsoft.Extensions.Logging;

namespace LightOps.Commerce.Services.Category.Domain.Services.Grpc
{
    public class CategoryGrpcService : CategoryProtoService.CategoryProtoServiceBase
    {
        private readonly ILogger<CategoryGrpcService> _logger;
        private readonly ICategoryService _categoryService;
        private readonly IMappingService _mappingService;

        public CategoryGrpcService(
            ILogger<CategoryGrpcService> logger,
            ICategoryService categoryService,
            IMappingService mappingService)
        {
            _logger = logger;
            _categoryService = categoryService;
            _mappingService = mappingService;
        }
        
        public override async Task<GetCategoriesByIdsProtoResponse> GetCategoriesByIds(GetCategoriesByIdsProtoRequest request, ServerCallContext context)
        {
            var entities = await _categoryService.GetByIdAsync(request.Ids);
            var protoEntities = _mappingService.Map<ICategory, CategoryProto>(entities);

            var result = new GetCategoriesByIdsProtoResponse();
            result.Categories.AddRange(protoEntities);

            return result;
        }

        public override async Task<GetCategoriesByHandlesProtoResponse> GetCategoriesByHandles(GetCategoriesByHandlesProtoRequest request, ServerCallContext context)
        {
            var entities = await _categoryService.GetByHandleAsync(request.Handles);
            var protoEntities = _mappingService.Map<ICategory, CategoryProto>(entities);

            var result = new GetCategoriesByHandlesProtoResponse();
            result.Categories.AddRange(protoEntities);

            return result;
        }

        public override async Task<GetCategoriesBySearchProtoResponse> GetCategoriesBySearch(GetCategoriesBySearchProtoRequest request, ServerCallContext context)
        {
            var searchResult = await _categoryService.GetBySearchAsync(
                request.SearchTerm,
                request.ParentId,
                request.PageCursor,
                request.PageSize ?? 24,
                ConvertSortKey(request.SortKey),
                request.Reverse ?? false);

            var protoEntities = _mappingService
                .Map<ICategory, CategoryProto>(searchResult.Results)
                .ToList();

            var result = new GetCategoriesBySearchProtoResponse
            {
                HasNextPage = searchResult.HasNextPage,
                NextPageCursor = searchResult.NextPageCursor,
                TotalResults = searchResult.TotalResults,
            };
            result.Results.AddRange(protoEntities);

            return result;
        }

        private CategorySortKey ConvertSortKey(CategorySortKeyProto sortKey)
        {
            switch (sortKey)
            {
                case CategorySortKeyProto.Default:
                    return CategorySortKey.Default;
                case CategorySortKeyProto.Title:
                    return CategorySortKey.Title;
                case CategorySortKeyProto.CreatedAt:
                    return CategorySortKey.CreatedAt;
                case CategorySortKeyProto.UpdatedAt:
                    return CategorySortKey.UpdatedAt;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
