
namespace Business_Logic_Layer.Models
{
    public class CategoryModel
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public virtual ICollection<StoryModel>? Stories { get; set; }
    }
}
