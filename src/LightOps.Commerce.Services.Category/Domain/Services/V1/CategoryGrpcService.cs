using System.Threading.Tasks;
using Grpc.Core;
using LightOps.Commerce.Proto.Services.Category.V1;
using LightOps.Commerce.Services.Category.Api.Models;
using LightOps.Commerce.Services.Category.Api.Services;
using LightOps.Mapping.Api.Services;
using Microsoft.Extensions.Logging;

namespace LightOps.Commerce.Services.Category.Domain.Services.V1
{
    public class CategoryGrpcService : ProtoCategoryService.ProtoCategoryServiceBase
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

        public override async Task<ProtoGetCategoryResponse> GetCategory(ProtoGetCategoryRequest request, ServerCallContext context)
        {
            ICategory entity;
            switch (request.IdentifierCase)
            {
                case ProtoGetCategoryRequest.IdentifierOneofCase.Id:
                    entity = await _categoryService.GetByIdAsync(request.Id);
                    break;
                case ProtoGetCategoryRequest.IdentifierOneofCase.Handle:
                    entity = await _categoryService.GetByHandleAsync(request.Handle);
                    break;
                default:
                    throw new RpcException(new Status(StatusCode.InvalidArgument, "Missing identifier"));
            }

            var protoEntity = _mappingService.Map<ICategory, ProtoCategory>(entity);

            var result = new ProtoGetCategoryResponse
            {
                Category = protoEntity,
            };

            return result;
        }

        public override async Task<GetCategoriesByIdsResponse> GetCategoriesByIds(GetCategoriesByIdsRequest request, ServerCallContext context)
        {
            var entities = await _categoryService.GetByIdAsync(request.Ids);
            var protoEntities = _mappingService.Map<ICategory, ProtoCategory>(entities);

            var result = new GetCategoriesByIdsResponse();
            result.Categories.AddRange(protoEntities);

            return result;
        }

        public override async Task<GetCategoriesByHandlesResponse> GetCategoriesByHandles(GetCategoriesByHandlesRequest request, ServerCallContext context)
        {
            var entities = await _categoryService.GetByHandleAsync(request.Handles);
            var protoEntities = _mappingService.Map<ICategory, ProtoCategory>(entities);

            var result = new GetCategoriesByHandlesResponse();
            result.Categories.AddRange(protoEntities);

            return result;
        }

        public override async Task<ProtoGetCategoriesByParentIdResponse> GetCategoriesByParentId(ProtoGetCategoriesByParentIdRequest request, ServerCallContext context)
        {
            var entities = await _categoryService.GetByParentIdAsync(request.ParentId);
            var protoEntities = _mappingService.Map<ICategory, ProtoCategory>(entities);

            var result = new ProtoGetCategoriesByParentIdResponse();
            result.Categories.AddRange(protoEntities);

            return result;
        }

        public override async Task<ProtoGetCategoriesByParentIdsResponse> GetCategoriesByParentIds(ProtoGetCategoriesByParentIdsRequest request, ServerCallContext context)
        {
            var entities = await _categoryService.GetByParentIdAsync(request.ParentIds);
            var protoEntities = _mappingService.Map<ICategory, ProtoCategory>(entities);

            var result = new ProtoGetCategoriesByParentIdsResponse();
            result.Categories.AddRange(protoEntities);

            return result;
        }

        public override async Task<ProtoGetCategoriesByRootResponse> GetCategoriesByRoot(ProtoGetCategoriesByRootRequest request, ServerCallContext context)
        {
            var entities = await _categoryService.GetByRootAsync();
            var protoEntities = _mappingService.Map<ICategory, ProtoCategory>(entities);

            var result = new ProtoGetCategoriesByRootResponse();
            result.Categories.AddRange(protoEntities);

            return result;
        }

        public override async Task<ProtoGetCategoriesBySearchResponse> GetCategoriesBySearch(ProtoGetCategoriesBySearchRequest request, ServerCallContext context)
        {
            var entities = await _categoryService.GetBySearchAsync(request.SearchTerm);
            var protoEntities = _mappingService.Map<ICategory, ProtoCategory>(entities);

            var result = new ProtoGetCategoriesBySearchResponse();
            result.Categories.AddRange(protoEntities);

            return result;
        }
    }
}
