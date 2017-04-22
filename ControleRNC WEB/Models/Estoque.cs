using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ControleRNC_WEB.Models
{
    [Table("TLOC")]
    public class Estoque
    {
        [Key]
        [Column("CODLOC")]
        [Display(Name = "Codigo do estoque")]
        public string Codigo { get; set; }

        [Column("NOME")]
        [Display(Name = "Nome do estoque")]
        public string Descricao { get; set; }
    }
}