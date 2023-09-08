using Business_Logic_Layer;
using Business_Logic_Layer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Story_Telling_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChapterController : ControllerBase
    {
        private readonly IChapterBLL _chapterBLL;

        public ChapterController(IChapterBLL chapterBLL)
        {
            _chapterBLL = chapterBLL;
        }

        [HttpPost("postChapter")]
        public async Task<ActionResult> PostChapter(ChapterModel chapterModel)
        {

            try
            {
                if (chapterModel == null)
                {
                    return BadRequest(new CommonResponseModel<object>
                    {
                        status = "Failed!",
                        message = "Chapter is null!"
                    });
                }
                else
                {
                    await _chapterBLL.PostChapter(chapterModel);
                    return Ok(new CommonResponseModel<ChapterModel>
                    {
                        status = "Success!",
                        message = "Create story successfully!",
                        Data = chapterModel
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new CommonResponseModel<object>
                {
                    status = "Failed!",
                    message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpGet("getAllChaptersByStory")]
        public async Task<ActionResult<IEnumerable<ChapterModel>>> GetAllChaptersByStory(Guid storyId)
        {
            try
            {
                return Ok(await _chapterBLL.GetChaptersByStory(storyId));
            }
            catch (Exception ex)
            {
                return BadRequest(new CommonResponseModel<object>
                {
                    status = "Failed!",
                    message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpGet("getChapterById")]
        public async Task<ActionResult<ChapterModel>> GetChapterById(Guid Id)
        {
            try
            {
                var chapter = await _chapterBLL.GetChapterDetail(Id);
                return Ok(new CommonResponseModel<ChapterModel>
                {
                    status = "Success!",
                    message = "Get story successfully!",
                    Data = chapter
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new CommonResponseModel<object>
                {
                    status = "Failed!",
                    message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpDelete("removeChapterById")]
        public async Task<ActionResult> RemoveChapterById(Guid Id)
        {
            try
            {
                await _chapterBLL.RemoveChapter(Id);
                return Ok(new CommonResponseModel<object>
                {
                    status = "Success!",
                    message = "Remove chapter successfully!"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new CommonResponseModel<object>
                {
                    status = "Failed!",
                    message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpPut("updateChapter")]
        public async Task<ActionResult<ChapterModel>> UpdateChapter(Guid Id, ChapterModel chapterModel)
        {
            try
            {
                var updateChapter = await _chapterBLL.UpdateChapter(Id, chapterModel);
                return Ok(new CommonResponseModel<ChapterModel>
                {
                    status = "Success!",
                    message = "Update chapter successfull!",
                    Data = updateChapter
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new CommonResponseModel<object>
                {
                    status = "Failed!",
                    message = ex.Message,
                    Data = null
                });
            }
        }

    }
}
