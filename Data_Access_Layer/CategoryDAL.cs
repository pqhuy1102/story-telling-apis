using Data_Access_Layer.Repository.Context;
using Data_Access_Layer.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data_Access_Layer
{
    public class CategoryDAL : ICategoryDAL
    {
        private readonly StoryTellingContext _storyTellingContext;

        public CategoryDAL(StoryTellingContext storyTellingContext)
        {
            _storyTellingContext = storyTellingContext;
        }

        public async Task<IEnumerable<CategoryEntity>> GetCategories()
        {
            try
            {
                return await _storyTellingContext.Categories.ToListAsync();
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task PostCategory(CategoryEntity categoryEntity)
        {
            var availableCategory = _storyTellingContext.Categories.Any(x => x.CategoryName == categoryEntity.CategoryName);
            if (!availableCategory)
            {
                await _storyTellingContext.Categories.AddAsync(categoryEntity);
                await _storyTellingContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException($"Could not create category: Category {categoryEntity.CategoryName} is existed!");
            }
        }

        public async Task RemoveCategory(Guid categoryId)
        {
            var removeCategory = _storyTellingContext.Categories.FirstOrDefault(x => x.CategoryId == categoryId);
            if (removeCategory != null)
            {
                _storyTellingContext.Categories.Remove(removeCategory);
                await _storyTellingContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException($"Could not remove category: Category {categoryId} not found!");
            }
        }

        public async Task<CategoryEntity> UpdateCategory(Guid categoryId, CategoryEntity categoryEntity)
        {
            var existingCategory = _storyTellingContext.Categories.FirstOrDefault(c => c.CategoryId == categoryId);
            if (existingCategory != null)
            {
                existingCategory.CategoryName = categoryEntity.CategoryName;
                await _storyTellingContext.SaveChangesAsync();
                return existingCategory;
            }
            else
            {
                throw new ArgumentException($"Could not update category: Category {categoryId} not found!");
            }
        }
    }
}
