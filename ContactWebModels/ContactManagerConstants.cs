namespace ContactWebModels
{
    // Cette classe contient des constantes utilisées pour définir les longueurs maximales
    // et d'autres valeurs constantes dans l'application.


/*Cette classe contient des constantes utilisées 
 * pour définir diverses longueurs maximales et 
 * valeurs constantes utilisées dans l'application. 
 * Ces constantes sont utilisées pour définir des 
 * contraintes de validation et garantir que les données 
 * saisies par les utilisateurs respectent ces limites.
 * */
public class ContactManagerConstants
{
    // Longueur maximale du nom de l'État
    public const int MAX_STATE_NAME_LENGTH = 50;

    // Longueur maximale de l'abréviation de l'État
    public const int MAX_STATE_ABBR_LENGTH = 4;

    // Longueur maximale du prénom du contact
    public const int MAX_FIRST_NAME_LENGTH = 50;

    // Longueur maximale du nom de famille du contact
    public const int MAX_LAST_NAME_LENGTH = 250;

    // Longueur maximale de l'adresse e-mail du contact
    public const int MAX_EMAIL_LENGTH = 250;

    // Longueur maximale du numéro de téléphone du contact
    public const int MAX_PHONE_LENGTH = 15;

    // Longueur maximale de la première ligne de l'adresse du contact
    public const int MAX_STREET_ADDRESS_LENGTH = 250;

    // Longueur maximale du nom de la ville du contact
    public const int MAX_CITY_LENGTH = 50;

    // Longueur maximale du code postal du contact
    public const int MAX_ZIP_CODE_LENGTH = 10;

    // Longueur minimale du code postal du contact
    public const int MIN_ZIP_CODE_LENGTH = 5;
}
}
