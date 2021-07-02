using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TareaCRUD.Data;
using TareaCRUD.Models;

namespace TareaCRUD.Controllers
{
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CourseController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Course> courses = _context.Course;
            return View(courses);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Course course)
        {
            if(ModelState.IsValid)
            {
                _context.Course.Add(course);
                _context.SaveChanges();

                TempData["mensaje"] = "El curso se ha agregado correctamente";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            var course = _context.Course.Find(Id);

            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Course.Update(course);
                _context.SaveChanges();

                TempData["mensaje"] = "El curso se ha actualizado correctamente";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? Id)
        {
            var course = _context.Course.Find(Id);

            if (course == null)
            {
                return NotFound();
            }
            
            _context.Course.Remove(course);
            _context.SaveChanges();
            
            TempData["mensaje"] = "El curso se ha eliminado correctamente";
            
            return RedirectToAction("Index");
        }


    }
}
