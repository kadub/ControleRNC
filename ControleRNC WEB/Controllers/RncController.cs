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
using Microsoft.Ajax.Utilities;
using PagedList;
using ControleRNC_WEB.ModelViews;
using ControleRNC_WEB.BussinessLogicLayer;

namespace ControleRNC_WEB.Controllers
{
    public class RncController : Controller
    {

        private readonly ControleRncContext _db = new ControleRncContext();

        // GET: Rnc
        public ActionResult Index(string sortBy, string filter, int? page, DateTime? dateIni, DateTime? dateEnd, 
            int? tipoRnc, string departamento, int? status, int? acao)
        {
            ViewBag.TiposRnc = new SelectList(_db.TipoRncs, "Id", "Descricao");
            ViewBag.Departamentos = new SelectList(_db.Departamentos, "Codigo", "Descricao");
            ViewBag.TiposStatus = new SelectList(_db.Status, "Id", "Descricao");
            ViewBag.TiposAcao = new SelectList(_db.TiposAcao, "Id", "Descricao");
            try
            {
                List<Rnc> rncsSelected = _db.Rncs.ToList();
                if (sortBy.IsNullOrWhiteSpace())
                {
                    sortBy = "";
                }
                if (dateIni != null && dateEnd != null)
                {
                    rncsSelected = rncsSelected.Where(x => x.DataAbertura >= dateIni && x.DataAbertura <= dateEnd).ToList();
                }
                if (tipoRnc.HasValue)
                {
                    rncsSelected = rncsSelected.Where(x => x.IdTipoRnc == tipoRnc).ToList();
                }
                if (!string.IsNullOrEmpty(departamento))
                {
                    rncsSelected = rncsSelected.Where(x => x.CodDepartamento.CompareTo(departamento) == 0).ToList();
                }
                if (status.HasValue)
                {
                    rncsSelected = rncsSelected.Where(x => x.IdStatus == status).ToList();
                }
                if (acao.HasValue)
                {
                    rncsSelected = rncsSelected.Where(x => x.IdTipoAcao == acao).ToList();
                }
                ViewBag.CurrentFilter = filter ?? "";
                ViewBag.CurrentFilter = ViewBag.CurrentFilter.ToUpper();
                if (!page.HasValue)
                {
                    page = 1;
                }
                switch (filter)
                {
                    case "id":
                        rncsSelected = rncsSelected.OrderByDescending(x => x.Id).ToList();
                        break;
                    case "codigo":
                        rncsSelected = rncsSelected.OrderByDescending(x => x.Codigo).ToList();
                        break;
                    case "tipoRnc":
                        rncsSelected = rncsSelected.OrderByDescending(x => x.TipoRnc.Descricao).ToList();
                        break;
                    case "departamento":
                        rncsSelected = rncsSelected.OrderByDescending(x => x.Departamento.Descricao).ToList();
                        break;
                    case "itemRnc":
                        rncsSelected = rncsSelected.OrderByDescending(x => x.Desenho.Descricao).ToList();
                        break;
                    case "data":
                        rncsSelected = rncsSelected.OrderByDescending(x => x.DataAbertura).ToList();
                        break;
                    default:
                        rncsSelected = rncsSelected.OrderByDescending(x => Convert.ToInt16(x.Codigo.Split('/')[1]))
                            .ThenByDescending(x => Convert.ToInt16(x.Codigo.Split('/')[0])).ToList();
                        break;
                }

                var rnc = rncsSelected.Where(x => x.Desenho == null).ToList();

                if (ViewBag.CurrentFilter != string.Empty)
                {
                    rncsSelected = rncsSelected.Where(x => x.Codigo.ToUpper().Contains(ViewBag.CurrentFilter)
                                                           ||
                                                           x.Departamento.Descricao.ToUpper()
                                                               .Contains(ViewBag.CurrentFilter)
                                                           ||
                                                           x.TipoRnc.Descricao.ToUpper()
                                                               .Contains(ViewBag.CurrentFilter)
                                                           ||
                                                           x.Desenho.Descricao.ToUpper()
                                                               .Contains(ViewBag.CurrentFilter)
                                                           ||
                                                           x.DescricaoRnc.ToUpper()
                                                               .Contains(ViewBag.CurrentFilter)).ToList();
                }
                int pageSize = 20;
                int pageNumber = page ?? 1;
                return View(rncsSelected.ToPagedList(pageNumber, pageSize));
            }
            catch(Exception ex)
            {
                return Content("Ocorreu um erro durante a chamada a página. Detalhes:" + ex.InnerException.Message);
            }
        }

        // GET: Rnc/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rnc rnc = _db.Rncs.Find(id);
            if (rnc == null)
            {
                return HttpNotFound();
            }
            return View(rnc);
        }

