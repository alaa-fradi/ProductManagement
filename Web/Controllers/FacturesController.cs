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
using Service;

namespace Web.Controllers
{
    public class FacturesController : Controller
    {
        private GestionProduitsContext db = new GestionProduitsContext();

        private ServiceFacture sf = new ServiceFacture();

        // GET: Factures
        public ActionResult Index()
        {
           // var factures = db.Factures.Include(f => f.Client).Include(f => f.Product);
           //ViewBag.ProductName = sf._unitOfWork.DataContext.Product.Where(P => P.ProductID )
           var facture = sf._unitOfWork.DataContext.Factures.Include(f => f.Client).Include(f => f.Product);
            return View(facture);
        }

        // GET: Factures/Details/5
        public ActionResult Details(int IdClient, int IdProduct, DateTime DateAchat)
        {
            if (IdClient == 0 && IdProduct == 0 && DateAchat == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Facture facture = db.Factures.Where(f => f.ProductId == IdProduct && f.ClientId == IdClient && f.DateAchat == DateAchat).FirstOrDefault();
            Facture facture = sf.GetFactureById(IdProduct, IdClient, DateAchat);
            if (facture == null)
            {
                return HttpNotFound();
            }
            return View(facture);
        }

        // GET: Factures/Create
        public ActionResult Create()
        {
            ViewBag.ClientId = new SelectList(sf._unitOfWork.DataContext.Clients, "Cin", "Nom");
            ViewBag.ProductId = new SelectList(sf._unitOfWork.DataContext.Product, "ProductID", "Name");
            return View();
        }

        // POST: Factures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DateAchat,ProductId,ClientId,Prix")] Facture facture)
        {
            if (ModelState.IsValid)
            {
                //db.Factures.Add(facture);
                // db.SaveChanges();
                sf.Create(facture);
                return RedirectToAction("Index");
            }

            ViewBag.ClientId = new SelectList(sf._unitOfWork.DataContext.Clients, "Cin", "Nom", facture.ClientId);
            ViewBag.ProductId = new SelectList(sf._unitOfWork.DataContext.Product, "ProductID", "Name", facture.ProductId);
            return View(facture);
        }

        // GET: Factures/Edit/5
        public ActionResult Edit(int IdClient , int IdProduct , DateTime DateAchat )
        {
            if (IdClient == 0 && IdProduct==0 && DateAchat == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facture facture = db.Factures.Where(f=>f.ProductId == IdProduct && f.ClientId == IdClient && f.DateAchat==DateAchat).FirstOrDefault();
            if (facture == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientId = new SelectList(db.Clients, "Cin", "Nom", facture.ClientId);
            ViewBag.ProductId = new SelectList(db.Product, "ProductID", "Name", facture.ProductId);
            return View(facture);
        }

        // POST: Factures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DateAchat,ProductId,ClientId,Prix")] Facture facture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(facture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientId = new SelectList(db.Clients, "Cin", "Nom", facture.ClientId);
            ViewBag.ProductId = new SelectList(db.Product, "ProductID", "Name", facture.ProductId);
            return View(facture);
        }

        // GET: Factures/Delete/5
        public ActionResult Delete(int IdClient, int IdProduct, DateTime DateAchat)
        {
            if (IdClient == 0 && IdProduct == 0 && DateAchat == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facture facture = db.Factures.Where(f => f.ProductId == IdProduct && f.ClientId == IdClient && f.DateAchat == DateAchat).FirstOrDefault();
            if (facture == null)
            {
                return HttpNotFound();
            }
            return View(facture);
        }

        // POST: Factures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int IdClient, int IdProduct, DateTime DateAchat)
        {
            Facture facture = db.Factures.Where(f => f.ProductId == IdProduct && f.ClientId == IdClient && f.DateAchat == DateAchat).FirstOrDefault();
            db.Factures.Remove(facture);
            db.SaveChanges();
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
