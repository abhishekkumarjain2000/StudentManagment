using Microsoft.AspNetCore.Mvc;
using StudentManagment.DataAccessLayer.Data;
using StudentManagment.DataAccessLayer.Infrastructure.IRepository;
using StudentsManagment.Models;

namespace Student_Managment.Controllers
{
    public class CategoryController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Category_List()
        {
            IEnumerable<Category> categories = _unitOfWork.Category.GetAll();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create_Category(int? Id)
        {
            if (Id != null && Id > 0)
            {
                var data = _unitOfWork.Category.GetT(c => c.Id == Id);
                return View(data);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Create_Category(Category category)
        {
            if (category.Id > 0)
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.Category.Update(category);
                    _unitOfWork.Save();
                    TempData["success"] = "Record Update Sucessfully";
                    return RedirectToAction("Category_List");
                }
                return View(category);
            }
            else if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(category);
                _unitOfWork.Save();
                TempData["success"] = "Record Save Sucessfully";
                return RedirectToAction("Category_List");
            }
            return View(category);
        }

        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            if (Id > 0)
            {
                var category = _unitOfWork.Category.GetT(x => x.Id == Id);
                if (category != null)
                {
                    _unitOfWork.Category.Delete(category);
                    _unitOfWork.Save();
                    TempData["success"] = "Record Delete Sucessfully";
                    return RedirectToAction("Category_List");
                }
                else
                {
                    return NotFound();
                }
            }
            return View();
        }

    }
}
