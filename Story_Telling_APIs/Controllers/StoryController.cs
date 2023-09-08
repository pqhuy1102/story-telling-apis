using Business_Logic_Layer;
using Business_Logic_Layer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Story_Telling_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoryController : ControllerBase
    {
        private readonly IStoryBLL _storyBLL;

        public StoryController(IStoryBLL storyBLL)
        {
            _storyBLL = storyBLL;
        }

        [HttpPost("postStory")]
        public async Task<ActionResult> PostStory(StoryModel storyModel)
        {
            try
            {
                if (storyModel == null)
                {
                    return BadRequest(new CommonResponseModel<object>
                    {
                        status = "Failed!",
                        message = "Story is null!"
                    });
                }
                if (storyModel.StoryName == null)
                {
                    return BadRequest(new CommonResponseModel<object>
                    {
                        status = "Failed!",
                        message = "Story name is null!"
                    });
                }
                await _storyBLL.PostStory(storyModel);
                return Ok(new CommonResponseModel<StoryModel>
                {
                    status = "Success!",
                    message = "Create story successfully!",
                    Data = storyModel
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

        [HttpGet("getAllStories")]
        public async Task<ActionResult<IEnumerable<StoryModel>>> GetAllStories()
        {
            try
            {
                return Ok(await _storyBLL.GetStories());
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

        [HttpGet("getAllStoriesByCategory")]
        public async Task<ActionResult<IEnumerable<StoryModel>>> GetAllStoriesByCategory(Guid cateId)
        {
            try
            {
                return Ok(await _storyBLL.GetStoriesByCategory(cateId));
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

        [HttpGet("getStoryById")]
        public async Task<ActionResult<StoryModel>> GetStoryById(Guid Id)
        {
            try
            {
                var story = await _storyBLL.GetStoryById(Id);
                return Ok(new CommonResponseModel<StoryModel>
                {
                    status = "Success!",
                    message = "Get story successfully!",
                    Data = story
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

        [HttpDelete("removeStoryById")]
        public async Task<ActionResult> RemoveStoryById(Guid Id)
        {
            try
            {
                await _storyBLL.RemoveStory(Id);
                return Ok(new CommonResponseModel<object>
                {
                    status = "Success!",
                    message = "Remove story successfully!"
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

        [HttpPut("updateStory")]
        public async Task<ActionResult<StoryModel>> UpdateStory(Guid Id, StoryModel storyModel)
        {
            try
            {
                var updateStory = await _storyBLL.UpdateStory(Id, storyModel);
                return Ok(new CommonResponseModel<StoryModel>
                {
                    status = "Success!",
                    message = "Update story successfull!",
                    Data = updateStory
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
