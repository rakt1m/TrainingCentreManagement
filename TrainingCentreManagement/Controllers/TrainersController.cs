using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrainingCentreManagement.BLL.Contracts;
using TrainingCentreManagement.DatabaseContext.DatabaseContext;
using TrainingCentreManagement.Models.EntityModels.Trainers;

namespace TrainingCentreManagement.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TrainersController : Controller
    {
        private readonly ITrainerManager _iTrainerManager;

        public TrainersController(ITrainerManager iTrainerManager)
        {
            _iTrainerManager = iTrainerManager;
        }

        public IActionResult Index()
        {
            var trainers = _iTrainerManager.GetAll().ToList();
            return View(trainers);
        }

        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainers = _iTrainerManager.GetById(id);
            if (trainers == null)
            {
                return NotFound();
            }

            return View(trainers);
        }


        // GET: Trainees/Create
        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                _iTrainerManager.Add(trainer);
                return RedirectToAction(nameof(Index));
            }

            return View(trainer);
        }
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainer = _iTrainerManager.GetById(id);
            if (trainer == null)
            {
                return NotFound();
            }

            return View(trainer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long id, Trainer trainer)
        {
            if (id != trainer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _iTrainerManager.Update(trainer);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrainerExists(trainer.Id))
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

            return View(trainer);
        }
        public IActionResult Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainer = _iTrainerManager.GetById(id);
            if (trainer == null)
            {
                return NotFound();
            }

            return View(trainer);
        }


        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(long id)
        {
            var trainer = _iTrainerManager.GetById(id);
            _iTrainerManager.Remove(trainer);

            return RedirectToAction(nameof(Index));
        }

        private bool TrainerExists(long id)
        {
            return _iTrainerManager.GetAll().Any(e => e.Id == id);
        }
    }
}
