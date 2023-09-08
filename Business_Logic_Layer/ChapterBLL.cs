using Business_Logic_Layer.Models;
using Data_Access_Layer;
using Data_Access_Layer.Repository.Entities;

namespace Business_Logic_Layer
{
    public class ChapterBLL : IChapterBLL
    {
        private readonly IChapterDAL _chapterDAL;

        public ChapterBLL(IChapterDAL chapterDAL)
        {
            _chapterDAL = chapterDAL;
        }

        public static ChapterModel MapChapterEntityToChapterModel(ChapterEntity chapterEntity)
        {
            return new ChapterModel
            {
                ChapterName = chapterEntity.ChapterName,
                ChapterId = chapterEntity.ChapterId,
                Content = chapterEntity.Content,
                StoryId = chapterEntity.StoryId,
            };
        }

        public static ChapterEntity MapChapterModelToChapterEntity(ChapterModel chapterModel)
        {
            return new ChapterEntity
            {
                ChapterName = chapterModel.ChapterName,
                ChapterId = chapterModel.ChapterId,
                Content = chapterModel.Content,
                StoryId = chapterModel.StoryId
            };
        }

        public async Task<ChapterModel> GetChapterDetail(Guid Id)
        {
            try
            {
                var chapterEntity = await _chapterDAL.GetChapterDetail(Id);
                return MapChapterEntityToChapterModel(chapterEntity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<ChapterModel>> GetChaptersByStory(Guid storyId)
        {
            try
            {
                var chapterEntities = await _chapterDAL.GetChaptersByStory(storyId);
                return chapterEntities.Select(MapChapterEntityToChapterModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task PostChapter(ChapterModel chapterModel)
        {
            try
            {
                var chapterEntity = MapChapterModelToChapterEntity(chapterModel);
                await _chapterDAL.PostChapter(chapterEntity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task RemoveChapter(Guid Id)
        {
            try
            {
                await _chapterDAL.RemoveChapter(Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ChapterModel> UpdateChapter(Guid Id, ChapterModel chapterModel)
        {
            try
            {
                var updateChapterEntity = await _chapterDAL.UpdateChapter(Id, MapChapterModelToChapterEntity(chapterModel));
                return MapChapterEntityToChapterModel(updateChapterEntity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
