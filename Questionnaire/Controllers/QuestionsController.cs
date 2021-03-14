using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Questionnaire.Core.RequestModels;
using Questionnaire.Services;

namespace Questionnaire.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        public QuestionsController(IQuestionService questionService)
        {
            _questionService = questionService;
        }
        [HttpGet]
        public IActionResult GetAllAsync()
        {
            return Ok(_questionService.GetAll());
            
        }

        [HttpPost]
        public IActionResult PostAsync(UserAnswers userAnswers)
        {
            return Ok(_questionService.Save(userAnswers));
        }
    }
}
