using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleFinanceiroPessoal.Models
{
    [Table("CategoriaInvestimento")]
    public class CategoriaInvestimento
    {
        [Key]
        public int IdCategoriaInvestimento { get; set; }

        [Required(ErrorMessage = "O nome do investimento é obrigatório.")]
        [Display(Name = "Nome do Investimento")]
        public string NomeInvestimento { get; set; }

        [Required(ErrorMessage = "A Categoria do investimento é obrigatória.")]
        [Display(Name = "Tipo de Categoria")]
        public string TipoCategoria { get; set; }

        public bool TaxaJuros { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Juros Anual (%)")]
        public decimal? JurosAnual { get; set; }

        public ICollection<Investimento> Investimentos { get; set; }
    }
}
