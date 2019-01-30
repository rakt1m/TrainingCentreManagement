using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrainingCentreManagement.BLL.Contracts;
using TrainingCentreManagement.DatabaseContext.DatabaseContext;
using TrainingCentreManagement.Models.EntityModels.Trainings;

namespace TrainingCentreManagement.Controllers
{
    public class TrainingSchedulesController : Controller
    {
        private readonly ITrainingScheduleManager _iTrainingScheduleManager;

        public TrainingSchedulesController(ITrainingScheduleManager iTrainingScheduleManager)
        {
            _iTrainingScheduleManager =iTrainingScheduleManager;
        }

        // GET: TrainingSchedules
        public IActionResult Index()
        {
            return View(_iTrainingScheduleManager.GetAll());
        }

        // GET: TrainingSchedules/Details/5
        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingSchedule =_iTrainingScheduleManager.GetById(id);
            if (trainingSchedule == null)
            {
                return NotFound();
            }

            return View(trainingSchedule);
        }

        // GET: TrainingSchedules/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TrainingSchedules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TrainingSchedule trainingSchedule)
        {
            if (ModelState.IsValid)
            {
                _iTrainingScheduleManager.Add(trainingSchedule);
                return RedirectToAction(nameof(Index));
            }
            return View(trainingSchedule);
        }

        // GET: TrainingSchedules/Edit/5
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingSchedule = _iTrainingScheduleManager.GetById(id);
            if (trainingSchedule == null)
            {
                return NotFound();
            }
            return View(trainingSchedule);
        }

        // POST: TrainingSchedules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long id,TrainingSchedule trainingSchedule)
        {
            if (id != trainingSchedule.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _iTrainingScheduleManager.Update(trainingSchedule);
                   
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrainingScheduleExists(trainingSchedule.Id))
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
            return View(trainingSchedule);
        }

        // GET: TrainingSchedules/Delete/5
        public IActionResult Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingSchedule = _iTrainingScheduleManager.GetById(id);
            if (trainingSchedule == null)
            {
                return NotFound();
            }

            return View(trainingSchedule);
        }

        // POST: TrainingSchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(long id)
        {
            var trainingSchedule = _iTrainingScheduleManager.GetById(id);
            _iTrainingScheduleManager.Remove(trainingSchedule);
            return RedirectToAction(nameof(Index));
        }

        private bool TrainingScheduleExists(long id)
        {
            return _iTrainingScheduleManager.GetAll().Any(e => e.Id == id);
        }
    }
}

