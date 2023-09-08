

using Business_Logic_Layer.Models;

namespace Business_Logic_Layer
{
    public interface IChapterBLL
    {
        public Task PostChapter(ChapterModel chapterModel);
        public Task<IEnumerable<ChapterModel>> GetChaptersByStory(Guid storyId);
        public Task<ChapterModel> GetChapterDetail(Guid Id);
        public Task RemoveChapter(Guid Id);
        public Task<ChapterModel> UpdateChapter(Guid Id, ChapterModel chapterModel);
    }
}
