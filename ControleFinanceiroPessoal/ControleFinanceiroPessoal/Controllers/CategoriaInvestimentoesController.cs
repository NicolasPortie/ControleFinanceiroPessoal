using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ControleFinanceiroPessoal.Data;
using ControleFinanceiroPessoal.Models;

namespace ControleFinanceiroPessoal.Controllers
{
    public class CategoriaInvestimentosController : Controller
    {
        private readonly AppDbContext _context;

        public CategoriaInvestimentosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: CategoriaInvestimentos
        public async Task<IActionResult> Index()
        {
            var categorias = await _context.CategoriaInvestimentos.ToListAsync();
            return View(categorias);
        }

        // GET: CategoriaInvestimentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                ModelState.AddModelError("", "Categoria não encontrada.");
                return NotFound();
            }

            var categoriaInvestimento = await _context.CategoriaInvestimentos
                .FirstOrDefaultAsync(m => m.IdCategoriaInvestimento == id);

            if (categoriaInvestimento == null)
            {
                ModelState.AddModelError("", "Categoria não encontrada.");
                return NotFound();
            }

            return View(categoriaInvestimento);
        }

        // GET: CategoriaInvestimentos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoriaInvestimentos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCategoriaInvestimento,NomeInvestimento,TipoCategoria,TaxaJuros,JurosAnual")] CategoriaInvestimento categoriaInvestimento)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(categoriaInvestimento);
                    await _context.SaveChangesAsync();
                    TempData["Sucesso"] = "Categoria criada com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Erro ao salvar categoria: {ex.Message}");
                }
            }
            else
            {
                ModelState.AddModelError("", "Preencha todos os campos obrigatórios.");
            }

            return View(categoriaInvestimento);
        }

        // GET: CategoriaInvestimentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaInvestimento = await _context.CategoriaInvestimentos.FindAsync(id);
            if (categoriaInvestimento == null)
            {
                return NotFound();
            }
            return View(categoriaInvestimento);
        }

        // POST: CategoriaInvestimentos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCategoriaInvestimento,NomeInvestimento,TipoCategoria,TaxaJuros,JurosAnual")] CategoriaInvestimento categoriaInvestimento)
        {
            if (id != categoriaInvestimento.IdCategoriaInvestimento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoriaInvestimento);
                    await _context.SaveChangesAsync();
                    TempData["Sucesso"] = "Categoria atualizada com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaInvestimentoExists(categoriaInvestimento.IdCategoriaInvestimento))
                    {
                        return NotFound();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Erro de concorrência ao atualizar categoria.");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Erro ao atualizar categoria: {ex.Message}");
                }
            }
            else
            {
                ModelState.AddModelError("", "Preencha todos os campos obrigatórios.");
            }

            return View(categoriaInvestimento);
        }

        // GET: CategoriaInvestimentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                ModelState.AddModelError("", "Categoria não encontrada.");
                return NotFound();
            }

            var categoriaInvestimento = await _context.CategoriaInvestimentos
                .FirstOrDefaultAsync(m => m.IdCategoriaInvestimento == id);

            if (categoriaInvestimento == null)
            {
                ModelState.AddModelError("", "Categoria não encontrada.");
                return NotFound();
            }

            return View(categoriaInvestimento);
        }

        // POST: CategoriaInvestimentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var categoriaInvestimento = await _context.CategoriaInvestimentos.FindAsync(id);

                if (categoriaInvestimento != null)
                {
                    _context.CategoriaInvestimentos.Remove(categoriaInvestimento);
                    await _context.SaveChangesAsync();
                    TempData["Sucesso"] = "Categoria excluída com sucesso!";
                }
                else
                {
                    ModelState.AddModelError("", "Categoria não encontrada.");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Erro ao excluir categoria: {ex.Message}");
            }

            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaInvestimentoExists(int id)
        {
            return _context.CategoriaInvestimentos.Any(e => e.IdCategoriaInvestimento == id);
        }
    }
}
