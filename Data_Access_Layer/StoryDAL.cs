
using Data_Access_Layer.Repository.Context;
using Data_Access_Layer.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data_Access_Layer
{
    public class StoryDAL : IStoryDAL
    {

        private readonly StoryTellingContext _storyTellingContext;

        public StoryDAL(StoryTellingContext storyTellingContext)
        {
            _storyTellingContext = storyTellingContext;
        }

        public async Task<IEnumerable<StoryEntity>> GetStories()
        {
            try
            {
                return await _storyTellingContext.Stories.ToListAsync();
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<IEnumerable<StoryEntity>> GetStoriesByCategory(Guid cateId)
        {
            try
            {
                return await _storyTellingContext.Stories.Where(x => x.CategoryId == cateId).ToListAsync();
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<StoryEntity> GetStoryById(Guid Id)
        {
            var story = await _storyTellingContext.Stories.FirstOrDefaultAsync(x => x.StoryId == Id);
            if (story != null)
            {
                return story;
            }
            else
            {
                throw new ArgumentException($"Could not find this story!");
            }
        }

        public async Task PostStory(StoryEntity storyEntity)
        {
            await _storyTellingContext.Stories.AddAsync(storyEntity);
            await _storyTellingContext.SaveChangesAsync();
        }

        public async Task RemoveStory(Guid Id)
        {
            var removeStory = _storyTellingContext.Stories.FirstOrDefault(x => x.StoryId == Id);
            if (removeStory != null)
            {
                _storyTellingContext.Stories.Remove(removeStory);
                await _storyTellingContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException($"Could not remove story: Story not found!");
            }
        }

        public async Task<StoryEntity> UpdateStory(Guid Id, StoryEntity storyEntity)
        {
            var existingStory = _storyTellingContext.Stories.FirstOrDefault(c => c.StoryId == Id);
            if (existingStory != null)
            {
                existingStory.StoryName = storyEntity.StoryName;
                await _storyTellingContext.SaveChangesAsync();
                return existingStory;
            }
            else
            {
                throw new ArgumentException($"Could not update story: Story not found!");
            }
        }
    }
}
