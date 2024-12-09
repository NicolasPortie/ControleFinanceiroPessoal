using System.Diagnostics;
using ControleFinanceiroPessoal.Models;
using ControleFinanceiroPessoal.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace ControleFinanceiroPessoal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // Ação para a página inicial
        public IActionResult Index()
        {
            // Consultando as receitas e despesas no banco de dados
            var receitas = _context.Receitas.ToList();
            var despesas = _context.Despesas.ToList();

            // Calculando o total de receitas e despesas
            var totalReceitas = receitas.Sum(r => r.Valor);
            var totalDespesas = despesas.Sum(d => d.Valor);

            // Passando os totais para a View (para os gráficos)
            ViewBag.TotalReceitas = totalReceitas;
            ViewBag.TotalDespesas = totalDespesas;

            // Definindo ViewData para a tela inicial (Home)
            ViewData["IsHome"] = true;

            return View();
        }

        // Ação para a página de privacidade
        public IActionResult Privacy()
        {
            return View();
        }

        // Ação para a página de erro
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