        // GET: Rnc/Create 
        public ActionResult Create()
        {
            //tipos que permitem complementos
            ViewBag.Departamentos = new SelectList(_db.Departamentos, "Codigo", "Descricao");
            ViewBag.TiposRnc = new SelectList(_db.TipoRncs, "Id", "Descricao");
            ViewBag.Funcionarios = new SelectList(_db.Funcionarios.OrderBy(x => x.Nome), "Id", "Nome");
            ViewBag.Produtos = new SelectList(_db.Produtos.Where(x => x.Codigo.Length > 11).OrderBy(x => x.Codigo), "Id","CodigoDescricao");
            ViewBag.Clientes = new SelectList(_db.Clientes.OrderBy(x => x.Nome), "Codigo", "Nome");
            ViewBag.Acoes = new SelectList(_db.TiposAcao.OrderBy(x => x.Descricao), "Id", "Descricao");
            ViewBag.Status = new SelectList(_db.Status.OrderBy(x => x.Descricao), "Id", "Descricao");
            return View();
        }

        [HttpPost]
        public ActionResult ConfirmNew([Bind(Include = "Codigo, IdTipoRnc, DataAbertura, CodDepartamento, CodigoDesenho, Qtde" +
                                                       ", Origem, Serial, CodigoEquipamento, DescricaoRnc, IdTipoAcao, IdStatus")] Rnc rnc)
        {
            try
            {
                if (rnc.CodigoEquipamento.CompareTo("none") == 0)
                {
                    rnc.CodigoEquipamento = null;
                }

                if (rnc.CodigoDesenho.CompareTo("none") == 0)
                {
                    rnc.CodigoDesenho = null;
                }

                _db.Rncs.Add(rnc);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Content("Ocorreu uma falha na operação. Detalhes: " + ex.Message);
            }
        }

        // GET: Rnc/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.Departamentos = new SelectList(_db.Departamentos, "Codigo", "Descricao");
            ViewBag.TiposRnc = new SelectList(_db.TipoRncs, "Id", "Descricao");
            ViewBag.Funcionarios = new SelectList(_db.Funcionarios.OrderBy(x => x.Nome), "Id", "Nome");
            ViewBag.Produtos = new SelectList(_db.Produtos.Where(x => x.Codigo.Length > 11).OrderBy(x => x.Codigo), "Id", "CodigoDescricao");
            ViewBag.Clientes = new SelectList(_db.Clientes.OrderBy(x => x.Nome), "Codigo", "Nome");
            ViewBag.Acoes = new SelectList(_db.TiposAcao.OrderBy(x => x.Descricao), "Id", "Descricao");
            ViewBag.Status = new SelectList(_db.Status.OrderBy(x => x.Descricao), "Id", "Descricao");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rnc rnc = _db.Rncs.Find(id);
            if (rnc == null)
            {
                return HttpNotFound();
            }
            ViewBag.Código = new SelectList(_db.Departamentos, "Codigo", "Descricao", rnc.Codigo);
            ViewBag.Id = new SelectList(_db.TipoRncs, "Id", "Codigo", rnc.Id);
            return View(rnc);
        }

        [HttpPost]
        public ActionResult ConfirmEdit([Bind(Include = "Id,Codigo, IdTipoRnc, DataAbertura, CodDepartamento, CodigoDesenho, Qtde" +
                                                        ", Origem, Serial, CodigoEquipamento, DescricaoRnc, IdTipoAcao, IdStatus")] Rnc rnc)
        {
            if (rnc.CodigoEquipamento.CompareTo("none") == 0)
            {
                rnc.CodigoEquipamento = null;
            }

            if (rnc.CodigoDesenho.CompareTo("none") == 0)
            {
                rnc.CodigoDesenho = null;
            }
            if (ModelState.IsValid)
            {
                _db.Entry(rnc).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Código = new SelectList(_db.Departamentos, "Codigo", "Descricao", rnc.Codigo);
            ViewBag.Id = new SelectList(_db.TipoRncs, "Id", "Codigo", rnc.Id);
            return View(rnc);
        }

        // GET: Rnc/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rnc rnc = _db.Rncs.Find(id);
            if (rnc == null)
            {
                return HttpNotFound();
            }
            return View(rnc);
        }

        public ActionResult DeleteConfirmed(int id)
        {
            Rnc rnc = _db.Rncs.Find(id);
            _db.Rncs.Remove(rnc);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Analise()
        {
            ViewBag.TiposRnc = new SelectList(_db.TipoRncs, "Id", "Descricao");
            ViewBag.Departamentos = new SelectList(_db.Departamentos, "Codigo", "Descricao");
            ViewBag.TiposStatus = new SelectList(_db.Status, "Id", "Descricao");
            ViewBag.TiposAcao = new SelectList(_db.TiposAcao, "Id", "Descricao");
            return View(new AnaliseModelView());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}
