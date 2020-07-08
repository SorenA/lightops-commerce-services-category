using System.Collections.Generic;
using System.Threading.Tasks;
using LightOps.Commerce.Services.Category.Api.Models;

namespace LightOps.Commerce.Services.Category.Api.Services
{
    public interface ICategoryService
    {
        Task<ICategory> GetByIdAsync(string id);
        Task<ICategory> GetByHandleAsync(string handle);

        Task<IList<ICategory>> GetByRootAsync();
        Task<IList<ICategory>> GetByParentIdAsync(string parentId);
        Task<IList<ICategory>> GetBySearchAsync(string searchTerm);
    }
}