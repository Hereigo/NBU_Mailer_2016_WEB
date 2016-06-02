using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NBU_Mailer_2016_WEB.DAL;

namespace NBU_Mailer_2016_WEB.Controllers
{
    public class Sprusnbu_BanksController : Controller
    {
        private Model1 db = new Model1();

        // GET: Sprusnbu_Banks
        public ActionResult Index()
        {
            return View(db.SPRUSNBU_BANKS.ToList());
        }

        // GET: Sprusnbu_Banks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SPRUSNBU_BANKS sPRUSNBU_BANKS = db.SPRUSNBU_BANKS.Find(id);
            if (sPRUSNBU_BANKS == null)
            {
                return HttpNotFound();
            }
            return View(sPRUSNBU_BANKS);
        }

        // GET: Sprusnbu_Banks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sprusnbu_Banks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IDHOST,FNHOST,MFOM,OKPO,KTELE,KFASE,PARTNER")] SPRUSNBU_BANKS sPRUSNBU_BANKS)
        {
            if (ModelState.IsValid)
            {
                db.SPRUSNBU_BANKS.Add(sPRUSNBU_BANKS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sPRUSNBU_BANKS);
        }

        // GET: Sprusnbu_Banks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SPRUSNBU_BANKS sPRUSNBU_BANKS = db.SPRUSNBU_BANKS.Find(id);
            if (sPRUSNBU_BANKS == null)
            {
                return HttpNotFound();
            }
            return View(sPRUSNBU_BANKS);
        }

        // POST: Sprusnbu_Banks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IDHOST,FNHOST,MFOM,OKPO,KTELE,KFASE,PARTNER")] SPRUSNBU_BANKS sPRUSNBU_BANKS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sPRUSNBU_BANKS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sPRUSNBU_BANKS);
        }

        // GET: Sprusnbu_Banks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SPRUSNBU_BANKS sPRUSNBU_BANKS = db.SPRUSNBU_BANKS.Find(id);
            if (sPRUSNBU_BANKS == null)
            {
                return HttpNotFound();
            }
            return View(sPRUSNBU_BANKS);
        }

        // POST: Sprusnbu_Banks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SPRUSNBU_BANKS sPRUSNBU_BANKS = db.SPRUSNBU_BANKS.Find(id);
            db.SPRUSNBU_BANKS.Remove(sPRUSNBU_BANKS);
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
