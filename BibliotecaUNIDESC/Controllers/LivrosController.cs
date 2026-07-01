
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BibliotecaUNIDESC.Models;
using BibliotecaUNIDESC.Data;

public class LivrosController : Controller
{
    private readonly BibliotecaContext _context;

    public LivrosController(BibliotecaContext context)
    {
        _context = context;
    }


    public async Task<IActionResult> Index(string pesquisa, string categoria)
    {
        ViewData["Pesquisa"] = pesquisa;
        ViewData["Categoria"] = categoria;

        var livros = _context.Livros.AsQueryable();

        if (!string.IsNullOrEmpty(pesquisa))
        {
            livros = livros.Where(l =>
                l.Titulo.Contains(pesquisa) ||
                l.Autor.Contains(pesquisa));
        }

        if (!string.IsNullOrEmpty(categoria))
        {
            livros = livros.Where(l => l.Categoria == categoria);
        }

        ViewBag.Categorias = await _context.Livros
            .Select(l => l.Categoria)
            .Distinct()
            .OrderBy(c => c)
            .ToListAsync();

        return View(await livros.ToListAsync());
    }


    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var livro = await _context.Livros
            .FirstOrDefaultAsync(m => m.Id == id);
        if (livro == null)
        {
            return NotFound();
        }

        return View(livro);
    }

    
    public IActionResult Create()
    {
        return View();
    }

    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Titulo,Autor,Categoria,AnoPublicacao,Quantidade")] Livro livro)
    {
        if (ModelState.IsValid)
        {
            _context.Add(livro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(livro);
    }

    
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var livro = await _context.Livros.FindAsync(id);
        if (livro == null)
        {
            return NotFound();
        }
        return View(livro);
    }

    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Titulo,Autor,Categoria,AnoPublicacao,Quantidade")] Livro livro)
    {
        if (id != livro.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(livro);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LivroExists(livro.Id))
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
        return View(livro);
    }

    
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var livro = await _context.Livros
            .FirstOrDefaultAsync(m => m.Id == id);
        if (livro == null)
        {
            return NotFound();
        }

        return View(livro);
    }

    
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var livro = await _context.Livros.FindAsync(id);
        if (livro != null)
        {
            _context.Livros.Remove(livro);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool LivroExists(int? id)
    {
        return _context.Livros.Any(e => e.Id == id);
    }
}
