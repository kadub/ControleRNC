using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleRNC_WEB.Models
{
    [Table("EYTIPOSTATUS")]
    public class TipoStatus
    {
        [Column("id")]
        [Display(Name ="Id")]
        public int? Id { get; set; }

        [Column("descricao")]
        [Display(Name ="Descrição")]
        public string Descricao { get; set; }
    }
}