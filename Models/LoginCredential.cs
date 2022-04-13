using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Linq;
using System.Web.Mvc;

namespace KnapSack.Models
{
    /// <summary>
    /// Abstract class to implement features interacting with LoginCredential
    /// </summary>
    public abstract class LoginCredential
    {
        public Joueur ConvertToJoueur()
        {
            return new Joueur
            {
                alias = this.Alias,
                password = Encoding.UTF8.GetBytes(this.Password)
            };
        }

        public byte[] GetEncodedPassword()
        {
            if (this.Password is null)
                throw new Exception("Le password n'est pas definit!");

            return Encoding.UTF8.GetBytes(this.Password);
        }


        public int Id { get; set; }
        public string Alias { get; set; }
        public string Password { get; set; }
    }

    /// <summary>
    /// Used for DataAnnotation of creation of a LoginCredential
    /// </summary>
    [MetadataType(typeof(LoginCredentialCreateView))]
    public partial class LoginCredentialCreate : LoginCredential
    { }
    public partial class LoginCredentialCreateView
    {
        [DataType(DataType.Text)]
        [Display(Name = "Alias"), Required(ErrorMessage = "Obligatoire")]
        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "L'alias doit etre entre 3 et 50 charactere")]
        [Remote("Alias_isAvailable", "Joueurs", HttpMethod = "POST", ErrorMessage = "Cet alias est déjà utilisé! Essayer en un autre!")]
        public string Alias { get; set; }

        [Display(Name = "Mot de passe"), Required(ErrorMessage = "Obligatoire")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    /// <summary>
    /// Used for DataAnnotation of access of a LoginCredential
    /// </summary>
    [MetadataType(typeof(LoginCredentialAccessView))]
    public partial class LoginCredentialAccess : LoginCredential
    { }
    public partial class LoginCredentialAccessView
    {
        [DataType(DataType.Text)]
        [Display(Name = "Alias"), Required(ErrorMessage = "Obligatoire")]
        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "L'alias doit etre entre 3 et 50 charactere")]
        public string Alias { get; set; }

        [Display(Name = "Mot de passe"), Required(ErrorMessage = "Obligatoire")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}