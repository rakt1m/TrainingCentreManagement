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
using TrainingCentreManagement.Models.EntityModels.Institues;

namespace TrainingCentreManagement.Controllers
{
    [Authorize(Roles = "Admin")]
    public class InstitutesController : Controller
    {

        private readonly IInstituteManager _iInstituteManager;

        public InstitutesController(IInstituteManager iInstituteManager)
        {
            _iInstituteManager = iInstituteManager;
        }

        public IActionResult Index()
        {
            var institutes = _iInstituteManager.GetAll().ToList();
            return View(institutes);
        }

        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var institutes = _iInstituteManager.GetById(id);
            if (institutes == null)
            {
                return NotFound();
            }

            return View(institutes);
        }


        // GET: Trainees/Create
        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Institute institute)
        {
            if (ModelState.IsValid)
            {
                institute.CreatedAt = DateTime.Now;
                institute.UpdatedAt = DateTime.Now;
                _iInstituteManager.Add(institute);
                return RedirectToAction(nameof(Index));
            }

            return View(institute);
        }
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var institute = _iInstituteManager.GetById(id);
            if (institute == null)
            {
                return NotFound();
            }

            return View(institute);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long id, Institute institute)
        {
            if (id != institute.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    institute.UpdatedAt = DateTime.Now;
                    _iInstituteManager.Update(institute);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstituteExists(institute.Id))
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

            return View(institute);
        }
        public IActionResult Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var institute = _iInstituteManager.GetById(id);
            if (institute == null)
            {
                return NotFound();
            }

            return View(institute);
        }


        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(long id)
        {
            var institute = _iInstituteManager.GetById(id);
            _iInstituteManager.Remove(institute);

            return RedirectToAction(nameof(Index));
        }

        private bool InstituteExists(long id)
        {
            return _iInstituteManager.GetAll().Any(e => e.Id == id);
        }
    }
}
