using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ControleRNC_WEB.Models
{
    [Table("TPRODUTO")]
    public class Produto
    {
        [ScaffoldColumn(false)]
        [Display(Name = "Id")]
        [Column("IDPRD")]
        [Key]
        public int Id { get; set; }

        [Display(Name = "Codigo")]
        [Column("CODIGOPRD")]
        public string Codigo { get; set; }

        [Display(Name = "Descricao")]
        [Column("NOMEFANTASIA")]
        public string Descricao { get; set; }

        [Display(Name = "INATIVO")]
        [Column("Inativo")]
        public Int16? Inativo { get; set; }

        [NotMapped]
        public IQueryable<ProdutoEstoque> ProdutoEstoques { get; set; }

        public string CodigoDescricao => Codigo + " - " + Descricao;
    }
}