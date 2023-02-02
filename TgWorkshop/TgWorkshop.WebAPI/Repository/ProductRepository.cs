using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TgWorkshop.WebAPI.DBContexts;
using TgWorkshop.WebAPI.Models;
using System;
using NuGet.Protocol;
using Newtonsoft.Json;

namespace TgWorkshop.WebAPI.Repository
{
    public class ProductRepository : IProductRepository

    {
        private readonly ProductContext _dbContext;

        public ProductRepository(ProductContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product> Add(Product product)
        {

            var addedEntity = _dbContext.Entry(product);
            addedEntity.State = EntityState.Added;
            await _dbContext.SaveChangesAsync();
            return product;

        }
    

    public async Task Delete(Product product)
        {
          
                var deletedEntity = _dbContext.Entry(product);
                deletedEntity.State = EntityState.Deleted;
                await _dbContext.SaveChangesAsync();

         }

public async Task<Product> Get(Expression<Func<Product, bool>> filter)
    {
            return _dbContext.Set<Product>().FirstOrDefault(filter);
        }

    public async Task<IEnumerable<Product>> GetAll(Expression<Func<Product, bool>> filter = null)
    {

        return filter == null
        ? await _dbContext.Set<Product>().ToListAsync()
        : await _dbContext.Set<Product>().Where(filter).ToListAsync();

    }



    public async Task<Product> Update(Product product)
        {
                _dbContext.Update(product);
                await _dbContext.SaveChangesAsync();
                return product;
           
            /* var updatedEntity = context.Entry(entity);
             updatedEntity.State = EntityState.Modified;*/
           

    }

   }

 }