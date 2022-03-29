using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using System.ComponentModel.DataAnnotations;

namespace KnapSack.Models
{
    [MetadataType(typeof(JoueursView))]
    public partial class Joueur 
    {
        private string _passwordString;

        [DataType(DataType.Password)]
        public string PasswordString
        {
            get => _passwordString;
            set { 
                password = System.Text.Encoding.UTF8.GetBytes(value);
                _passwordString = value;
            }
        }
    }

    public class JoueursView
    {
        public byte[] password { get; set; }

        [Required(ErrorMessage = "Obligatoire")]
        [Remote("Alias_isAvailable", "Joueurs", HttpMethod = "GET", ErrorMessage = "Cet alias existe deja! Utiliser en un autre")]
        public string alias { get; set; }

        [Range(0, 100, ErrorMessage = "La dexterite doit etre entre {1} et {2}")]
        public int dexterite { get; set; }

    }
}