using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Callisto.Domain.Services;
using Callisto.Web.Models;
using WebGrease.Css.Extensions;

namespace Callisto.Web.Controllers
{
    public class ReleaseNotesController : Controller
    {
        private IReleaseNoteService releaseNoteService;

        public ReleaseNotesController()
        {
            
        }

        public ReleaseNotesController(IReleaseNoteService releaseNoteService)
        {
            if(releaseNoteService == null)
                throw new ArgumentNullException("releaseNoteService");

            this.releaseNoteService = releaseNoteService;
        }

        // GET: ReleaseNotes
        public ActionResult Index()
        {
            var notes = releaseNoteService.GetAllReleaseNotes();
            var releaseNotes = notes.Select(n => n.FromDomainModel());
            return View(releaseNotes);
        }

        // GET: ReleaseNotes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReleaseNotes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReleaseNotes/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ReleaseNotes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReleaseNotes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ReleaseNotes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReleaseNotes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
