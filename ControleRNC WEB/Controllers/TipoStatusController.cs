using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ControleRNC_WEB.DataAcessLayer;
using ControleRNC_WEB.Models;

namespace ControleRNC_WEB.Controllers
{
    public class TipoStatusController : Controller
    {
        private ControleRncContext db = new ControleRncContext();

        // GET: TipoStatus
        public ActionResult Index()
        {
            return View(db.Status.ToList());
        }

        // POST: TipoStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,Descricao")] TipoStatus tipoStatus)
        {
            if (ModelState.IsValid)
            {
                db.Status.Add(tipoStatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoStatus);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Descricao")] TipoStatus tipoStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoStatus);
        }

        // POST: TipoStatus/Delete/5
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoStatus tipoStatus = db.Status.Find(id);
            db.Status.Remove(tipoStatus);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetById(int id)
        {
            JsonResult json = new JsonResult();
            json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            json.Data = db.Status.Find(id);
            json.ContentType = "application/json; charset=utf-8";
            return json;
        }
    }
}
