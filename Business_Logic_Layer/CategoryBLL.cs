using Business_Logic_Layer.Models;
using Data_Access_Layer;
using Data_Access_Layer.Repository.Entities;

namespace Business_Logic_Layer
{
    public class CategoryBLL : ICategoryBLL
    {
        private readonly ICategoryDAL _categoryDAL;

        public CategoryBLL(ICategoryDAL categoryDAL)
        {
            _categoryDAL = categoryDAL;
        }

        public static CategoryModel MapCategoryEntityToCategoryModel(CategoryEntity categoryEntity)
        {
            return new CategoryModel
            {
                CategoryName = categoryEntity.CategoryName,
                CategoryId = categoryEntity.CategoryId
            };
        }

        public static CategoryEntity MapCategoryModelToCategoryEntity(CategoryModel categoryModel)
        {
            return new CategoryEntity
            {
                CategoryName = categoryModel.CategoryName,
                CategoryId = categoryModel.CategoryId
            };
        }

        public async Task<IEnumerable<CategoryModel>> GetCategories()
        {
            try
            {
                var categoryEntities = await _categoryDAL.GetCategories();
                return categoryEntities.Select(MapCategoryEntityToCategoryModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task PostCategory(CategoryModel categoryModel)
        {
            try
            {
                var categoryEntity = MapCategoryModelToCategoryEntity(categoryModel);
                await _categoryDAL.PostCategory(categoryEntity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task RemoveCategory(Guid categoryId)
        {
            try
            {
                await _categoryDAL.RemoveCategory(categoryId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CategoryModel> UpdateCategory(Guid categoryId, CategoryModel categoryModel)
        {
            try
            {
                var updateCategoryEntity = await _categoryDAL.UpdateCategory(categoryId, MapCategoryModelToCategoryEntity(categoryModel));
                return MapCategoryEntityToCategoryModel(updateCategoryEntity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
