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
    }
}
