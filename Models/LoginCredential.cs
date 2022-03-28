using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KnapSack.Models
{
    public class LoginCredential
    {
        [Display(Name = "Alias"), Required(ErrorMessage = "Obligatoire")]
        [DataType(DataType.Text)]
        public string Alias { get; set; }

        [Display(Name = "Mot de passe"), Required(ErrorMessage = "Obligatoire")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}