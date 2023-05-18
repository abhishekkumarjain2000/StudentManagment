using Microsoft.AspNetCore.Mvc;
using StudentManagment.DataAccessLayer.Data;
using StudentsManagment.Models;

namespace Student_Managment.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Category_List()
        {
            IEnumerable<Category> categories = _context.categories;
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create_Category()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create_Category(Category category)
        {
            if(ModelState.IsValid)
            {
                _context.Add(category);
                _context.SaveChanges();
                return RedirectToAction("Category_List");
            }
            return View(category);
        }

        [HttpPut]
        public IActionResult Update_Category()
        {

            return View();
        }

        [HttpDelete]
        public IActionResult Delete_Category()
        {
            return View();
        }

    }
}
