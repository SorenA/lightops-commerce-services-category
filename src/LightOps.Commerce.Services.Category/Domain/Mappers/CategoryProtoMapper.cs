using Google.Protobuf.WellKnownTypes;
using LightOps.Commerce.Proto.Types;
using LightOps.Commerce.Services.Category.Api.Models;
using LightOps.Mapping.Api.Mappers;
using LightOps.Mapping.Api.Services;

namespace LightOps.Commerce.Services.Category.Domain.Mappers
{
    public class CategoryProtoMapper : IMapper<ICategory, CategoryProto>
    {
        private readonly IMappingService _mappingService;

        public CategoryProtoMapper(IMappingService mappingService)
        {
            _mappingService = mappingService;
        }

        public CategoryProto Map(ICategory src)
        {
            return new CategoryProto
            {
                Id = src.Id,
                ParentId = src.ParentId,
                Handle = src.Handle,
                Title = src.Title,
                Url = src.Url,
                Type = src.Type,
                Description = src.Description,
                CreatedAt = Timestamp.FromDateTime(src.CreatedAt.ToUniversalTime()),
                UpdatedAt = Timestamp.FromDateTime(src.UpdatedAt.ToUniversalTime()),
                PrimaryImage = _mappingService.Map<IImage, ImageProto>(src.PrimaryImage),
            };
        }
    }
}