using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContactWebModels;
using MyContactManagerData;

namespace ContactWebEFCore1.Controllers
{
    /*Ce contrôleur ContactsController gère les opérations CRUD (Create, Read, Update, Delete) pour les contacts.
     * Il utilise le contexte de base de données MyContactManagerDbContext 
     * pour interagir avec la base de données. Les principales actions 
     * incluent la création, l'affichage, la mise à jour et la suppression 
     * de contacts, ainsi que la gestion des états associés.
     * */
    public class ContactsController : Controller
    {
        private readonly MyContactManagerDbContext _context;

        // Constructeur du contrôleur, injecte le contexte de base de données
        public ContactsController(MyContactManagerDbContext context)
        {
            _context = context;
        }

        // Méthode privée pour mettre à jour l'état et réinitialiser le modèle
        private async Task UpdateStateAndResetModelState(Contact contact)
        {
            ModelState.Clear();
            var state = await _context.States.SingleOrDefaultAsync(x => x.Id == contact.StateId);
            contact.State = state;
            TryValidateModel(contact);
        }

        // Action pour afficher la liste des contacts
        public async Task<IActionResult> Index()
        {
            // Charge tous les contacts avec leurs états associés depuis la base de données
            var myContactManagerDbContext = _context.Contacts.Include(c => c.State);
            return View(await myContactManagerDbContext.ToListAsync());
        }

        // Action pour afficher les détails d'un contact
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Contacts == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts
                .Include(c => c.State)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // Action pour afficher le formulaire de création d'un nouveau contact
        public IActionResult Create()
        {
            // Charge la liste des états pour la vue déroulante
            ViewData["StateId"] = new SelectList(_context.States, "Id", "Abbreviation");
            return View();
        }

        // Action pour traiter la création d'un nouveau contact
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,PhonePrimary,PhoneSecondary,Birthday,StreetAddress1,StreetAddress2,City,StateId,Zip,UserId")] Contact contact)
        {
            // Appelle la méthode de mise à jour de l'état et de réinitialisation du modèle
            UpdateStateAndResetModelState(contact);

            if (ModelState.IsValid)
            {
                // Ajoute le contact à la base de données et enregistre les modifications
                _context.Add(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Recharge la liste des états pour la vue déroulante en cas d'erreur
            ViewData["StateId"] = new SelectList(_context.States, "Id", "Abbreviation", contact.StateId);
            return View(contact);
        }

        // Actions pour afficher et traiter la mise à jour d'un contact existant
        // (similaires à l'action Create mais pour la mise à jour)

        // Actions pour afficher et traiter la suppression d'un contact existant

        private bool ContactExists(int id)
        {
            return (_context.Contacts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
