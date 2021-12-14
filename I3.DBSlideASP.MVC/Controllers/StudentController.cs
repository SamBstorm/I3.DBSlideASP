using DBSlideDataContext.DTO;
using DBSlideDataContext.Services;
using I3.DBSlideASP.MVC.Handlers;
using I3.DBSlideASP.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace I3.DBSlideASP.MVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly IRepository<Student> service;

        public StudentController(IRepository<Student> service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            IEnumerable<StudentListItem> students = service.Get().Select(s => s.ToListItem());
            return View(students);
        }
        /// <summary>
        /// Action de suppression d'un étudiant à l'aide de son identifiant
        /// url d'accès : /student/delete/3
        /// </summary>
        /// <param name="id">Identifiant d'un student</param>
        /// <returns></returns>
        public IActionResult Delete(int id)
        {
            StudentNames student = service.Get(id).ToNames();
            if (!(student is null))
            {
                service.Delete(id);
                return View(student);
            }
            return View("DeleteFail",id);
            
            //Si pas de vue secondaire, on peut rediriger vers une action généraliste :
            //url :  /Home/Error/

            //return RedirectToAction("Error", "Home");
        }

        public IActionResult Details(int id)
        {
            StudentDetails student = service.Get(id).ToDetails();
            if(student is not null) return View(student);
            return RedirectToAction("Index");
        }
    }
}
