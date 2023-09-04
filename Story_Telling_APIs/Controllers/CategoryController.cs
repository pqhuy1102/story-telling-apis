using Business_Logic_Layer;
using Business_Logic_Layer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Story_Telling_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryBLL _categoryBLL;

        public CategoryController(ICategoryBLL categoryBLL)
        {
            _categoryBLL = categoryBLL;
        }

        [HttpPost("postCategory"), Authorize(Roles = "Admin")]
        public async Task<ActionResult> PostCategory(CategoryModel categoryModel)
        {
            try
            {
                if (categoryModel == null)
                {
                    return BadRequest(new CommonResponseModel<object>
                    {
                        status = "Failed!",
                        message = "Category is null!"
                    });
                }
                if (categoryModel.CategoryName == null)
                {
                    return BadRequest(new CommonResponseModel<object>
                    {
                        status = "Failed!",
                        message = "Category name is null!"
                    });
                }
                await _categoryBLL.PostCategory(categoryModel);
                return Ok(new CommonResponseModel<object>
                {
                    status = "Success!",
                    message = "Create category successfully!",
                    Data = categoryModel.CategoryName
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

        [HttpGet("getAllCategories")]
        public async Task<ActionResult<IEnumerable<CategoryModel>>> GetAllCategories()
        {
            try
            {
                return Ok(await _categoryBLL.GetCategories());
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

        [HttpDelete("removeCategoryById"), Authorize(Roles = "Admin")]
        public async Task<ActionResult> RemoveCategoryById(Guid Id)
        {
            try
            {
                await _categoryBLL.RemoveCategory(Id);
                return Ok(new CommonResponseModel<object>
                {
                    status = "Success!",
                    message = "Remove category successfully!"
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

        [HttpPut("updateCategory"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<CategoryModel>> UpdateCategory(Guid categoryId, CategoryModel categoryModel)
        {
            try
            {
                var updateCategory = await _categoryBLL.UpdateCategory(categoryId, categoryModel);
                return Ok(new CommonResponseModel<CategoryModel>
                {
                    status = "Success!",
                    message = "Update category successfull!",
                    Data = updateCategory
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
