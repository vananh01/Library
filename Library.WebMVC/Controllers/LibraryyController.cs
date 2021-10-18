using Library.Models;
using Library.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.WebMVC.Controllers
{
    public class LibraryyController : Controller
    {
        // GET: Libraryy
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LibraryyService(userId);
            var model = service.GetLibraries();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create (LibraryyCreate model)
        {
            if (!ModelState.IsValid)   return View(model);

            var service = CreateLibraryyService();

            if (service.CreateLibraryy(model))
            {
                TempData["SaveResult"] = "Library was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Library could not be created.");
            return View(model);
        }

        private LibraryyService CreateLibraryyService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LibraryyService(userId);
            return service;
        }
    }
}