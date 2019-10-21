using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DW.Enterprise.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DW.Enterprise.Web.Controllers
{
    [Authorize(Roles = "Admin, Manager")]
    public class StudentsController : Controller
    {
        private readonly IStudentServicecs _service;

        public StudentsController(IStudentServicecs service)
        {
            _service = service;
        }

        // GET: Students
        public async Task<ActionResult> Index()
        {
            //if (User.Identity.IsAuthenticated)
            //{
                // TRaigo el Role de la base de datos de permisos
                //var userRole = "Manager";
                //if (User.IsInRole(userRole))
                    return View(await _service.GetAll());
            //    else
            //        return Unauthorized();
            //}
            //else
            //    return Unauthorized();
        }

        // GET: Students/Details/5
        [AllowAnonymous]
        public async Task<ActionResult> Details(int id)
        {
            return View(await _service.Get(id));
        }

        // GET: Students/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Students/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Students/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}