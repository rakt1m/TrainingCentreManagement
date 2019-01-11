using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainingCentreManagement.BLL.Contracts;
using TrainingCentreManagement.Models.EntityModels;
using TrainingCentreManagement.Models.ViewModels;

namespace TrainingCentreManagement.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TraineesController : Controller
    {
        private readonly ITraineeManager _iTraineeManager;
        private readonly ICourseManager _iCourseManager;

        public TraineesController(ITraineeManager iTraineeManager,ICourseManager iCourseManager)
        {
            _iTraineeManager = iTraineeManager;
            _iCourseManager = iCourseManager;
        }

        // GET: Trainees
        public IActionResult Index()
        {
            return View(_iTraineeManager.GetAll().ToList());
        }

        // GET: Trainees/Details/5
        public IActionResult Details(int id)
        {
           

            var trainee = _iTraineeManager.GetById(id);
            if (trainee == null)
            {
                return NotFound();
            }

            return View(trainee);
        }

        // GET: Trainees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trainees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Email,Phone,Address")] Trainee trainee)
        {
            if (ModelState.IsValid)
            {
                _iTraineeManager.Add(trainee);
               
                return RedirectToAction(nameof(Index));
            }
            return View(trainee);
        }

        // GET: Trainees/Edit/5
        public IActionResult Edit(int id)
        {
            

            var trainee = _iTraineeManager.GetById(id);
            if (trainee == null)
            {
                return NotFound();
            }
            return View(trainee);
        }

        // POST: Trainees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Email,Phone,Address")] Trainee trainee)
        {
          

            if (ModelState.IsValid)
            {
                try
                {
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

        // GET: Trainees/Delete/5
        public IActionResult Delete(int id)
        {


            var trainee = _iTraineeManager.GetById(id);
            if (trainee == null)
            {
                return NotFound();
            }

            return View(trainee);
        }

        // POST: Trainees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var trainee = _iTraineeManager.GetById(id);
            _iTraineeManager.Remove(trainee);

            return RedirectToAction(nameof(Index));
        }

        private bool TraineeExists(long id)
        {
            return _iTraineeManager.GetAll().Any(e => e.Id == id);
        }

        public IActionResult GetTraineeEnrollPartial(int courseId)
        {
            //var course = _iCourseManager.GetById(courseId);
          TraineeEnrollViewModel model=new TraineeEnrollViewModel();
            model.CourseId = courseId;
            
            return PartialView("_TraineeEnrollPartialView", model);
        }
    }
}
