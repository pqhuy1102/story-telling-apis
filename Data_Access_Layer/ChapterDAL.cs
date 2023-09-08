
using Data_Access_Layer.Repository.Context;
using Data_Access_Layer.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data_Access_Layer
{
    public class ChapterDAL : IChapterDAL
    {
        private readonly StoryTellingContext _storyTellingContext;

        public ChapterDAL(StoryTellingContext storyTellingContext)
        {
            _storyTellingContext = storyTellingContext;
        }

        public async Task<ChapterEntity> GetChapterDetail(Guid Id)
        {
            var chapter = await _storyTellingContext.Chapters.FirstOrDefaultAsync(x => x.ChapterId == Id);
            if (chapter != null)
            {
                return chapter;
            }
            else
            {
                throw new ArgumentException($"Could not find this chapter!");
            }
        }

        public async Task<IEnumerable<ChapterEntity>> GetChaptersByStory(Guid storyId)
        {
            try
            {
                return await _storyTellingContext.Chapters.Where(x => x.StoryId == storyId).ToListAsync();
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task PostChapter(ChapterEntity chapterEntity)
        {
            await _storyTellingContext.Chapters.AddAsync(chapterEntity);
            await _storyTellingContext.SaveChangesAsync();
        }

        public async Task RemoveChapter(Guid Id)
        {
            var removeChapter = _storyTellingContext.Chapters.FirstOrDefault(x => x.ChapterId == Id);
            if (removeChapter != null)
            {
                _storyTellingContext.Chapters.Remove(removeChapter);
                await _storyTellingContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException($"Could not remove chapter: Chapter not found!");
            }
        }

        public async Task<ChapterEntity> UpdateChapter(Guid Id, ChapterEntity chapterEntity)
        {
            var existingChapter = _storyTellingContext.Chapters.FirstOrDefault(c => c.ChapterId == Id);
            if (existingChapter != null)
            {
                existingChapter.ChapterName = chapterEntity.ChapterName;
                existingChapter.Content = chapterEntity.Content;
                await _storyTellingContext.SaveChangesAsync();
                return existingChapter;
            }
            else
            {
                throw new ArgumentException($"Could not update chapter: chapter not found!");
            }
        }
    }
}
