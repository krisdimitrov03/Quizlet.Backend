using Microsoft.AspNetCore.Mvc;
using Quizlet.Core.Contracts;
using Quizlet.Core.Models;
using Quizlet.Infrastructure.Data.Models;

namespace Quizlet.Api.Controllers
{
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

            return BadRequest();
        }
    }
}
