
using Data_Access_Layer.Repository.Entities;

namespace Data_Access_Layer
{
    public interface IChapterDAL
    {
        public Task PostChapter(ChapterEntity chapterEntity);
        public Task<IEnumerable<ChapterEntity>> GetChaptersByStory(Guid storyId);
        public Task<ChapterEntity> GetChapterDetail(Guid Id);
        public Task RemoveChapter(Guid Id);
        public Task<ChapterEntity> UpdateChapter(Guid Id, ChapterEntity chapterEntity);
    }
}
