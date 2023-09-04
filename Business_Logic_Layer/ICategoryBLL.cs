using Business_Logic_Layer.Models;


namespace Business_Logic_Layer
{
    public interface ICategoryBLL
    {
        public Task PostCategory(CategoryModel categoryModel);
        public Task<IEnumerable<CategoryModel>> GetCategories();
        public Task RemoveCategory(Guid categoryId);
        public Task<CategoryModel> UpdateCategory(Guid categoryId, CategoryModel categoryModel);
    }
}
