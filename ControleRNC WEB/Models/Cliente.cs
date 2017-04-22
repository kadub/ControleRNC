using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ControleRNC_WEB.Models
{
    [Table("FCFO")]
    public class Cliente
    {
        [Column("CODCFO")]
        [Display(Name = "Código")]
        [Key]
        public string Codigo { get; set; }

        [Column("NOMEFANTASIA")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Column("RUA")]
        public string Rua { get; set; }

        [Column("NUMERO")]
        public string Numero { get; set; }

        [Column("BAIRRO")]
        public string Bairro { get; set; }

        [Column("COMPLEMENTO")]
        public string Complemento { get; set; }

        [Column("CodADE")]
        public string Codade { get; set; }

        [Column("CODETD")]
        public string Estado { get; set; }

        [Column("TELEFONE")]
        public string Telefone { get; set; }

        [NotMapped]
        public string Endereco
            =>
            Rua + ", nº " + Numero + (Complemento == null ? "" : ", " + Complemento) + ", " + Bairro + ", " + Codade +
            " - " + Estado;
    }
}