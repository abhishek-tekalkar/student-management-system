using Microsoft.AspNetCore.Mvc;
using SMS.Data;
using SMS.Models;

namespace SMS.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            //need to check here that "_context.Students.ToList()" is updating or not if not then need to retrive all studentts pass to view
            return View(_context.Students.ToList());  
        }
        //initial push
        // 2. GET: Display empty Create form
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student studentObj)
        {
            if (!ModelState.IsValid)
                return View(studentObj);
            studentObj.Id = GlobalService.GetNextNumber();
            _context.Students.Add(studentObj);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(string id)
        {
            deleteOps(id);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult DeleteMulti(List<string> id)
        {

            foreach (var item in id)
            {
                deleteOps(item);
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        private void deleteOps(string studentObj_ID)
        {
            var exisiting = _context.Students.Find(studentObj_ID);
            if (exisiting != null) _context.Students.Remove(exisiting);            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student studentObj)
        {
            if (!ModelState.IsValid)
                return View(studentObj);

            var existingStudent = _context.Students.Find(studentObj.Id);

            if (existingStudent == null) return NotFound();

            _context.Entry(existingStudent)
                    .CurrentValues
                    .SetValues(studentObj);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(string id)
        {
            var existingStudent = _context.Students.Find(id);

            if (existingStudent == null)
                return NotFound();

            return View(existingStudent);
        }
            
    }
}
