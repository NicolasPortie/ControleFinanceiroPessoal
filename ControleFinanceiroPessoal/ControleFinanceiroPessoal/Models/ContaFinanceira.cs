using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ControleFinanceiroPessoal.Models
{
    public class ContaFinanceira
    {
        [Key]
        public int IdContaFinanceira { get; set; }

        [Required(ErrorMessage = "Informe o tipo da conta.")]
        [Display(Name = "Tipo de Conta")]
        public string TipoConta { get; set; }

        [Required(ErrorMessage = "Informe o nome da instituição.")]
        [Display(Name = "Nome da Instituição")]
        public string NomeInstituicao { get; set; }

        [Required(ErrorMessage = "Informe o saldo atual.")]
        [Display(Name = "Saldo Atual")]
        [Range(0, double.MaxValue, ErrorMessage = "O saldo deve ser um valor positivo.")]
        public decimal SaldoAtual { get; set; }

        // Propriedades de navegação
        public ICollection<Despesa> Despesas { get; set; }
        public ICollection<Receita> Receitas { get; set; }
    }
}
