using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.ComponentModel.DataAnnotations;

namespace KnapSack.Models
{
    public abstract class ISpecific 
    {
    }

    public static class ItemSpecific
    {
        public static ISpecific GetISpecificFromId (this KnapsackDBEntities DB, int id)
        {
            string nomType = DB.TypesItems.Where(el => el.idType == id).First().nomType;
            ISpecific res;

            switch (nomType) 
            {
                case "Armure":
                    res = new Armure();
                    break;
                case "Arme":
                    res = new Armure();
                    break;
                case "Medicament":
                    res = new Medicament();
                    break;
                default:
                    res = null;
                    break;
            }

            return res;
        }
    }

    public partial class ItemSpecific<T>
    {
        [Required(ErrorMessage = "Obligatoire")]
        public Item Item { get; set; }

        [Required(ErrorMessage = "Obligatoire")]
        public T Specifics { get; set; }
    }


    public partial class Arme : ISpecific { }
    public partial class Armure : ISpecific { }
    public partial class Medicament : ISpecific { }

}