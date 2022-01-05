using DBSlideDataContext.DTO;
using DBSlideDataContext.Services;
using I3.DBSlideASP.MVC.Handlers;
using I3.DBSlideASP.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace I3.DBSlideASP.MVC.Controllers
{
    public class ProfessorController : Controller
    {
        private readonly IRepository<Professor> _service;

        public ProfessorController(IRepository<Professor> service)
        {
            this._service = service;
        }

        // GET: Professor?primarySort=section
        // GET: Professor/Index?primarySort=section
        public ActionResult Index(string primarySort)
        {
            IEnumerable<ProfessorListItem> model = this._service.Get()
                                                    .Select(p => p.ToListItem());
            if (primarySort is null)
            {
                model = model.OrderBy(m => m.Professor_Name);
                return View(model);
            }
            switch (primarySort.ToLower())
            {
                case "nom" :
                    model = model.OrderBy(m => m.Professor_Name);
                    break;
                case "prenom":
                    model = model.OrderBy(m => m.Professor_Surname);
                    break;
                case "section":
                    model = model.OrderBy(m => m.Section_Id);
                    break;
                default:
                    break;
            }
            return View(model);
        }

        // GET: ProfessorController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        
        /*// GET: ProfessorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProfessorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }*/

        // GET: ProfessorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProfessorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProfessorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProfessorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
