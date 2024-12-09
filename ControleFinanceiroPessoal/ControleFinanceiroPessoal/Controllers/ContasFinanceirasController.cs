using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControleFinanceiroPessoal.Data;
using ControleFinanceiroPessoal.Models;

namespace ControleFinanceiroPessoal.Controllers
{
    public class ContasFinanceirasController : Controller
    {
        private readonly AppDbContext _context;

        public ContasFinanceirasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ContaFinanceiras
        public async Task<IActionResult> Index()
        {
            return View(await _context.ContasFinanceiras.ToListAsync());
        }

        // GET: ContaFinanceiras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contaFinanceira = await _context.ContasFinanceiras
                .FirstOrDefaultAsync(m => m.IdContaFinanceira == id);
            if (contaFinanceira == null)
            {
                return NotFound();
            }

            return View(contaFinanceira);
        }

        // GET: ContaFinanceiras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContaFinanceiras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdContaFinanceira,TipoConta,SaldoAtual,NomeInstituicao")] ContaFinanceira contaFinanceira)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contaFinanceira);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contaFinanceira);
        }

        // GET: ContaFinanceiras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contaFinanceira = await _context.ContasFinanceiras.FindAsync(id);
            if (contaFinanceira == null)
            {
                return NotFound();
            }
            return View(contaFinanceira);
        }

        // POST: ContaFinanceiras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdContaFinanceira,TipoConta,SaldoAtual,NomeInstituicao")] ContaFinanceira contaFinanceira)
        {
            if (id != contaFinanceira.IdContaFinanceira)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contaFinanceira);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContaFinanceiraExists(contaFinanceira.IdContaFinanceira))
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
            return View(contaFinanceira);
        }

        // GET: ContaFinanceiras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contaFinanceira = await _context.ContasFinanceiras
                .FirstOrDefaultAsync(m => m.IdContaFinanceira == id);
            if (contaFinanceira == null)
            {
                return NotFound();
            }

            return View(contaFinanceira);
        }

        // POST: ContaFinanceiras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contaFinanceira = await _context.ContasFinanceiras.FindAsync(id);
            if (contaFinanceira != null)
            {
                _context.ContasFinanceiras.Remove(contaFinanceira);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContaFinanceiraExists(int id)
        {
            return _context.ContasFinanceiras.Any(e => e.IdContaFinanceira == id);
        }
    }
}
