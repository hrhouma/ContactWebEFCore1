using System.ComponentModel.DataAnnotations;

namespace ContactWebModels
{
    // Cette classe représente un État avec des propriétés telles que l'ID, le nom et l'abréviation.
/*
 * Cette classe représente un État avec trois propriétés :

Id : Il s'agit de l'identifiant unique de l'État, 
généralement utilisé comme clé primaire dans la base de données.
Name : Il s'agit du nom complet de l'État. La propriété 
est décorée avec des attributs pour spécifier son affichage et 
définir des contraintes de validation.
Abbreviation : Il s'agit de l'abréviation de l'État, 
telle que "CA" pour la Californie. Cette propriété est également décorée 
avec des attributs de validation.
Les attributs Display sont utilisés pour spécifier comment le nom de 
l'État doit être affiché dans l'interface utilisateur. Les attributs 
Required indiquent que certaines propriétés sont obligatoires et 
les attributs StringLength définissent des limites de longueur 
pour les chaînes de caractères.

Cette classe est utilisée pour représenter les États dans 
l'application et est mappée à une table dans la base de données 
grâce à Entity Framework Core.
*/

public class State
{
    [Key]
    public int Id { get; set; } // Identifiant unique de l'État

    [Display(Name = "State")]
    [Required(ErrorMessage = "Name of State is required")]
    [StringLength(ContactManagerConstants.MAX_STATE_NAME_LENGTH)]
    public string Name { get; set; } // Nom de l'État

    [Required(ErrorMessage = "State Abbreviation is required")]
    [StringLength(ContactManagerConstants.MAX_STATE_ABBR_LENGTH)]
    public string Abbreviation { get; set; } // Abréviation de l'État
}
}
