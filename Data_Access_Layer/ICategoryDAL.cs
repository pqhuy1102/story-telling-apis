using Data_Access_Layer.Repository.Entities;

namespace Data_Access_Layer
{
    public interface ICategoryDAL
    {
        public Task PostCategory(CategoryEntity categoryEntity);
        public Task<IEnumerable<CategoryEntity>> GetCategories();
        public Task RemoveCategory(Guid categoryId);
        public Task<CategoryEntity> UpdateCategory(Guid categoryId, CategoryEntity categoryEntity);
    }
}
