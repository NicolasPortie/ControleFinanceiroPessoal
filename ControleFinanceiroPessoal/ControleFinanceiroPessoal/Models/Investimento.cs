using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleFinanceiroPessoal.Models
{
    public class Investimento
    {
        [Key]
        public int IdInvestimento { get; set; }

        // Configuração correta da Foreign Key
        [Required(ErrorMessage = "Selecione uma categoria de investimento.")]
        public int IdCategoriaInvestimento { get; set; }

        // Relacionamento com a chave estrangeira
        [ForeignKey(nameof(IdCategoriaInvestimento))]
        public CategoriaInvestimento CategoriaInvestimento { get; set; }

        [Required(ErrorMessage = "Informe o valor investido.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero.")]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Valor Investido")]
        public decimal ValorInvestido { get; set; }

        [Required(ErrorMessage = "Informe a data do investimento.")]
        [Display(Name = "Data do Investimento")]
        public DateTime DataInvestimento { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Valor Futuro")]
        public decimal? ValorFuturo { get; set; }
    }
}
