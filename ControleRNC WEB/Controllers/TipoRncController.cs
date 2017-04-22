using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ControleRNC_WEB.DataAcessLayer;
using ControleRNC_WEB.Models;

namespace ControleRNC_WEB.Controllers
{
    public class TipoRncController : Controller
    {

        private readonly ControleRncContext db = new ControleRncContext();

        //GET: TipoRnc/Index
        public ActionResult Index()
        {
            var tipos = db.TipoRncs.ToList();
            return View(tipos);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Descricao")] TipoRnc tipoRnc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoRnc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoRnc);
        }

        public ActionResult Delete(int id)
        {
            db.TipoRncs.Remove(db.TipoRncs.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ConfirmNew([Bind(Include = "Id, Descricao")] TipoRnc tipo)
        {
            db.TipoRncs.Add(tipo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetById(int id)
        {
            JsonResult json = new JsonResult();
            json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            json.Data = db.TipoRncs.Find(id);
            json.ContentType = "application/json; charset=utf-8";
            return json;
        }
    }
}