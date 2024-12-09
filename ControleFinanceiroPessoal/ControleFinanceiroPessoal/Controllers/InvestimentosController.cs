using Microsoft.AspNetCore.Mvc;
using ControleFinanceiroPessoal.Data;
using ControleFinanceiroPessoal.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiroPessoal.Controllers
{
    public class InvestimentosController : Controller
    {
        private readonly AppDbContext _context;

        public InvestimentosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Investimentos
        public async Task<IActionResult> Index()
        {
            var investimentos = await _context.Investimentos
                .Include(i => i.CategoriaInvestimento)
                .ToListAsync();
            return View(investimentos);
        }

        // GET: Investimentos/Create
        public IActionResult Create()
        {
            ViewBag.Categorias = _context.CategoriaInvestimentos
                .Select(ci => new { ci.IdCategoriaInvestimento, NomeCompleto = ci.TipoCategoria + " - " + ci.NomeInvestimento })
                .ToList();
            return View();
        }

        // POST: Investimentos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Investimento investimento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(investimento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categorias = _context.CategoriaInvestimentos
                .Select(ci => new { ci.IdCategoriaInvestimento, NomeCompleto = ci.TipoCategoria + " - " + ci.NomeInvestimento })
                .ToList();
            return View(investimento);
        }

        // GET: Investimentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var investimento = await _context.Investimentos.FindAsync(id);
            if (investimento == null)
            {
                return NotFound();
            }
            ViewBag.Categorias = _context.CategoriaInvestimentos
                .Select(ci => new { ci.IdCategoriaInvestimento, NomeCompleto = ci.TipoCategoria + " - " + ci.NomeInvestimento })
                .ToList();
            return View(investimento);
        }

        // POST: Investimentos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Investimento investimento)
        {
            if (id != investimento.IdInvestimento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(investimento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Investimentos.Any(e => e.IdInvestimento == id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categorias = _context.CategoriaInvestimentos
                .Select(ci => new { ci.IdCategoriaInvestimento, NomeCompleto = ci.TipoCategoria + " - " + ci.NomeInvestimento })
                .ToList();
            return View(investimento);
        }
    }
}
