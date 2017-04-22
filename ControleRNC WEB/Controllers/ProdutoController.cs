using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using ControleRNC_WEB.DataAcessLayer;
using Microsoft.Ajax.Utilities;
using ControleRNC_WEB.Models;
using ControleRNC_WEB.ModelViews;
using PagedList;

namespace ControleRNC_WEB.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ControleRncContext _db = new ControleRncContext();



        public ActionResult Index(string sortBy, string filter, int? page)
        {
            ViewBag.SortParameter = sortBy;
            ViewBag.CurrentFilter = filter ?? "";
            if (sortBy.IsNullOrWhiteSpace())
            {
                sortBy = "id";
            }
            if (!page.HasValue)
            {
                page = 1;
            }

            List<Produto> selectedProdutos = _db.Produtos.Where(item => item.Codigo.Length > 11).ToList();
            switch (sortBy)
            {
                case "id":
                    selectedProdutos = selectedProdutos.OrderBy(x => x.Codigo).ToList();
                    break;
                case "descricao":
                    selectedProdutos = selectedProdutos.OrderBy(x => x.Descricao).ToList();
                    break;
                default:
                    selectedProdutos = selectedProdutos.OrderBy( x => x.Codigo).ToList();
                    break;
            }

            selectedProdutos = selectedProdutos.Where(x =>  x.Codigo.ToUpper().Contains(ViewBag.CurrentFilter.ToUpper()) 
                                                        || x.Descricao.ToUpper().Contains(ViewBag.CurrentFilter.ToUpper())).ToList();
            int pageSize = 20;
            int pageNumber = page ?? 1;
            return View(selectedProdutos.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult SearchProduct(string filter)
        {
            filter = filter.ToUpper();
            var searchResult = _db.Produtos.Where(x => x.Codigo.ToUpper().Contains(filter)
                                                        || x.Descricao.ToUpper().Contains(filter)
                                                        && x.Codigo.Length > 11);
            searchResult = searchResult.OrderBy(produto => produto.Codigo);
            return Json(searchResult, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Details(int? id)
        {
            var produto = _db.Produtos.Find(id);
            produto.ProdutoEstoques = _db.ProdutoEstoques.Where(x => x.IdProduto == produto.Id);
            produto.ProdutoEstoques.ToList().ForEach(x => x.Estoque = _db.Estoques.First(y => y.Codigo == x.CodigoEstoque));
            return View(produto);
        }
    }
}