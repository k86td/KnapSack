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
                KnapSackDbEntities DB = new KnapSackDbEntities();
                return DB.TypesItems.Where(sel => sel.idType == this.idType).First().nomType;
            }
        }
    }

    public partial class ItemsView
    {
        [Display(Name = "Nom objet")]
        public string nom { get; set; }

        [Display(Name = "Image")]
        public string urlImage { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:0} caps"), Display(Name = "Prix")]
        public decimal prix { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:0} livres"), Display(Name = "Poid")]
        public decimal poid { get; set; }
    }
}