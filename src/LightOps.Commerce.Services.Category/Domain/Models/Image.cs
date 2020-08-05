using LightOps.Commerce.Services.Category.Api.Models;

namespace LightOps.Commerce.Services.Category.Domain.Models
{
    public class Image : IImage
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public string AltText { get; set; }
    }
}