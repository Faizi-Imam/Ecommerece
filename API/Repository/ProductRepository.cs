using AutoMapper;
using ecommerce.Context;
using ecommerce.Data;
using ecommerce.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductsDbContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(ProductsDbContext context,IMapper mapper) 
        {
           _context = context;
            _mapper = mapper;
        }

        public async Task<int> AddProductAsync(EntityModel entityModel)
        {
            var newproduct = new Entities()
            {
                id = entityModel.id,
                name = entityModel.name
            };
            _context.Products.Add(newproduct);
            await _context.SaveChangesAsync();
            return newproduct.id;
        }

        public async Task<IReadOnlyList<EntityModel>> GetAllProductsAsync()
        {
            // return await _context.Products.
            //  Select(x => new EntityModel()
            //  {
            //      id = x.id,
            //      name = x.name,
            //  }).ToListAsync();
            var products=await _context.Products.ToListAsync();
            return _mapper.Map<IReadOnlyList<EntityModel>>(products);
        }

        public async Task<EntityModel> GetProductByIdAsync(int id)

        {
            // return await _context.Products.Where(x => x.id == id).
            //  Select(x => new EntityModel()
            //  {
            //      id = x.id,
            //      name = x.name,
            //  }).
            //  FirstOrDefaultAsync();

            var product=await _context.Products.FindAsync(id);
            return _mapper.Map<EntityModel>(product);

        }
        public async Task UpdateProductAsync(int id, EntityModel model)
        {
            // var productupdated=await _context.Products.FindAsync(id);
            // if(productupdated!=null)
            // {
            //     productupdated.id=model.id;
            //     productupdated.name=model.name;
            //     await _context.SaveChangesAsync();
            // }

            var newproduct = new Entities()
            {
                id = model.id,
                name = model.name,
            };
            _context.Products.Update(newproduct);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProductPatchAsync(int id, JsonPatchDocument model)
        {
            var productupdated=await _context.Products.FindAsync(id);
            if(productupdated != null)
            {
                model.ApplyTo(productupdated);
                await _context.SaveChangesAsync();
            }

        }
        public async Task DeleteProductAsync(int id)
        {
            var deletedproduct = new Entities()
            {
                id = id,
            };
            _context.Products.Remove(deletedproduct);
            await _context.SaveChangesAsync();
            
        }


    }
}