//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KnapSack.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Joueur
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Joueur()
        {
            this.Items = new HashSet<Item>();
            this.Ratings = new HashSet<Rating>();
        }
    
        public int idJoueur { get; set; }
        public byte[] password { get; set; }
        public string alias { get; set; }
        public int dexterite { get; set; }
        public int poidMaximale { get; set; }
        public decimal montantCaps { get; set; }
        public bool isAdmin { get; set; }
    
        public virtual Panier Panier { get; set; }
        public virtual Sac Sac { get; set; }
        public virtual Transaction Transaction { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item> Items { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
