using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ControleRNC_WEB.DataAcessLayer;
using Microsoft.Ajax.Utilities;

namespace ControleRNC_WEB.Controllers
{
    public class ClienteController : Controller
    {
        private ControleRncContext _db = new ControleRncContext();

        public ActionResult SearchClient(string filter)
        {
            if (!filter.IsNullOrWhiteSpace())
            {
                filter = filter.ToUpper();
                var clientsFiltered =
                    _db.Clientes.Where(client => client.Nome.Contains(filter)).OrderBy(client => client.Nome);
                return Json(clientsFiltered, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(null);
            }
        }

        public ActionResult SearchById(string codigo)
        {
            var clientsFiltered = _db.Clientes.First(cliente => cliente.Codigo == codigo);
            return Json(clientsFiltered, JsonRequestBehavior.AllowGet);
        }
    }
}