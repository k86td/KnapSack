using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KnapSack.Models
{
    [MetadataType(typeof(JoueursView))]
    public partial class Joueur 
    {
        // need to do this since the generated schema doesn't permit using default values
        public Joueur(LoginCredentialCreate credential)
        {
            this.alias = credential.Alias;
            this.password = credential.GetEncodedPassword();

            this.dexterite = 100;
            this.poidMaximale = 50;
            this.isAdmin = false;
            this.montantCaps = 1000;
        }
    }

    public class JoueursView
    {
        public byte[] password { get; set; }

        [Required(ErrorMessage = "Obligatoire")]
        public string alias { get; set; }

        [Range(1, 100, ErrorMessage = "La dexterite doit etre entre {1} et {2}")]
        public int dexterite { get; set; }
    }
}