using LightOps.Commerce.Proto.Types;
using LightOps.Commerce.Services.Category.Api.Models;
using LightOps.Mapping.Api.Mappers;

namespace LightOps.Commerce.Services.Category.Domain.Mappers
{
    public class ImageProtoMapper : IMapper<IImage, ImageProto>
    {
        public ImageProto Map(IImage src)
        {
            return new ImageProto
            {
                Id = src.Id,
                Url = src.Url,
                AltText = src.AltText,
                FocalCenterTop = src.FocalCenterTop,
                FocalCenterLeft = src.FocalCenterLeft,
            };
        }
    }
}