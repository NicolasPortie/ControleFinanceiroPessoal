using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleFinanceiroPessoal.Models
{
    public class Receita
    {
        [Key]
        public int IdReceita { get; set; }

        [Required(ErrorMessage = "Informe o valor.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero.")]
        public decimal Valor { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Informe a data de recebimento.")]
        public DateTime DataRecebimento { get; set; }

        [Required(ErrorMessage = "Selecione uma conta financeira.")]
        public int IdContaFinanceira { get; set; }

        [ForeignKey("IdContaFinanceira")]
        public ContaFinanceira ContaFinanceira { get; set; }

        public string FormaRecebimento { get; set; }
        public bool Recorrente { get; set; }
        public string Intervalo { get; set; }
        public DateTime? DataFinalRecebimento { get; set; }
    }
}
