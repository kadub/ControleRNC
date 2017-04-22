using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ControleRNC_WEB.DataAcessLayer;
using ControleRNC_WEB.Models;

namespace ControleRNC_WEB.Controllers
{
    public class TipoAcaosController : Controller
    {
        private ControleRncContext db = new ControleRncContext();

        // GET: TipoAcaos
        public ActionResult Index()
        {
            return View(db.TiposAcao.ToList());
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,Descricao")] TipoAcao tipoAcao)
        {
            if (ModelState.IsValid)
            {
                db.TiposAcao.Add(tipoAcao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoAcao);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Descricao")] TipoAcao tipoAcao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoAcao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoAcao);
        }

        // POST: TipoAcaos/Delete/5
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoAcao tipoAcao = db.TiposAcao.Find(id);
            db.TiposAcao.Remove(tipoAcao);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetById(int id)
        {
            JsonResult json = new JsonResult();
            json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            json.Data = db.TiposAcao.Find(id);
            json.ContentType = "application/json; charset=utf-8";
            return json;
        }
    }
}
