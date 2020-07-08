using System.Linq;
using LightOps.Commerce.Proto.Services.Category.V1;
using LightOps.Commerce.Services.Category.Api.Models;
using LightOps.Mapping.Api.Mappers;
using LightOps.Mapping.Api.Services;

// ReSharper disable UseObjectOrCollectionInitializer

namespace LightOps.Commerce.Services.Category.Domain.Mappers.V1
{
    public class ProtoCategoryMapper : IMapper<ICategory, ProtoCategory>
    {
        private readonly IMappingService _mappingService;

        public ProtoCategoryMapper(IMappingService mappingService)
        {
            _mappingService = mappingService;
        }

        public ProtoCategory Map(ICategory source)
        {
            var dest = new ProtoCategory();

            dest.Id = source.Id;
            dest.Handle = source.Handle;
            dest.Url = source.Url;

            dest.ParentCategoryId = source.ParentCategoryId;

            dest.Title = source.Title;
            dest.Description = source.Description;

            dest.SeoTitle = source.SeoTitle;
            dest.SeoDescription = source.SeoDescription;

            dest.PrimaryImage = source.PrimaryImage;

            return dest;
        }
    }
}