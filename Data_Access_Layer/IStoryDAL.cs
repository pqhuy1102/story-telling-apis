

using Data_Access_Layer.Repository.Entities;

namespace Data_Access_Layer
{
    public interface IStoryDAL
    {
        public Task PostStory(StoryEntity storyEntity);
        public Task<IEnumerable<StoryEntity>> GetStories();
        public Task<IEnumerable<StoryEntity>> GetStoriesByCategory(Guid cateId);
        public Task<StoryEntity> GetStoryById(Guid Id);
        public Task RemoveStory(Guid Id);
        public Task<StoryEntity> UpdateStory(Guid Id, StoryEntity storyEntity);
    }
}
