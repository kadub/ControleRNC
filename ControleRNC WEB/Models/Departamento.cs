using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace ControleRNC_WEB.Models
{
    [Table("GDEPTO")]
    public class Departamento
    {
        [Key]
        [Column("CODDEPARTAMENTO")]
        [Display(Name = "Codigo")]
        public string Codigo { get; set; }

        [Column("NOME")]
        [Display(Name = "Descricao")]
        public string Descricao { get; set; }

    }
}