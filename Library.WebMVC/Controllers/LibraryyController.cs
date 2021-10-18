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

        public ActionResult Details(int id)
        {
            var svc = CreateLibraryyService();
            var model = svc.GetLibraryyById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateLibraryyService();
            var detail = service.GetLibraryyById(id);
            var model =
                new LibraryyEdit
                {
                    LibraryID = detail.LibraryID,
                    Name = detail.Name,
                    Address = detail.Address
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, LibraryyEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            
            if(model.LibraryID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateLibraryyService();
            if (service.UpdateLibraryy(model))
            {
                TempData["SaveResult"] = "Library was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Can not update.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateLibraryyService();
            var model = svc.GetLibraryyById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateLibraryyService();

            service.DeleteLibraryy(id);

            TempData["SaveResult"] = "Library was deleted";

            return RedirectToAction("Index");
        }

        private LibraryyService CreateLibraryyService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LibraryyService(userId);
            return service;
        }
    }
}