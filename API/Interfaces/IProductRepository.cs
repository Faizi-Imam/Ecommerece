using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerce.Data;
using Microsoft.AspNetCore.JsonPatch;

namespace ecommerce.Interfaces
{
    public interface IProductRepository
    {
        Task<IReadOnlyList<EntityModel>> GetAllProductsAsync();
        Task<EntityModel> GetProductByIdAsync(int id);

        Task<int> AddProductAsync(EntityModel entityModel);

        Task UpdateProductAsync(int id,EntityModel model);

        Task UpdateProductPatchAsync(int id, JsonPatchDocument model);

        Task DeleteProductAsync(int id);

        
    }
}