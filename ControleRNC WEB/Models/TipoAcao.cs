using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ControleRNC_WEB.Models
{
    [Table("EYTIPOACAO")]
    public class TipoAcao
    {
        [Column("id")]
        [Display(Name ="Id")]
        public int? Id { get; set; }

        [Required]
        [Column("descricao")]
        [Display(Name ="Descricão")]
        public string Descricao { get; set; }
    }
}