using Microsoft.EntityFrameworkCore;
using TelerikBlazorEF.Data;

namespace TelerikBlazorEF.Services
{
    public class CategoryService
    {
        private readonly IDbContextFactory<EfDbContext> _contextFactory;

        public async Task<List<Category>> GetCategoriesAsync()
        {
            using (var dbContext = await _contextFactory.CreateDbContextAsync())
            {
                return dbContext.Categories.ToList();
            }
        }

        public async Task UpdateCategoryAsync(Category updatedCategory)
        {
            using (var dbContext = await _contextFactory.CreateDbContextAsync())
            {
                var CategoryToUpdate = dbContext.Categories.FirstOrDefault(x => x.Id == updatedCategory.Id);

                if (CategoryToUpdate != null)
                {
                    CategoryToUpdate.Name = updatedCategory.Name;

                    await dbContext.SaveChangesAsync();
                }
            }
        }

        public async Task<int> CreateCategoryAsync(Category newCategory)
        {
            using (var dbContext = await _contextFactory.CreateDbContextAsync())
            {
                dbContext.Categories.Add(newCategory);

                await dbContext.SaveChangesAsync();

                return newCategory.Id;
            }
        }

        public async Task DeleteCategoryAsync(Category Category)
        {
            using (var dbContext = await _contextFactory.CreateDbContextAsync())
            {
                var CategoryToDelete = dbContext.Categories.FirstOrDefault(x => x.Id == Category.Id);

                if (CategoryToDelete != null)
                {
                    dbContext.Categories.Remove(CategoryToDelete);

                    await dbContext.SaveChangesAsync();
                }
            }
        }

        public CategoryService(IDbContextFactory<EfDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
    }
}
