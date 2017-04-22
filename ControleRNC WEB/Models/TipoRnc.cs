using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ControleRNC_WEB.Models
{
    [Table("EYTIPORNC")]
    public class TipoRnc
    {
        [Column("id")]
        [Display(Name = "Id")]
        public int Id { get; set; }
        

        [Required]
        [Column("descricao")]
        [Display(Name = "Descricao")]
        public string Descricao { get; set; }
    }
}