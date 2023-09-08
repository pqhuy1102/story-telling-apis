

using Business_Logic_Layer.Models;
using Data_Access_Layer;
using Data_Access_Layer.Repository.Entities;

namespace Business_Logic_Layer
{
    public class StoryBLL : IStoryBLL
    {
        private readonly IStoryDAL _storyDAL;

        public StoryBLL(IStoryDAL storyDAL)
        {
            _storyDAL = storyDAL;
        }

        public static StoryModel MapStoryEntityToStoryModel(StoryEntity storyEntity)
        {
            return new StoryModel
            {
                StoryName = storyEntity.StoryName,
                StoryId = storyEntity.StoryId,
                StoryRating = storyEntity.StoryRating,
                CategoryId = storyEntity.CategoryId,
                UserId = storyEntity.UserId,
            };
        }

        public static StoryEntity MapStoryModelToStoryEntity(StoryModel storyModel)
        {
            return new StoryEntity
            {
                StoryName = storyModel.StoryName,
                StoryId = storyModel.StoryId,
                StoryRating = storyModel.StoryRating,
                CategoryId = storyModel.CategoryId,
                UserId = storyModel.UserId,
            };
        }

        public async Task<IEnumerable<StoryModel>> GetStories()
        {
            try
            {
                var storyEntities = await _storyDAL.GetStories();
                return storyEntities.Select(MapStoryEntityToStoryModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<StoryModel>> GetStoriesByCategory(Guid cateId)
        {
            try
            {
                var storyEntities = await _storyDAL.GetStoriesByCategory(cateId);
                return storyEntities.Select(MapStoryEntityToStoryModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<StoryModel> GetStoryById(Guid Id)
        {
            try
            {
                var storyEntity = await _storyDAL.GetStoryById(Id);
                return MapStoryEntityToStoryModel(storyEntity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task PostStory(StoryModel storyModel)
        {
            try
            {
                var storyEntity = MapStoryModelToStoryEntity(storyModel);
                await _storyDAL.PostStory(storyEntity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task RemoveStory(Guid Id)
        {
            try
            {
                await _storyDAL.RemoveStory(Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<StoryModel> UpdateStory(Guid Id, StoryModel storyModel)
        {
            try
            {
                var updateStoryEntity = await _storyDAL.UpdateStory(Id, MapStoryModelToStoryEntity(storyModel));
                return MapStoryEntityToStoryModel(updateStoryEntity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
