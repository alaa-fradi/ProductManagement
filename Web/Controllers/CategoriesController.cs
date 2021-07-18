using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data;
using Domaine.Entities;
using Data.Repositories;
using Data.Infrastructure;

namespace Web.Controllers
{
    public class CategoriesController : Controller
    {
        private GestionProduitsContext db = new GestionProduitsContext();

        private CategoryRepository crRepo = new CategoryRepository(new DatabaseFactory());

        private UnitOfWork uow = new UnitOfWork();

        // GET: Categories
        public ActionResult Index()
        {
            return View(uow.GetRepository<Categories>().GetAll());
        }

        // GET: Categories/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categories categories = uow.GetRepository<Categories>().GetById(id);
            if (categories == null)
            {
                return HttpNotFound();
            }
            return View(categories);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "categoryId,name")] Categories categories)
        {
            if (ModelState.IsValid)
            {
                uow.GetRepository<Categories>().Add(categories);
                uow.Commit();
                return RedirectToAction("Index");
            }

            return View(categories);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categories categories = uow.GetRepository<Categories>().GetById(id);
            if (categories == null)
            {
                return HttpNotFound();
            }
            return View(categories);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "categoryId,name")] Categories categories)
        {
            if (ModelState.IsValid)
            {
                uow.GetRepository<Categories>().Update(categories);
                uow.Commit();
                return RedirectToAction("Index");
            }
            return View(categories);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categories categories = uow.GetRepository<Categories>().GetById(id);
            if (categories == null)
            {
                return HttpNotFound();
            }
            return View(categories);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Categories categories = uow.GetRepository<Categories>().GetById(id);
            uow.GetRepository<Categories>().Delete(categories);
            uow.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
