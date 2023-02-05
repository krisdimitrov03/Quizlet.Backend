using Microsoft.AspNetCore.Mvc;
using Quizlet.Core.Models;

namespace Quizlet.Api.Controllers
{
    public class QuizController : BaseController
    {
        [HttpPost(nameof(Create))]
        public async Task<IActionResult> Create(QuizCreateModel data)
        {
            return Ok();
        }
    }
}
