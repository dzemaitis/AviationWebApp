using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AviationEducation.Data;
using AviationEducation.Models;
using Microsoft.AspNetCore.Authorization;
using AviationEducation;
using AviationEducation.Helpers;

namespace AviationEducation.Controllers
{   
    [Authorize(Roles ="Administrator")]
    public class QuestionsController : Controller
    {
        private readonly AviationEducationContext _context;

        public QuestionsController(AviationEducationContext context)
        {
            _context = context;
        }

        // GET: Questions
        public async Task<IActionResult> Index(string sortOrder,
            string searchString,
            string currentFilter,
            int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["ModuleSortParm"] = sortOrder == "Module" ? "module_desc" : "Module";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;
            var questions = from s in _context.Question
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                questions = questions.Where(s => s.Question_Text.Contains(searchString)
                                       || s.Explanation.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    questions = questions.OrderByDescending(s => s.Question_Text);
                    break;
                case "Module":
                    questions = questions.OrderBy(s => s.Module);
                    break;
                case "module_desc":
                    questions = questions.OrderByDescending(s => s.Module);
                    break;
                default:
                    questions = questions.OrderBy(s => s.Question_Text);
                    break;
            }
            int pageSize = 10;
            return View(await PaginatedList<Question>.CreateAsync(questions.AsNoTracking(), pageNumber ?? 1, pageSize));
        }
        
        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }

        // GET: Questions/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Question
                .FirstOrDefaultAsync(m => m.Id == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // GET: Questions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Questions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598. Neuzdejes BIND ant Create ir EDIT, web APP -> ASP.NET Core MVC tutorial yra.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Question_Text,Option1,Option2,Option3,Answer,Explanation,Module,Category,Image")] Question question)
        {
            if (ModelState.IsValid)
            {
                _context.Add(question);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(question);
        }

        // GET: Questions/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Question.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }
            return View(question);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Question_Text,Option1,Option2,Option3,Answer,Explanation,Module,Category,Image")] Question question)
        {
            if (id != question.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(question);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionExists(question.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(question);
        }

        // GET: Questions/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Question
                .FirstOrDefaultAsync(m => m.Id == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var question = await _context.Question.FindAsync(id);
            _context.Question.Remove(question);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionExists(long id)
        {
            return _context.Question.Any(e => e.Id == id);
        }
    }
}
