using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControleRNC_WEB.Models
{
    public class ClienteFornecedor
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Codigo")]
        public string Codigo { get; set; }

        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        [Display(Name = "Telefone")]
        public string Telefone { get; set; }
    }
}