using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NBU_Mailer_2016_WEB.DAL;
using System.IO;
using System.Data.SqlClient;

namespace NBU_Mailer_2016_WEB.Controllers
{
    public class Nbu_EnvelopesController : Controller
    {
        private Model1 db = new Model1();

        // GET: Nbu_Envelopes
        public ActionResult Index()
        {
            var nBU_ENVELOPES = db.NBU_ENVELOPES.Include(n => n.SPRUSNBU_BANKS);

            DateTime fromDate = DateTime.Now.AddDays(-3);

            var fewNBU_envelopes = from fewEnv in nBU_ENVELOPES where fewEnv.DATE_SENT > fromDate select fewEnv;

            var rez = fewNBU_envelopes.ToList().OrderByDescending(f => f.DATE_SENT);

            return View(rez);

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


        private byte[] MessageAlert(string msg)
        {
            string scriptStr = "<html><script>alert(\" + msg + \");</script></html>";

            byte[] scriptBytes = new byte[scriptStr.Length * sizeof(char)];

            System.Buffer.BlockCopy(scriptStr.ToCharArray(), 0, scriptBytes, 0, scriptBytes.Length);

            return scriptBytes;
        }


        // GET: Nbu_Envelopes/ FILE OPEN /5

        public FileContentResult FileOpen(int? id)
        {
            byte[] fileBody;
            string fileName = "";

            try
            {
                var record = from env in db.NBU_ENVELOPES where env.ID == id select env;

                fileName = record.First().FILE_NAME;

                fileBody = (byte[])record.First().FILE_BODY.ToArray();

                return File(fileBody, "text", fileName);

            }
            catch (Exception)
            {
                // TODO:
                // INSERT FILE NAME & FILE ID IN TO MSG !
                // INSERT FILE NAME & FILE ID IN TO MSG !
                // INSERT FILE NAME & FILE ID IN TO MSG !

                string scriptStr = "<html><script>alert(\"File : " + id + " - " + fileName + " - Not found!\");</script></html>";

                byte[] scriptBytes = new byte[scriptStr.Length * sizeof(char)];

                System.Buffer.BlockCopy(scriptStr.ToCharArray(), 0, scriptBytes, 0, scriptBytes.Length);

                return File(scriptBytes, "text/html");
            }
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
        public ActionResult Create([Bind(Include =
            "ID,FROM,TO,FILE_NAME,FILE_SIZE,FILE_BODY,FILE_DATE,DATE_SENT,DATE_DELIV,ENV_NAME,ENV_PATH,SPRUSNBU_BANK_ID")]
        NBU_ENVELOPES nBU_ENVELOPES)
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
