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
using TrainingCentreManagement.Models.EntityModels.Trainees;

namespace TrainingCentreManagement.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TraineesController : Controller
    {
        private readonly ITraineeManager _iTraineeManager;

        public TraineesController(ITraineeManager iTraineeManager)
        {
            _iTraineeManager = iTraineeManager;
        }
        public IActionResult Index()
        {
            var trainees = _iTraineeManager.GetAll().ToList();
            return View(trainees);
        }

        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainees = _iTraineeManager.GetById(id);
            if (trainees == null)
            {
                return NotFound();
            }

            return View(trainees);
        }
        

        // GET: Trainees/Create
        public IActionResult Create()
        {
            return View();
        }

       

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Trainee trainee)
        {
            if (ModelState.IsValid)
            {
                trainee.CreatedAt = DateTime.Now;
                trainee.UpdatedAt = DateTime.Now;
                _iTraineeManager.Add(trainee);
                return RedirectToAction(nameof(Index));
            }
            
            return View(trainee);
        }
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainee = _iTraineeManager.GetById(id);
            if (trainee == null)
            {
                return NotFound();
            }
           
            return View(trainee);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long id, Trainee trainee)
        {
            if (id != trainee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    trainee.UpdatedAt = DateTime.Now;
                    _iTraineeManager.Update(trainee);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TraineeExists(trainee.Id))
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
            
            return View(trainee);
        }
        public IActionResult Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainee = _iTraineeManager.GetById(id);
            if (trainee == null)
            {
                return NotFound();
            }

            return View(trainee);
        }


        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(long id)
        {
            var trainee = _iTraineeManager.GetById(id);
            _iTraineeManager.Remove(trainee);

            return RedirectToAction(nameof(Index));
        }

        private bool TraineeExists(long id)
        {
            return _iTraineeManager.GetAll().Any(e => e.Id == id);
        }
        
    }
}
