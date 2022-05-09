using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace KnapSack.Models
{
    [MetadataType(typeof(ItemsView))]
    public partial class Item
    {
        public string TypeItem 
        {
            get
            {
                KnapsackDBEntities DB = new KnapsackDBEntities();
                return DB.TypesItems.Where(sel => sel.idType == this.idType).First().nomType;
            }
        }
    }

    public partial class ItemsView
    {
        [Display(Name = "Nom objet"), Required(ErrorMessage = "Obligatoire")]
        public string nom { get; set; }

        [Display(Name = "Image"), Required(ErrorMessage = "Obligatoire")]
        public string urlImage { get; set; }

        [Display(Name = "Disponibilité"), Required(ErrorMessage = "Obligatoire")]
        public bool disponibilite { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:0} caps"), Display(Name = "Prix"), Required(ErrorMessage = "Obligatoire")]
        [Range(1, 100, ErrorMessage = "Le prix n'est pas valide!")]
        public decimal prix { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:0} livres"), Display(Name = "Poid"), Required(ErrorMessage = "Obligatoire")]
        [Range(1, 20, ErrorMessage = "Le poid n'est pas valide!")]
        public decimal poid { get; set; }
    }
}