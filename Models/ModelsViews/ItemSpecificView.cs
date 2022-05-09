using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace KnapSack.Models
{
    #region Armure

    [MetadataType(typeof(ArmureView))]
    public partial class Armure { }
    
    public class ArmureView
    {
        [Required(ErrorMessage = "Obligatoire")]
        public string matiere { get; set; }

        [Required(ErrorMessage = "Obligatoire")]
        public int taille { get; set; }
    }

    #endregion

    #region Arme

    [MetadataType(typeof(ArmeView))]
    public partial class Arme { }

    public class ArmeView
    {
        [Display(Name = "Type de l'arme")]
        [Required(ErrorMessage = "Obligatoire")]
        public int type { get; set; }

        [Display(Name = "Efficacité")]
        [Required(ErrorMessage = "Obligatoire")]
        public int efficacite { get; set; }
    }

    #endregion

    #region Medicament

    [MetadataType(typeof(MedicamentView))]
    public partial class Medicament { }

    public class MedicamentView
    {
        [Display(Name = "Durée de l'effet")]
        [Required(ErrorMessage = "Obligatoire")]
        public int dureeEffet { get; set; }

        [Display(Name = "Effet attendu")]
        [Required(ErrorMessage = "Obligatoire")]
        public string effetAttendu { get; set; }
    }

    #endregion

}