using ContactWebEFCore1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ContactWebEFCore1.Controllers
{
   /* Ce contrôleur est principalement responsable de la gestion des pages 
    * statiques comme la page d'accueil et la page de confidentialité, 
    * ainsi que de la gestion des erreurs et de la journalisation 
    * des informations.*/
    // Ce contrôleur gère les actions liées à la page d'accueil,
    // la confidentialité et les erreurs.
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // Le constructeur accepte un ILogger de type HomeController pour la journalisation.
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Action Index() renvoie la vue de la page d'accueil.
        public IActionResult Index()
        {
            return View();
        }

        // Action Privacy() renvoie la vue de la page de confidentialité.
        public IActionResult Privacy()
        {
            return View();
        }

        // Action Error() renvoie la vue d'erreur avec des informations de suivi.
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Crée une nouvelle instance de ErrorViewModel avec un identifiant de requête ou l'identifiant de trace actuel.
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
