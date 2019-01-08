using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrainingCentreManagement.BLL.Contracts;
using TrainingCentreManagement.DatabaseContext.DatabaseContext;

using TrainingCentreManagement.Models.EntityModels;

namespace TrainingCentreManagement.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CoursesController : Controller
    {
        private readonly ICourseManager _iCourseManager;

        private readonly ICategoryManager _iCategoryManager;

        public CoursesController(ICourseManager iCourseManager, ICategoryManager iCategoryManager)
        {
            _iCourseManager = iCourseManager;
            _iCategoryManager = iCategoryManager;

        }

        // GET: Courses
        public IActionResult Index()
        {
            return View(_iCourseManager.GetAll().ToList());
        }

        // GET: Courses/Details/5
        public IActionResult Details(int id)
        {


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

            ViewBag.CategoryId = _iCategoryManager.GetAll()
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();
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

            ViewBag.CategoryId = _iCategoryManager.GetAll()
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();

            return View(course);
        }

        // GET: Courses/Edit/5
        public IActionResult Edit(int id)
        {


            var course = _iCourseManager.GetById(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]


        public IActionResult Edit(int id,Course course)

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
            return View(course);
        }

        // GET: Courses/Delete/5
        public IActionResult Delete(int id)
        {

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
        public IActionResult DeleteConfirmed(int id)
        {
            var course = _iCourseManager.GetById(id);
            _iCourseManager.Remove(course);
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(int id)
        {
            return _iCourseManager.GetAll().Any(e => e.Id == id);
        }
    }
}
