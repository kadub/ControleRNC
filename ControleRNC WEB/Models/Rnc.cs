using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using ControleRNC_WEB.DataAcessLayer;

namespace ControleRNC_WEB.Models
{
    [Table("EYRNCBASICA")]
    public class Rnc
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        
        [Column("codRnc")]
        [Display(Name = "Codigo")]
        public string Codigo { get; set; }

        [Column("tipoRnc")]
        [Display(Name = "Código tipo de RNC")]
        public int IdTipoRnc { get; set; }


        [Column("dataAbertura")]
        [Display(Name = "Data de abertura")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataAbertura { get; set; }

        [Column("departamento")]
        [Display(Name = "Codigo do departamento")]
        public string CodDepartamento { get; set; }

        [Column("desenho")]
        [Display(Name = "Código do desenho")]
        public string CodigoDesenho { get; set; }

        [Column("qtde")]
        [Display(Name = "Quantidade")]
        public double Qtde { get; set; }

        [Column("origem")]
        [Display(Name = "Nota fiscal ou Ordem")]
        public string Origem { get; set; }

        [Column("numeroSerie")]
        [Display(Name = "Serial")]
        public string Serial { get; set; }

        [Column("equipamento")]
        [Display(Name = "Código do equipamento")]
        public string CodigoEquipamento { get; set; }

        [Column("descRNC")]
        [Display(Name = "Descricao da RNC")]
        public string DescricaoRnc { get; set; }

        [Column("tipoAcao")]
        [Display(Name = "Id Tipo Ação")]
        public int? IdTipoAcao { get; set; }

        [Column("status")]
        [Display(Name = "Status")]
        public int? IdStatus { get; set; }

        [NotMapped]
        public virtual TipoStatus Status => new ControleRncContext().Status.FirstOrDefault(x => x.Id == IdStatus);

        [NotMapped]
        public virtual TipoAcao TipoAcao => new ControleRncContext().TiposAcao.FirstOrDefault(x => x.Id == IdTipoAcao);

        [NotMapped]
        public virtual TipoRnc TipoRnc => new ControleRncContext().TipoRncs.Find(IdTipoRnc);

        [NotMapped]
        public virtual Departamento Departamento => new ControleRncContext().Departamentos.First(x => x.Codigo == CodDepartamento);

        [NotMapped]
        public virtual Produto Desenho => new ControleRncContext().Produtos.FirstOrDefault(x => x.Codigo == (CodigoDesenho == null ? CodigoEquipamento : CodigoDesenho));

    }
}