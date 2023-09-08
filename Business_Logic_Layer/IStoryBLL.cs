using Business_Logic_Layer.Models;

namespace Business_Logic_Layer
{
    public interface IStoryBLL
    {
        public Task PostStory(StoryModel storyModel);
        public Task<IEnumerable<StoryModel>> GetStories();
        public Task<IEnumerable<StoryModel>> GetStoriesByCategory(Guid cateId);
        public Task<StoryModel> GetStoryById(Guid Id);
        public Task RemoveStory(Guid Id);
        public Task<StoryModel> UpdateStory(Guid Id, StoryModel storyModel);
    }
}
