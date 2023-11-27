using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Handyman.Models;

namespace Handyman.Views
{
    public class TasksController : Controller
    {
        private readonly TaskContext _context;

        public TasksController(TaskContext context)
        {
            _context = context;
        }

        // GET: Tasks
        //public async Task<IActionResult> Index()
        //{
        //      return _context.Tasks != null ? 
        //                  View(await _context.Tasks.ToListAsync()) :
        //                  Problem("Entity set 'TaskContext.Tasks'  is null.");
        //}



        public async Task<IActionResult> Index(string sortOrder, string filterCategory, string searchString, int? pageNumber)
        {
            //ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParam"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["CatSortParam"] = sortOrder == "Category" ? "cat_desc" : "Category";
            ViewData["SkillSortParam"] = sortOrder == "Skill" ? "skill_desc" : "Skill";

            var tasks = from t in _context.Tasks
                            select t;
            if (!String.IsNullOrEmpty(searchString))
            {
                tasks = tasks.Where(s => s.TaskName.Contains(searchString));
                                        
            }

            if (!String.IsNullOrEmpty(filterCategory) && Enum.TryParse(typeof(Categories), filterCategory, out object filterEnum))
            {
                tasks = tasks.Where(task => task.Category == (Categories)filterEnum);
            }

            switch (sortOrder)
            {
                case "name_desc":
                    tasks = tasks.OrderByDescending(s => s.TaskName);
                    break;
                case "Category":
                    tasks = tasks.OrderBy(s => s.Category);
                    break;
                case "cat_desc":
                    tasks = tasks.OrderByDescending(s => s.Category);
                    break;
                case "Skill":
                    tasks = tasks.OrderBy(s => s.SkillLevel);
                    break;
                case "skill_desc":
                    tasks = tasks.OrderByDescending(s => s.SkillLevel);
                    break;
                default:
                    tasks = tasks.OrderBy(s => s.TaskName);
                    break;
            }
            return View(tasks);
        }

        // GET: Tasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tasks == null)
            {
                return NotFound();
            }

            var tasks = await _context.Tasks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tasks == null)
            {
                return NotFound();
            }

            return View(tasks);
        }

      

        // GET: Tasks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TaskName,Tools,Steps,Category,SkillLevel,Duration,VideoLink,EstimatedPrice")] Tasks tasks)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tasks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tasks);
        }

        // GET: Tasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tasks == null)
            {
                return NotFound();
            }

            var tasks = await _context.Tasks.FindAsync(id);
            if (tasks == null)
            {
                return NotFound();
            }
            return View(tasks);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TaskName,Tools,Steps,Category,SkillLevel,Duration,VideoLink,EstimatedPrice")] Tasks tasks)
        {
            if (id != tasks.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tasks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TasksExists(tasks.Id))
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
            return View(tasks);
        }

        // GET: Tasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tasks == null)
            {
                return NotFound();
            }

            var tasks = await _context.Tasks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tasks == null)
            {
                return NotFound();
            }

            return View(tasks);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tasks == null)
            {
                return Problem("Entity set 'TaskContext.Tasks'  is null.");
            }
            var tasks = await _context.Tasks.FindAsync(id);
            if (tasks != null)
            {
                _context.Tasks.Remove(tasks);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TasksExists(int id)
        {
          return (_context.Tasks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
