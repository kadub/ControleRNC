using ControleRNC_WEB.DataAcessLayer;
using ControleRNC_WEB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ControleRNC_WEB.ModelViews
{
    public class RncIndexViewModel
    {
        private readonly ControleRncContext _db = new ControleRncContext();

        public DbSet<Rnc> TodasRnc
        {
            get { return _db.Rncs; }
        }
        public DbSet<Rnc> RncFiltradas { get; set; }

        [Display(Name = "Total de Rnc")]
        public int TotalRnc
        {
            get { return TodasRnc.Count(); }
        }

        [Display(Name = "Total de RNC filtradas")]
        public int TotalRncFiltrada
        {
            get { return RncFiltradas.Count(); }
        }
    }

}