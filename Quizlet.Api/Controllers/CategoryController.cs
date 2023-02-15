using Microsoft.AspNetCore.Mvc;
using Quizlet.Core.Contracts;
using Quizlet.Core.Models.Return;
using Quizlet.Infrastructure.Data.Models;

namespace Quizlet.Api.Controllers
{
    [Route("Categories")]
    public class CategoryController : BaseController
    {
        private readonly ICategoryService service;

        public CategoryController(ICategoryService _service)
        {
            this.service = _service;
        }

        [HttpPost(nameof(Create))]
        public async Task<IActionResult> Create(string name)
        {
            var result = await service.Create(new Category
            {
                Name = name
            });

            if (result != null)
                return CreatedAtAction(nameof(Create), result);

            return BadRequest(new FailReturnModel());
        }

        [HttpPost(nameof(Edit))]
        public async Task<IActionResult> Edit(string name)
        {
            var result = await service.Edit(new Category
            {
                Name = name
            });

            if (result != null)
                return Ok(result);

            return BadRequest(new FailReturnModel());
        }

        [HttpGet($"{nameof(Delete)}/{{id}}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await service.Remove(id);

            if (result)
                return Ok(new SuccessReturnModel());

            return NotFound(new FailReturnModel());
        }
    }
}
