using Microsoft.EntityFrameworkCore;
using TelerikBlazorEF.Data;

namespace TelerikBlazorEF.Services
{
    public class ProductService
    {
        private readonly IDbContextFactory<EfDbContext> _contextFactory;

        public async Task<List<Product>> GetProductsAsync()
        {
            using (var dbContext = await _contextFactory.CreateDbContextAsync())
            {
                return dbContext.Products.ToList();
            }
        }

        public async Task UpdateProductAsync(Product updatedProduct)
        {
            using (var dbContext = await _contextFactory.CreateDbContextAsync())
            {
                var productToUpdate = dbContext.Products.FirstOrDefault(x => x.Id == updatedProduct.Id);

                if (productToUpdate != null)
                {
                    productToUpdate.Name = updatedProduct.Name;
                    productToUpdate.CategoryId = updatedProduct.CategoryId;

                    await dbContext.SaveChangesAsync();
                }
            }
        }

        public async Task<int> CreateProductAsync(Product newProduct)
        {
            using (var dbContext = await _contextFactory.CreateDbContextAsync())
            {
                dbContext.Products.Add(newProduct);

                await dbContext.SaveChangesAsync();

                return newProduct.Id;
            }
        }

        public async Task DeleteProductAsync(Product product)
        {
            using (var dbContext = await _contextFactory.CreateDbContextAsync())
            {
                var productToDelete = dbContext.Products.FirstOrDefault(x => x.Id == product.Id);

                if (productToDelete != null)
                {
                    dbContext.Products.Remove(productToDelete);

                    await dbContext.SaveChangesAsync();
                }
            }
        }

        public ProductService(IDbContextFactory<EfDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
    }
}
