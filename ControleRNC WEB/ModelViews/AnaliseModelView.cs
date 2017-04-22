using ControleRNC_WEB.DataAcessLayer;
using ControleRNC_WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleRNC_WEB.ModelViews
{
    public class AnaliseModelView : Controller
    {
        private readonly ControleRncContext _db = new ControleRncContext();

        public String ChartPieByAcao()
        {
            
            string content = "";
            var tiposRnc = _db.TipoRncs.ToList();
            foreach (var tipo in tiposRnc)
            {
                int qtde = _db.Rncs.Where(x => x.IdTipoRnc == tipo.Id).Count();
                if (qtde > 0)
                {
                    content += ",['" + tipo.Descricao + "\'," + qtde + "]";
                }
            }
            return content;
        }

        public String DataByDepartment()
        {
            string content = "";
            var deptos = _db.Departamentos.ToList();
            foreach (var depto in deptos)
            {
                int qtde = _db.Rncs.Where(x => x.CodDepartamento.CompareTo(depto.Codigo) == 0).Count();
                if (qtde > 0)
                    content += ",['" + depto.Descricao + "\'," + qtde + "]";
            }
            return content;
        }

    }

}