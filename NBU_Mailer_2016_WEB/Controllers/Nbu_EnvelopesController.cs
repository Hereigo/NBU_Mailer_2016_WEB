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
    public class Nbu_EnvelopesController : Controller
    {
        private Model1 db = new Model1();

        // GET: Nbu_Envelopes
        public ActionResult Index()
        {
            var nBU_ENVELOPES = db.NBU_ENVELOPES.Include(n => n.SPRUSNBU_BANKS);

            var fewNBU_envelopes = from fewEnv in nBU_ENVELOPES where fewEnv.ID > 1180 select fewEnv;

            return View(fewNBU_envelopes.ToList());
            //return View(nBU_ENVELOPES.ToList());
        }

        // GET: Nbu_Envelopes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NBU_ENVELOPES nBU_ENVELOPES = db.NBU_ENVELOPES.Find(id);
            if (nBU_ENVELOPES == null)
            {
                return HttpNotFound();
            }
            return View(nBU_ENVELOPES);
        }

        // GET: Nbu_Envelopes/Create
        public ActionResult Create()
        {
            ViewBag.SPRUSNBU_BANK_ID = new SelectList(db.SPRUSNBU_BANKS, "ID", "IDHOST");
            return View();
        }

        // POST: Nbu_Envelopes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FROM,TO,FILE_NAME,FILE_SIZE,FILE_BODY,FILE_DATE,DATE_SENT,DATE_DELIV,ENV_NAME,ENV_PATH,SPRUSNBU_BANK_ID")] NBU_ENVELOPES nBU_ENVELOPES)
        {
            if (ModelState.IsValid)
            {
                db.NBU_ENVELOPES.Add(nBU_ENVELOPES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SPRUSNBU_BANK_ID = new SelectList(db.SPRUSNBU_BANKS, "ID", "IDHOST", nBU_ENVELOPES.SPRUSNBU_BANK_ID);
            return View(nBU_ENVELOPES);
        }

        // GET: Nbu_Envelopes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NBU_ENVELOPES nBU_ENVELOPES = db.NBU_ENVELOPES.Find(id);
            if (nBU_ENVELOPES == null)
            {
                return HttpNotFound();
            }
            ViewBag.SPRUSNBU_BANK_ID = new SelectList(db.SPRUSNBU_BANKS, "ID", "IDHOST", nBU_ENVELOPES.SPRUSNBU_BANK_ID);
            return View(nBU_ENVELOPES);
        }

        // POST: Nbu_Envelopes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FROM,TO,FILE_NAME,FILE_SIZE,FILE_BODY,FILE_DATE,DATE_SENT,DATE_DELIV,ENV_NAME,ENV_PATH,SPRUSNBU_BANK_ID")] NBU_ENVELOPES nBU_ENVELOPES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nBU_ENVELOPES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SPRUSNBU_BANK_ID = new SelectList(db.SPRUSNBU_BANKS, "ID", "IDHOST", nBU_ENVELOPES.SPRUSNBU_BANK_ID);
            return View(nBU_ENVELOPES);
        }

        // GET: Nbu_Envelopes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NBU_ENVELOPES nBU_ENVELOPES = db.NBU_ENVELOPES.Find(id);
            if (nBU_ENVELOPES == null)
            {
                return HttpNotFound();
            }
            return View(nBU_ENVELOPES);
        }

        // POST: Nbu_Envelopes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NBU_ENVELOPES nBU_ENVELOPES = db.NBU_ENVELOPES.Find(id);
            db.NBU_ENVELOPES.Remove(nBU_ENVELOPES);
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
