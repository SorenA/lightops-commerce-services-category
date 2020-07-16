using LightOps.Commerce.Services.Category.Api.Models;

namespace LightOps.Commerce.Services.Category.Domain.Models
{
    public class Category : ICategory
    {
        public string Id { get; set; }
        public string Handle { get; set; }
        public string Url { get; set; }

        public string ParentCategoryId { get; set; }

        public string Title { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }

        public string SeoTitle { get; set; }
        public string SeoDescription { get; set; }

        public string PrimaryImage { get; set; }
    }
}