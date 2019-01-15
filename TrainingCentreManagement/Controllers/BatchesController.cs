using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrainingCentreManagement.DatabaseContext.DatabaseContext;
using TrainingCentreManagement.Models.EntityModels.Batches;
using TrainingCentreManagement.Models.EntityModels.Trainings;

namespace TrainingCentreManagement.Controllers
{
      [Authorize(Roles = "Admin")]
    public class BatchesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BatchesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Batches
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Batches.Include(b => b.BatchSchedule).Include(b => b.Training);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Batches/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batch = await _context.Batches
                .Include(b => b.BatchSchedule)
                .Include(b => b.Training)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (batch == null)
            {
                return NotFound();
            }

            return View(batch);
        }

        // GET: Batches/Create
        public IActionResult Create()
        {
            ViewData["BatchScheduleId"] = new SelectList(_context.Set<BatchSchedule>(), "Id", "Discriminator");
            ViewData["TrainingId"] = new SelectList(_context.Set<Training>(), "Id", "Discriminator");
            return View();
        }

        // POST: Batches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,IsNameDisplayed,EntityDescription,Description,TotalCapacity,RegistrationStart,RegistrationEnd,TrainingStart,BatchScheduleId,TrainingId,IsFree,Fee,CreatedAt,UpdatedAt")] Batch batch)
        {
            if (ModelState.IsValid)
            {
                _context.Add(batch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BatchScheduleId"] = new SelectList(_context.Set<BatchSchedule>(), "Id", "Discriminator", batch.BatchScheduleId);
            ViewData["TrainingId"] = new SelectList(_context.Set<Training>(), "Id", "Discriminator", batch.TrainingId);
            return View(batch);
        }

        // GET: Batches/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batch = await _context.Batches.FindAsync(id);
            if (batch == null)
            {
                return NotFound();
            }
            ViewData["BatchScheduleId"] = new SelectList(_context.Set<BatchSchedule>(), "Id", "Discriminator", batch.BatchScheduleId);
            ViewData["TrainingId"] = new SelectList(_context.Set<Training>(), "Id", "Discriminator", batch.TrainingId);
            return View(batch);
        }

        // POST: Batches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,IsNameDisplayed,EntityDescription,Description,TotalCapacity,RegistrationStart,RegistrationEnd,TrainingStart,BatchScheduleId,TrainingId,IsFree,Fee,CreatedAt,UpdatedAt")] Batch batch)
        {
            if (id != batch.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(batch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BatchExists(batch.Id))
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
            ViewData["BatchScheduleId"] = new SelectList(_context.Set<BatchSchedule>(), "Id", "Discriminator", batch.BatchScheduleId);
            ViewData["TrainingId"] = new SelectList(_context.Set<Training>(), "Id", "Discriminator", batch.TrainingId);
            return View(batch);
        }

        // GET: Batches/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batch = await _context.Batches
                .Include(b => b.BatchSchedule)
                .Include(b => b.Training)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (batch == null)
            {
                return NotFound();
            }

            return View(batch);
        }

        // POST: Batches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var batch = await _context.Batches.FindAsync(id);
            _context.Batches.Remove(batch);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BatchExists(long id)
        {
            return _context.Batches.Any(e => e.Id == id);
        }
    }
}
