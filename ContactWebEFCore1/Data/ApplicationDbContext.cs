using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ContactWebEFCore1.Data
{
    // Cette classe représente le contexte de la base de données de votre application.
    public class ApplicationDbContext : IdentityDbContext
    {
        // Le constructeur de la classe accepte un objet DbContextOptions en tant que paramètre.
        // Cet objet contient les options de configuration pour le contexte de la base de données.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) // Appel du constructeur de la classe de base (IdentityDbContext) avec les options fournies.
        {
            // Le constructeur configure le contexte de la base de données en utilisant les options spécifiées.
            // Les options définissent, par exemple, la chaîne de connexion à la base de données.
            // Cela permet à Entity Framework Core de savoir comment se connecter à la base de données.

            // IdentityDbContext est une classe fournie par le framework ASP.NET Core Identity.
            // Elle étend DbContext et ajoute des fonctionnalités spécifiques à la gestion de l'identité,
            // telles que la gestion des utilisateurs, des rôles, etc.

            // En résumé, cette classe représente le contexte de base de données de votre application,
            // et le constructeur configure ce contexte en fonction des options fournies.
        }
    }
}
