using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AviationEducation.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AviationEducation.Controllers
{
    [Route("api/[controller]")]
    public class JsonController : Controller
    {
        private readonly AviationEducationContext _context;
        public JsonController(AviationEducationContext context)
        {
            _context = context;
        }
        // GET: api/<controller>
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(_context.Question);
        }

        // GET api/<controller>/5
        [HttpGet("question/{id}")]
        public IActionResult GetById(int? id)
        {
            if (id == null)
            {
                return Ok("Question not found. Is your url correct? /api/json/question/{question number}");
            }

            var question = _context.Question
                .FirstOrDefault(m => m.Id == id);
            if (question == null)
            {
                return Ok($"Question with id {id} not found");
            }
            return Json(question);
        }
        [HttpGet("module/{name}")]
        public IActionResult GetByModule(string name)
        {
            var question = _context.Question.Where(x => x.Module == name);
            if (question.Count() == 0)
            {
                return Ok($"Questions with module {name} not found");
            }
            return Json(question);
        }

        [HttpGet("category/{name}")]
        public IActionResult GetByCategory(string name)
        {
            var question = _context.Question.Where(x => x.Category == name);
            if (question.Count() == 0)
            {
                return Ok($"Questions with category {name} not found");
            }
            return Json(question);
        }
    }
}
