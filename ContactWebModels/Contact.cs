using System;
using System.ComponentModel.DataAnnotations;

namespace ContactWebModels
{
    // Cette classe représente un modèle de contact dans l'application.
    public class Contact
    {
        [Key]
        public int Id { get; set; }  // Clé primaire de la table des contacts

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(ContactManagerConstants.MAX_FIRST_NAME_LENGTH)]
        public string FirstName { get; set; }  // Prénom du contact

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(ContactManagerConstants.MAX_LAST_NAME_LENGTH)]
        public string LastName { get; set; }  // Nom de famille du contact

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email Address is required")]
        [StringLength(ContactManagerConstants.MAX_EMAIL_LENGTH)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }  // Adresse e-mail du contact

        [Display(Name = "Mobile Phone")]
        [Required(ErrorMessage = "Phone number is required")]
        [StringLength(ContactManagerConstants.MAX_PHONE_LENGTH)]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        public string PhonePrimary { get; set; }  // Numéro de téléphone mobile principal du contact

        [Display(Name = "Home/Office Phone")]
        [Required(ErrorMessage = "Phone number is required")]
        [StringLength(ContactManagerConstants.MAX_PHONE_LENGTH)]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        public string PhoneSecondary { get; set; }  // Numéro de téléphone de domicile/bureau du contact

        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }  // Date de naissance du contact

        [Display(Name = "Street Address Line 1")]
        [StringLength(ContactManagerConstants.MAX_STREET_ADDRESS_LENGTH)]
        public string StreetAddress1 { get; set; }  // Première ligne de l'adresse du contact

        [Display(Name = "Street Address Line 2")]
        [StringLength(ContactManagerConstants.MAX_STREET_ADDRESS_LENGTH)]
        public string StreetAddress2 { get; set; }  // Deuxième ligne de l'adresse du contact

        [Required(ErrorMessage = "City is required")]
        [StringLength(ContactManagerConstants.MAX_CITY_LENGTH)]
        public string City { get; set; }  // Ville du contact

        [Display(Name = "State")]
        [Required(ErrorMessage = "State is required")]
        public int StateId { get; set; }  // ID de l'État du contact

        public virtual State State { get; set; }  // Relation de navigation vers l'État du contact

        [Required(ErrorMessage = "Zip Code is required")]
        [Display(Name = "Zip Code")]
        [StringLength(ContactManagerConstants.MAX_ZIP_CODE_LENGTH, MinimumLength = ContactManagerConstants.MIN_ZIP_CODE_LENGTH)]
        [RegularExpression("(^\\d{5}(-\\d{4})?$)|(^[ABCEGHJKLMNPRSTVXY]{1}\\d{1}[A-Z]{1} *\\d{1}[A-Z]{1}\\d{1}$)", ErrorMessage = "Zip code is invalid.")] // US or Canada
        public string Zip { get; set; }  // Code postal du contact (avec validation)

        [Required(ErrorMessage = "The User ID is required in order to map the contact to a user correctly")]
        public string UserId { get; set; }  // ID de l'utilisateur auquel le contact est associé

        [Display(Name = "Full Name")]
        public string FriendlyName => $"{FirstName} {LastName}";  // Propriété calculée pour obtenir le nom complet du contact

        [Display(Name = "Full Address")]
        public string FriendlyAddress => State is null ? "" : string.IsNullOrWhiteSpace(StreetAddress1) ? $"{City}, {State.Abbreviation}, {Zip}" :
                                                string.IsNullOrWhiteSpace(StreetAddress2)
                                                    ? $"{StreetAddress1}, {City}, {State.Abbreviation}, {Zip}"
                                                    : $"{StreetAddress1} - {StreetAddress2}, {City}, {State.Abbreviation}, {Zip}";
        // Propriété calculée pour obtenir l'adresse complète du contact
    }
}



//https://stackoverflow.com/questions/16675176/asp-net-mvc-4-zip-code-validation */

