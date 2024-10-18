using Company.BLL.Interfaces;
using Company.BLL.Repositories;
using Company.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Company.ProjectMVC.PL.Controllers
{
    public class DepartmentController : Controller
    {

        private readonly DepartmentRepository _departmentRepository;

        public DepartmentController(DepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var departments = _departmentRepository.GetAll();

            return View(departments);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Dpartment model)
        {
            if (ModelState.IsValid)
            {
                var count = _departmentRepository.Add(model);
                if (count > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);

        }

        public IActionResult Details(int? id)
        {
            if (id is null) return BadRequest();

          var department=  _departmentRepository.Get(id);

            if(department is null) return NotFound();

            return View(department);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id is null) return BadRequest();

            var department = _departmentRepository.Get(id);

            if (department is null) return NotFound();

            return View(department);
        }


        [HttpPost]
        public IActionResult Edit(Dpartment model)
        {
            if (ModelState.IsValid)
            {
                var Count = _departmentRepository.Update(model);
                if(Count > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id is null) return BadRequest();

            var department = _departmentRepository.Get(id);

            if (department is null) return NotFound();

            return View(department);
        }



        [HttpPost]
        public IActionResult Delete(Dpartment model)
        {
            if (ModelState.IsValid)
            {
                var Count = _departmentRepository.Delete(model);
                if (Count > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        
    }
}
