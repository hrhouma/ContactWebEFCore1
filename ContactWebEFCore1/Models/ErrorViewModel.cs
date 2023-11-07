namespace ContactWebEFCore1.Models
{
    /*Ce modèle est utilisé pour afficher les détails d'erreur 
     * dans la vue lorsqu'une erreur se produit dans l'application. 
     * La propriété RequestId contient l'identifiant de la demande 
     * associée à l'erreur, et la propriété calculée ShowRequestId 
     * renvoie vrai si RequestId n'est pas null ou vide, ce qui indique 
     * qu'il y a des détails d'erreur à afficher.
     * */
    // Ce modèle est utilisé pour gérer les erreurs et les détails d'erreur
    // dans l'application.
    public class ErrorViewModel
    {
        // ID de la demande associée à l'erreur.
        public string? RequestId { get; set; }

        // Propriété calculée qui renvoie vrai si RequestId n'est pas null ou vide.
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
