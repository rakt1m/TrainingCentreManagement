using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using TrainingCentreManagement.BLL.Contracts;
using TrainingCentreManagement.Models.EntityModels;

namespace TIMSApp.Controllers
{
    public class InstitutesController : Controller
    {
        private readonly IInstituteManager _iInstituteManager;

        public InstitutesController(IInstituteManager iInstituteManager)
        {
            _iInstituteManager = iInstituteManager;
        }

        // GET: Institutes
        public IActionResult Index()
        {
            return View(_iInstituteManager.GetAll());
        }

        // GET: Institutes/Details/5
        public IActionResult Details(int id)
        {


            var institute = _iInstituteManager.GetById(id);
            if (institute == null)
            {
                return NotFound();
            }

            return View(institute);
        }

        // GET: Institutes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Institutes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,About,Phone,Email")] Institute institute)
        {
            if (ModelState.IsValid)
            {
                _iInstituteManager.Add(institute);
                return RedirectToAction(nameof(Index));
            }
            return View(institute);
        }

        // GET: Institutes/Edit/5
        public IActionResult Edit(int id)
        {


            var institute = _iInstituteManager.GetById(id);
            if (institute == null)
            {
                return NotFound();
            }
            return View(institute);
        }

        // POST: Institutes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,About,Phone,Email")] Institute institute)
        {
            if (id != institute.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
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

        // GET: Institutes/Delete/5
        public IActionResult Delete(int id)
        {
           

            var institute = _iInstituteManager.GetById(id);
            if (institute == null)
            {
                return NotFound();
            }

            return View(institute);
        }

        // POST: Institutes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var institute = _iInstituteManager.GetById(id);
            _iInstituteManager.Remove(institute);
            
            return RedirectToAction(nameof(Index));
        }

        private bool InstituteExists(int id)
        {
            return _iInstituteManager.GetAll().Any(e => e.Id == id);
        }
    }
}
