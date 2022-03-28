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
    }

    public partial class ItemsView
    {
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:0} caps")]
        public decimal prix { get; set; }
    }
}