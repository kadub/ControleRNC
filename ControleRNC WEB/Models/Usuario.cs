using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ControleRNC_WEB.Models
{
    [Table("EYUSER")]
    public class Usuario
    {
        [Column("Id")]
        [ScaffoldColumn(false)]
        public int? Id { get; set; }

        [Column("usuario")]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Column("senha")]
        [Display(Name = "Senha")]
        public string Senha { get; set; }

        [Column("nome")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Column("sobrenome")]
        [Display(Name = "Sobrenome")]
        public string Sobrenome { get; set; }

        [Column("perfil")]
        [Display(Name = "Perfil")]
        public string Perfil { get; set; }
    }
}