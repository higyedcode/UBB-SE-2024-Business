using Backend.Models;
using Iss.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApi_ISS.Entity;
using RestApi_ISS.Service;

namespace RestApi_ISS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FAQController : ControllerBase
    {
        private readonly IFAQService faqService;

        public FAQController(IFAQService service)
        {
            this.faqService = service;
        }

        [HttpGet("GetAllFAQs")]
        public IActionResult GetAllFAQs()
        {
            try
            {
                var faqs = faqService.GetAllFAQs();
                return Ok(faqs);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpGet("GetSubmittedQuestions")]
        public IActionResult GetSubmittedQuestions()
        {
            try
            {
                var submittedQuestions = faqService.GetSubmittedQuestions();
                return Ok(submittedQuestions);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpPost("AddSubmittedQuestion")]
        public IActionResult AddSubmittedQuestion([FromBody] FAQ newQuestion)
        {
            try
            {
                if (newQuestion == null)
                {
                    return BadRequest("FAQ question is null");
                }

                faqService.AddSubmittedQuestion(newQuestion);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpPut("FilterFAQs")]
        public IActionResult FilterFAQs([FromQuery] string searchText)
        {
            try
            {
                var faqs = faqService.FilterFAQs(faqService.GetAllFAQs(), searchText);
                return Ok(faqs);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
    }
}
