using Microsoft.AspNetCore.Mvc;
using Quizlet.Core.Contracts;
using Quizlet.Core.Models.Quiz;
using Quizlet.Core.Models.Return;

namespace Quizlet.Api.Controllers
{
    [Route("Quizes")]
    public class QuizController : BaseController
    {
        private readonly IQuizService service;

        public QuizController(IQuizService _service)
        {
            this.service = _service;
        }

        [HttpPost(nameof(Create))]
        public async Task<IActionResult> Create(QuizCreateModel data)
        {
            var result = await service.Create(data);

            if (result != null)
                return CreatedAtAction(nameof(Create), result);

            return BadRequest(new FailReturnModel());
        }

        [HttpPost(nameof(Edit))]
        public async Task<IActionResult> Edit(QuizEditModel data)
        {
            var result = await service.Edit(data);

            if (result != null)
                return Ok(result);

            return BadRequest(new FailReturnModel());
        }

        [HttpGet($"{nameof(Delete)}/{{id}}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await service.Remove(id);

            if (result)
                return Ok(new SuccessReturnModel());

            return BadRequest(new FailReturnModel());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            //FIX DEPTH
            var result = await service.GetById(id);

            if (result != null)
                return Ok(result);

            return NotFound(new FailReturnModel());
        }

        [HttpGet(nameof(All))]
        public async Task<IActionResult> All()
        {
            var result = await service.GetAll();

            if (result.Count > 0)
                return Ok(result);

            return NotFound(new FailReturnModel());
        }
    }
}
