using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ControleRNC_WEB.Models
{
    [Table("TPRDLOC")]
    public class ProdutoEstoque
    {
        [Column("IDPRD", Order = 1), Key]
        public int IdProduto { get; set; }

        [Column("SALDOFISICO2")]
        public decimal? Saldo { get; set; }

        [Column("CUSTOUNITARIO"), DisplayFormat(DataFormatString = "{0:C}")]
        public decimal? CustoUnitario { get; set; }

        [Column("CODLOC", Order = 0), Key]
        public string CodigoEstoque { get; set; }

        [NotMapped]
        public Estoque Estoque { get; set; }
    }
}