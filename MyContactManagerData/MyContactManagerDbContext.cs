using ContactWebModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;


/*
 * Cette classe MyContactManagerDbContext est le contexte 
 * de la base de données de l'application. Elle gère les DbSet 
 * pour les États et les Contacts, configure la connexion 
 * à la base de données à partir du fichier appsettings.json, 
 * et fournit des données initiales pour les États grâce 
 * à la méthode OnModelCreating.
Les DbSet permettent d'accéder aux données dans la base de 
données à l'aide d'Entity Framework Core. Le constructeur 
par défaut est nécessaire pour le scaffolding (génération automatique de code), 
tandis que le constructeur avec options est utilisé 
pour l'injection de dépendances.

La méthode OnConfiguring configure la connexion à la base 
de données en utilisant les informations de connexion 
du fichier appsettings.json.

La méthode OnModelCreating est utilisée pour configurer 
le modèle de données, y compris la fourniture de données 
initiales pour les États.
 * 
 */
namespace MyContactManagerData
{
    // Cette classe représente le contexte de base de données pour l'application.
    public class MyContactManagerDbContext : DbContext
    {
        private static IConfigurationRoot _configuration;

        // DbSet pour les États et les Contacts
        public DbSet<State> States { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        // Constructeur par défaut nécessaire pour Scaffold
        public MyContactManagerDbContext()
        {
            // À des fins de Scaffold, ce constructeur est laissé vide.
        }

        // Constructeur avec options pour l'injection de dépendances
        public MyContactManagerDbContext(DbContextOptions options)
            : base(options)
        {
            // À des fins d'injection de dépendances, ce constructeur prend des options de DbContext.
        }

        // Configuration de la connexion à la base de données à partir du fichier appsettings.json
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            _configuration = builder.Build();
            var cnstr = _configuration.GetConnectionString("MyContactManager");
            optionsBuilder.UseSqlServer(cnstr);
        }

        // Configuration du modèle de données avec les données initiales pour les États
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<State>(x =>
            {
                x.HasData(
                    // Exemple de données initiales pour les États
                    new State() { Id = 1, Name = "Alabama", Abbreviation = "AL" },
                    new State() { Id = 2, Name = "Alaska", Abbreviation = "AK" },
                    // ... (Données pour d'autres États)
                    new State() { Id = 50, Name = "Wisconsin", Abbreviation = "WI" },
                    new State() { Id = 51, Name = "Wyoming", Abbreviation = "WY" }
                );
            });
        }
    }
}
