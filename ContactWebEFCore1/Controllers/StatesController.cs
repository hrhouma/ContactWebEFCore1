using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContactWebModels;
using MyContactManagerData;

/*
 * Ce contrôleur gère les opérations CRUD (Create, Read, Update, Delete) 
 * pour l'entité "State" (État) dans l'application web. 
 * Il récupère les données depuis la base de données et les affiche 
 * dans les vues correspondantes, permettant ainsi à l'utilisateur de créer, 
 * modifier ou supprimer des États.
 * 
 */
namespace ContactWebEFCore1.Controllers
{
    // Ce contrôleur gère les actions liées à l'entité "State" (État).
    public class StatesController : Controller
    {
        private readonly MyContactManagerDbContext _context;

        // Le constructeur accepte une instance de MyContactManagerDbContext pour accéder à la base de données.
        public StatesController(MyContactManagerDbContext context)
        {
            _context = context;
        }

        // GET: States
        // L'action Index récupère la liste des États depuis la base de données et les renvoie à la vue Index.
        public async Task<IActionResult> Index()
        {
            // Vérifie si l'ensemble d'entités 'States' n'est pas null, puis renvoie la vue Index avec la liste des États.
            // Sinon, renvoie une erreur avec un message approprié.
            return _context.States != null ?
                View(await _context.States.ToListAsync()) :
                Problem("Entity set 'MyContactManagerDbContext.States'  is null.");
        }

        // GET: States/Details/5
        // L'action Details récupère les détails d'un État en fonction de son ID et les renvoie à la vue Details.
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.States == null)
            {
                return NotFound();
            }

            var state = await _context.States
                .FirstOrDefaultAsync(m => m.Id == id);
            if (state == null)
            {
                return NotFound();
            }

            return View(state);
        }

        // GET: States/Create
        // L'action Create renvoie la vue permettant de créer un nouvel État.
        public IActionResult Create()
        {
            return View();
        }

        // POST: States/Create
        // L'action Create traite la soumission du formulaire de création d'un État.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Abbreviation")] State state)
        {
            if (ModelState.IsValid)
            {
                _context.Add(state);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(state);
        }

        // GET: States/Edit/5
        // L'action Edit renvoie la vue pour modifier les détails d'un État en fonction de son ID.
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.States == null)
            {
                return NotFound();
            }

            var state = await _context.States.FindAsync(id);
            if (state == null)
            {
                return NotFound();
            }
            return View(state);
        }

        // POST: States/Edit/5
        // L'action Edit traite la soumission du formulaire de modification d'un État.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Abbreviation")] State state)
        {
            if (id != state.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(state);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StateExists(state.Id))
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
            return View(state);
        }

        // GET: States/Delete/5
        // L'action Delete renvoie la vue pour supprimer un État en fonction de son ID.
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.States == null)
            {
                return NotFound();
            }

            var state = await _context.States
                .FirstOrDefaultAsync(m => m.Id == id);
            if (state == null)
            {
                return NotFound();
            }

            return View(state);
        }

        // POST: States/Delete/5
        // L'action Delete traite la soumission du formulaire de suppression d'un État.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.States == null)
            {
                return Problem("Entity set 'MyContactManagerDbContext.States'  is null.");
            }
            var state = await _context.States.FindAsync(id);
            if (state != null)
            {
                _context.States.Remove(state);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Méthode privée pour vérifier si un État existe en fonction de son ID.
        private bool StateExists(int id)
        {
            return (_context.States?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
