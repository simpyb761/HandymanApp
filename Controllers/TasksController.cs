﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Handyman.Models;
using Microsoft.AspNetCore.Authorization;

namespace Handyman.Controllers
{
    public class TasksController : Controller
    {
        private readonly TaskContext _context;

        public TasksController(TaskContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "Admin, User")]
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
            ViewData["NameSortParam"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["CatSortParam"] = sortOrder == "Category" ? "cat_desc" : "Category";
            ViewData["SkillSortParam"] = sortOrder == "Skill" ? "skill_desc" : "Skill";
            ViewData["TimeSortParam"] = sortOrder == "Duration" ? "duration_desc" : "Duration";


            var tasks = from t in _context.Tasks
                        select t;
            if (!string.IsNullOrEmpty(searchString))
            {
                tasks = tasks.Where(s => s.TaskName.Contains(searchString));

            }

            if (!string.IsNullOrEmpty(filterCategory) && Enum.TryParse(typeof(Categories), filterCategory, out object filterEnum))
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
                case "Duration":
                    tasks = tasks.OrderBy(s => s.Duration);
                    break;
                case "duration_desc":
                    tasks = tasks.OrderByDescending(s => s.Duration);
                    break;
                default:
                    tasks = tasks.OrderBy(s => s.TaskName);
                    break;
            }
            return View(tasks);
        }
        [Authorize(Roles = "Admin, User")]
        // GET: Tasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            
            if (id == null || _context.Tasks == null)
            {
                return NotFound();
            }
            
            var tasks = await _context.Tasks
                .FirstOrDefaultAsync(m => m.Id == id);

            // Split the Steps string into an array
            string[] stepValues = tasks.Steps.Split(',');

            // Convert the array to a List<string>
            List<string> stepList = new List<string>();

            for (int i = 0; i < stepValues.Length; i++)
            {
                string currentStep = stepValues[i].Trim();
                if (currentStep.Any(char.IsDigit))
                {
                    // Display the number and the step on the same line
                    stepList.Add($"{currentStep.TrimStart('0', ' ', '.')}.");
                }
                else if (stepList.Count > 0)
                {
                    // If it doesn't contain a number, append it to the previous step
                    stepList[stepList.Count - 1] += " " + currentStep;
                }
            }

            // Pass the stepList to the view using ViewBag or ViewData
            ViewBag.StepList = stepList;

            if (tasks == null)
            {
                return NotFound();
            }

            return View(tasks);
        }

        [Authorize(Roles = "Admin")]

        // GET: Tasks/Create
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
