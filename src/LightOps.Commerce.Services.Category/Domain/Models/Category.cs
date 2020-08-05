using System;
using LightOps.Commerce.Services.Category.Api.Models;

namespace LightOps.Commerce.Services.Category.Domain.Models
{
    public class Category : ICategory
    {
        public string Id { get; set; }
        public string ParentId { get; set; }
        public string Handle { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public IImage PrimaryImage { get; set; }
    }
}