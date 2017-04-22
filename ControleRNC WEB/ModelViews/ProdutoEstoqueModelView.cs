using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ControleRNC_WEB.DataAcessLayer;
using ControleRNC_WEB.Models;

namespace ControleRNC_WEB.ModelViews
{
    public class ProdutoEstoqueModelView
    {
        private readonly ControleRncContext _db = new ControleRncContext();


        public ProdutoEstoqueModelView(Produto produto)
        {
            
        }
    }
}