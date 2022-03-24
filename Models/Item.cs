//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KnapSack.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Item
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Item()
        {
            this.Paniers = new HashSet<Panier>();
            this.Sacs = new HashSet<Sac>();
            this.Joueurs = new HashSet<Joueur>();
        }
    
        public int idItem { get; set; }
        public string nom { get; set; }
        public short idType { get; set; }
        public decimal prix { get; set; }
        public decimal poid { get; set; }
        public string urlImage { get; set; }
        public int qte { get; set; }
        public Nullable<bool> disponibilite { get; set; }
        public string description { get; set; }
    
        public virtual Arme Arme { get; set; }
        public virtual Armure Armure { get; set; }
        public virtual TypesItem TypesItem { get; set; }
        public virtual Medicament Medicament { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Panier> Paniers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sac> Sacs { get; set; }
        public virtual TypesArme TypesArme { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Joueur> Joueurs { get; set; }
    }
}
