using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Linq;
using System.Web;

namespace KnapSack.Models
{
    [MetadataType(typeof(LoginCredentialView))]
    public partial class LoginCredential
    {
        public Joueur ConvertToJoueur ()
        {
            return new Joueur
            {
                alias = this.Alias,
                password = Encoding.UTF8.GetBytes(this.Password)
            };
        }
        
        public int Id { get; set; }
        public string Alias { get; set; }
        public string Password { get; set; }
    }

    public partial class LoginCredentialView
    {
        [Display(Name = "Alias"), Required(ErrorMessage = "Obligatoire")]
        [DataType(DataType.Text)]
        public string Alias { get; set; }

        [Display(Name = "Mot de passe"), Required(ErrorMessage = "Obligatoire")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}