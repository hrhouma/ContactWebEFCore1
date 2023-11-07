namespace ContactWebEFCore1.Models
{
    /*Ce mod�le est utilis� pour afficher les d�tails d'erreur 
     * dans la vue lorsqu'une erreur se produit dans l'application. 
     * La propri�t� RequestId contient l'identifiant de la demande 
     * associ�e � l'erreur, et la propri�t� calcul�e ShowRequestId 
     * renvoie vrai si RequestId n'est pas null ou vide, ce qui indique 
     * qu'il y a des d�tails d'erreur � afficher.
     * */
    // Ce mod�le est utilis� pour g�rer les erreurs et les d�tails d'erreur
    // dans l'application.
    public class ErrorViewModel
    {
        // ID de la demande associ�e � l'erreur.
        public string? RequestId { get; set; }

        // Propri�t� calcul�e qui renvoie vrai si RequestId n'est pas null ou vide.
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
