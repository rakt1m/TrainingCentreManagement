using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrainingCentreManagement.BLL.Contracts;
using TrainingCentreManagement.BLL.Managers;
using TrainingCentreManagement.DatabaseContext.DatabaseContext;
using TrainingCentreManagement.Models.EntityModels.Batches;
using TrainingCentreManagement.Models.EntityModels.Trainings;

namespace TrainingCentreManagement.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BatchController : Controller
    {
        private readonly IBatchManager _iBatchManager;
        private readonly IBatchTrainerManager _iBatchTrainerManager;
        private readonly IScedhuleTypeManager _IScedhuleTypeManager;

        public BatchController(IBatchManager iBatchManager, IBatchTrainerManager iBatchTrainerManager, IScedhuleTypeManager iScedhuleTypeManager)
        {
            _iBatchManager = iBatchManager;
            _iBatchTrainerManager = iBatchTrainerManager;
            _IScedhuleTypeManager = iScedhuleTypeManager;
        }
        // GET: Batches
        public IActionResult Index()
        {
            var batches = _iBatchManager.GetAll().ToList();
            return View(batches);
        }

        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batches = _iBatchManager.GetById(id);
            if (batches == null)
            {
                return NotFound();
            }

            return View(batches);
        }

        public IActionResult Create()
        {
            ViewData["BatchScheduleId"] = new SelectList(_IScedhuleTypeManager.GetAll(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Batch batch)
        {
            if (ModelState.IsValid)
            {
                batch.CreatedAt = DateTime.Now;
                batch.UpdatedAt = DateTime.Now;
                _iBatchManager.Add(batch);
                return RedirectToAction(nameof(Index));
            }
            ViewData["BatchScheduleId"] = new SelectList(_IScedhuleTypeManager.GetAll(), "Id", "Name", batch.BatchScheduleId);
            return View(batch);
        }


        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batch = _iBatchManager.GetById(id);
            if (batch== null)
            {
                return NotFound();
            }
            ViewData["BatchScheduleId"] = new SelectList(_IScedhuleTypeManager.GetAll(), "Id", "Name" , batch.BatchScheduleId);
            return View(batch);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long id, Batch batch)
        {
            if (id != batch.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    batch.UpdatedAt = DateTime.Now;
                    _iBatchManager.Update(batch);

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
            ViewData["BatchScheduleId"] = new SelectList(_IScedhuleTypeManager.GetAll(), "Id", "Name", batch.BatchScheduleId);
            return View(batch);
        }
        public IActionResult Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batch = _iBatchManager.GetById(id);
            if (batch == null)
            {
                return NotFound();
            }

            return View(batch);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(long id)
        {
            var course = _iBatchManager.GetById(id);
            _iBatchManager.Remove(course);

            return RedirectToAction(nameof(Index));
        }

        private bool BatchExists(long id)
        {
            return _iBatchManager.GetAll().Any(e => e.Id == id);
        }

        
    }
}
