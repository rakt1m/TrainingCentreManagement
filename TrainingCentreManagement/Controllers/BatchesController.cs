using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainingCentreManagement.BLL.Contracts;
using TrainingCentreManagement.Models.EntityModels;

namespace TrainingCentreManagement.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BatchesController : Controller
    {
        private readonly IBatchManager _iBatchManager;

        public BatchesController(IBatchManager iBatchManager)
        {
            _iBatchManager = iBatchManager;
        }

        // GET: Batches
        public IActionResult Index()
        {
            return View(_iBatchManager.GetAll());
        }

        // GET: Batches/Details/5
        public IActionResult Details(int id)
        {
           
            var batch = _iBatchManager.GetById(id);
            if (batch == null)
            {
                return NotFound();
            }

            return View(batch);
        }

        // GET: Batches/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Batches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Title,TotalSeats,RegistrationStart,RegistrationEnd,ClassStart")] Batch batch)
        {
            if (ModelState.IsValid)
            {
                _iBatchManager.Add(batch);
                
                return RedirectToAction(nameof(Index));
            }
            return View(batch);
        }

        // GET: Batches/Edit/5
        public IActionResult Edit(int id)
        {
            var batch = _iBatchManager.GetById(id);
            if (batch == null)
            {
                return NotFound();
            }
            return View(batch);
        }

        // POST: Batches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Title,TotalSeats,RegistrationStart,RegistrationEnd,ClassStart")] Batch batch)
        {
            if (id != batch.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
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
            return View(batch);
        }

        // GET: Batches/Delete/5
        public IActionResult Delete(int id)
        {
           

            var batch = _iBatchManager.GetById(id);
            if (batch == null)
            {
                return NotFound();
            }

            return View(batch);
        }

        // POST: Batches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var batch = _iBatchManager.GetById(id);
            _iBatchManager.Remove(batch);
        
            return RedirectToAction(nameof(Index));
        }

        private bool BatchExists(long id)
        {
            return _iBatchManager.GetAll().Any(e => e.Id == id);
        }
    }
}
