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
using TrainingCentreManagement.Models.EntityModels.Master;
using TrainingCentreManagement.Models.EntityModels.Trainings;

namespace TrainingCentreManagement.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CoursesController : Controller
    {
        private readonly ITrainingManager _iTrainingManager;
        private readonly ICourseManager _iCourseManager;
        private readonly ITrainingTypeManager _iTrainingTypeManager;

        public CoursesController(ITrainingManager iTrainingManager,ITrainingTypeManager iTrainingTypeManager,ICourseManager iCourseManager)
        {
            _iTrainingManager = iTrainingManager;
            _iTrainingTypeManager = iTrainingTypeManager;
            _iCourseManager = iCourseManager;
        }

        // GET: Courses
        public IActionResult Index()
        {
            var courses = _iCourseManager.GetAll().ToList();
            return View(courses);
        }

        // GET: Courses/Details/5
        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = _iCourseManager.GetById(id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            ViewData["TrainingTypeId"] = new SelectList(_iTrainingTypeManager.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                _iCourseManager.Add(course);
                return RedirectToAction(nameof(Index));
            }
            ViewData["TrainingTypeId"] = new SelectList(_iTrainingTypeManager.GetAll(), "Id", "Name", course.TrainingTypeId);
            return View(course);
        }

        // GET: Courses/Edit/5
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course =_iCourseManager.GetById(id);
            if (course == null)
            {
                return NotFound();
            }
            ViewData["TrainingTypeId"] = new SelectList(_iTrainingTypeManager.GetAll(), "Id", "Name", course.TrainingTypeId);
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long id, Course course)
        {
            if (id != course.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _iCourseManager.Update(course);
                   
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.Id))
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
            ViewData["TrainingTypeId"] = new SelectList(_iTrainingTypeManager.GetAll(), "Id", "Name", course.TrainingTypeId);
            return View(course);
        }

        // GET: Courses/Delete/5
        public IActionResult Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = _iCourseManager.GetById(id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(long id)
        {
            var course = _iCourseManager.GetById(id);
            _iCourseManager.Remove(course);
          
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(long id)
        {
            return _iCourseManager.GetAll().Any(e => e.Id == id);
        }
    }
}
